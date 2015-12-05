using System;
using NServiceBus;

namespace IMT.Bus.Messages.Commands
{
    public class RegisterNewOrganizationResponse : IMessage
    {
        public Guid RegistrationId { get; set; }
        public string Email { get; set; }
        public string Subdomain { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}