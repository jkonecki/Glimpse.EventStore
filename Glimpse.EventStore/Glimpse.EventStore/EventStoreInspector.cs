using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glimpse.Core.Extensibility;

namespace Glimpse.EventStore
{
    public class EventStoreInspector : IInspector
    {
        public void Setup(IInspectorContext context)
        {
            ProfiledEventStoreConnection.InspectorContext = context;
        }
    }
}
