using System;
using NServiceBus;

namespace IMT.Bus.Messages.Commands
{
    public class RegisterNewOrganizationRequest : IMessage
    {
        public RegisterNewOrganizationRequest()
        {
            RegistrationId = Guid.NewGuid();
        }

        public Guid RegistrationId { get; set; }        
        public Guid TierId { get; set; }
        public string Subdomain { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }    
    }
}