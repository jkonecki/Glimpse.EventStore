using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glimpse.Core.Message;

namespace Glimpse.EventStore.Messages
{
    internal class ConnectionActivity
    {
        public string ConnectionName { get; set; }
        public string Name { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public object Arguments { get; set; }
        public object Results { get; set; }
    }
}
