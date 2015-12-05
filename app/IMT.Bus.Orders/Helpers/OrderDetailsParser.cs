using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace IMT.Bus.Orders.Helpers
{
    public class CustomTypeResolver : JavaScriptTypeResolver
    {
        public override Type ResolveType(string id)
        {
            return typeof(Dictionary<object, object>);
        }

        public override string ResolveTypeId(Type type)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderDetailsParser
    {
        public static dynamic Parse(string data)
        {
            var serializer = new JavaScriptSerializer(new CustomTypeResolver());
            serializer.MaxJsonLength = int.MaxValue;
            var order = serializer.DeserializeObject(data) as Dictionary<object, object>;

            if (order == null)
                return new {Error = "Unable To Parse"};

            return new
                       {
                           cc_number = order["cc_number"], 
                           cc_first_name = order["cc_first_name"], 
                           cc_last_name = order["cc_last_name"], 
                           exp_month = order["exp_month"],
                           exp_year = order["exp_year"],
                           payment_type = order["payment_type"],
                           security_code = order["security_code"]
                       };
        }         
    }
}