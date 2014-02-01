using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using Glimpse.Core.Extensibility;

namespace Glimpse.EventStore
{
    public static class ProfiledEventStoreConnection
    {
        public static IEventStoreConnection Create(IPEndPoint tcpEndPoint, string connectionName = null)
        {
            return new EventStoreConnectionProfiler(EventStoreConnection.Create(tcpEndPoint, connectionName));
        }

        public static IEventStoreConnection Create(ConnectionSettings settings, IPEndPoint tcpEndPoint, string connectionName = null)
        {
            return new EventStoreConnectionProfiler(EventStoreConnection.Create(settings, tcpEndPoint, connectionName));
        }

        public static IEventStoreConnection Create(ConnectionSettings connectionSettings, ClusterSettings clusterSettings, string connectionName = null)
        {
            return new EventStoreConnectionProfiler(EventStoreConnection.Create(connectionSettings, clusterSettings, connectionName));
        }
    }
}
