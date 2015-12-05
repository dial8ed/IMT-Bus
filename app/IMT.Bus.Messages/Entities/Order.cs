using System;

namespace IMT.Bus.Messages.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Subdomain { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public Guid Tier { get; set; }
        public decimal Price { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public bool Completed { get; set; }
        public string Details { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public bool Approved { get; set; }
        public string AuthorizationCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string Message { get; set; }
        public string ResponseCode { get; set; }
        public string TransactionId { get; set; }
    }
}