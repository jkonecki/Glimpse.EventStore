using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Extensions;
using Glimpse.Core.Tab.Assist;

namespace Glimpse.EventStore.UI
{
    class EventStoreTab : TabBase, ITabSetup, IKey
    {
        private static readonly object Layout;

        static EventStoreTab()
        {
            Layout = TabLayout.Create().Row(delegate(TabLayoutRow r)
            {
                r.Cell(0).WidthInPixels(100);
                r.Cell(1).WidthInPixels(100);
                r.Cell(2).WidthInPixels(70).AlignRight();
                r.Cell(3);
            }).Build();
        }
    
        public override object GetData(ITabContext context)
        {
            var activity = context.GetMessages<Messages.ConnectionActivity>().ToList();

            return activity;
        }

        public override string Name
        {
            get { return "Event Store"; }
        }
    
        public void Setup(ITabSetupContext context)
        {
            context.PersistMessages<Messages.ConnectionActivity>();
        }

        public object GetLayout()
        {
            return Layout;
        }

        public string Key
        {
            get { return "Glimpse.EventStore"; }
        }
    }
}
