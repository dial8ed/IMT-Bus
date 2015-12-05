using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IMT.Bus.DataSync.DataChangedListeners;

namespace IMT.Bus.DataSync.Notifiers
{
    public abstract class SqlDependencyNotifier<TData> : IDataChangedNotifier<TData>
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        protected abstract string CommandSql { get; }
        protected abstract string ConnectionString { get; }
        protected abstract void RefreshData(SqlDataReader reader);
        protected abstract TData Data { get; }
        
        private IEnumerable<IDataChangedListener<TData>> _listeners;

        protected SqlDependencyNotifier(IEnumerable<IDataChangedListener<TData>> listeners)
        {
            _listeners = listeners;
            _sqlConnection = GetSqlConnection();
            _sqlCommand = GetSqlCommand();
        }

        private string GetConnectionString()
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new NullReferenceException("ConnectionString cannot be empty");

            return ConnectionString;
        }

        private string GetCommandSql()
        {
            if (string.IsNullOrEmpty(CommandSql))
                throw new NullReferenceException("CommandSql cannot be empty");

            return CommandSql;
        }

        private SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(GetConnectionString());
            return connection;
        }

        private SqlCommand GetSqlCommand()
        {
            var command = new SqlCommand(GetCommandSql());
            command.Connection = _sqlConnection;
            command.CommandType = CommandType.Text;
            command.Notification = null;
            return command;
        }

        private void RefreshDataAndReSubscribe()
        {
            _sqlCommand.Notification = null;

            SqlDependency dependency = new SqlDependency(_sqlCommand);
            dependency.OnChange += dependency_OnChange;

            _sqlConnection.Open();
            using (var dataReader = _sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
            {                
                RefreshData(dataReader);                
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            var dependency = (SqlDependency) sender;
            dependency.OnChange -= dependency_OnChange;
            RefreshDataAndReSubscribe();
            NotifyListeners(Data);
        }

        public virtual void NotifyListeners(TData data)
        {
            foreach (var listener in _listeners)
            {
                listener.Notify(data);
            }
        }

        public void StartListening()
        {
            SqlDependency.Stop(GetConnectionString());
            SqlDependency.Start(GetConnectionString());
            RefreshDataAndReSubscribe();
        }

        public void StopListening()
        {
            SqlDependency.Stop(GetConnectionString());
        }
    }
}