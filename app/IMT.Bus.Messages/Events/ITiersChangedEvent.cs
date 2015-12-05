using System.Collections.Generic;
using IMT.Bus.Messages.Entities;
using NServiceBus;

namespace IMT.Bus.Messages.Events
{
    public interface ITiersChangedEvent : IEvent
    {
        List<Tier> Tiers { get; set; }
    } 
}