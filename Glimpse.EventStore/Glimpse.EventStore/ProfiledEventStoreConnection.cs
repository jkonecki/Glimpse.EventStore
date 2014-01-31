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
        internal static IInspectorContext InspectorContext;

        public static bool ProfilingEnabled 
        {
            get { return InspectorContext != null && InspectorContext.RuntimePolicyStrategy() != RuntimePolicy.Off; }
        }

        public static IEventStoreConnection Create(IPEndPoint tcpEndPoint, string connectionName = null)
        {
            return Profile(EventStoreConnection.Create(tcpEndPoint, connectionName));
        }

        public static IEventStoreConnection Create(ConnectionSettings settings, IPEndPoint tcpEndPoint, string connectionName = null)
        {
            return Profile(EventStoreConnection.Create(settings, tcpEndPoint, connectionName));
        }

        public static IEventStoreConnection Create(ConnectionSettings connectionSettings, ClusterSettings clusterSettings, string connectionName = null)
        {
            return Profile(EventStoreConnection.Create(connectionSettings, clusterSettings, connectionName));
        }

        private static IEventStoreConnection Profile(IEventStoreConnection connection)
        {
            return ProfilingEnabled
                ? new EventStoreConnectionProfiler(connection)
                : connection;
        }
    }
}
