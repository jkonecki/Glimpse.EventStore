using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glimpse.Core.Extensibility;

namespace Glimpse.EventStore.UI
{
    class EventStoreTab : TabBase
    {
        public override object GetData(ITabContext context)
        {
            var data = new List<object[]>();
            data.Add(new object[] { "Key", "Value" });
            data.Add(new object[] { "1", "Sample 1" });
            data.Add(new object[] { "2", "Sample 2" });
            data.Add(new object[] { "3", "Sample 3" });
            
            return data;
        }

        public override string Name
        {
            get { return "Event Store"; }
        }
    }
}
