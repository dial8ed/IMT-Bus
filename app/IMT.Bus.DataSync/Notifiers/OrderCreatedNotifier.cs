using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using IMT.Bus.DataSync.DataChangedListeners;
using IMT.Bus.Messages.Entities;

namespace IMT.Bus.DataSync.Notifiers
{
    public class OrderCreatedNotifier : SqlDependencyNotifier<List<Order>>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["IMT"].ConnectionString;
        private const string _commandSql =
            "SELECT  id, subdomain, company, first_name, last_name, title, email, tier, price, street_address, city, postal, country, completed, details, created, modified, Approved, AuthorizationCode, TransactionID FROM  dbo.[Order] WHERE Approved=1 AND completed=0";

        private List<Order> _orders = new List<Order>();

        public OrderCreatedNotifier(IEnumerable<IDataChangedListener<List<Order>>> listeners) : base(listeners)
        {
        }

        protected override string CommandSql
        {
            get { return _commandSql; }
        }

        protected override string ConnectionString
        {
            get { return _connectionString; }
        }

        protected override void RefreshData(SqlDataReader reader)
        {
            _orders.Clear();
            while(reader.Read())
            {
                _orders.Add(new Order()
                {
                    City = reader["city"].ToString(),
                    Company = reader["company"].ToString(),
                    Completed = bool.Parse(reader["completed"].ToString()),
                    Country = reader["country"].ToString(),
                    Created = DateTime.Parse(reader["created"].ToString()),
                    Details = reader["details"].ToString(),
                    Email = reader["email"].ToString(),
                    FirstName = reader["first_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    Id = Guid.Parse(reader["id"].ToString()),
                    Subdomain = reader["subdomain"].ToString(),
                    Title = reader["title"].ToString(),
                    Tier = Guid.Parse(reader["tier"].ToString()),
                    Price = Decimal.Parse(reader["price"].ToString()),
                    //Modified = DateTime.TryParse(reader["modified"].ToString()),
                    StreetAddress = reader["street_address"].ToString(),
                    Postal = reader["postal"].ToString(),
                    Approved = bool.Parse(reader["Approved"].ToString()),
                    AuthorizationCode = reader["AuthorizationCode"].ToString(),
                    TransactionId  = reader["TransactionID"].ToString()
                }); 
            }
        }

        protected override List<Order> Data
        {
            get { return _orders; }
        }
    }
}