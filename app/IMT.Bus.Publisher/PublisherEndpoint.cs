using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace IMT.Bus.Publisher
{
    [EndpointName("imt-publisher-input")]
    public class PublisherEndpoint : IConfigureThisEndpoint, AsA_Publisher
    {   
     
    }
}
