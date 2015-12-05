using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace IMT.Bus.Messages.Events
{    
    [Recoverable]
    public interface ICustomerCreated : ICommand 
    {
        Guid TierId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Subdomain { get; set; }        
        string Email { get; set; }
        string Company { get; set; }
    }
}
