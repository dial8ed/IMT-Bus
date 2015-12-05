using System;

namespace IMT.Bus.Messages.Entities
{
    public class Tier
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int MaxUsers { get; set; }
        public virtual int MaxBarcodes { get; set; }
        public virtual int MaxDays { get; set; }
        public virtual int MaxImages { get; set; }
    }
}