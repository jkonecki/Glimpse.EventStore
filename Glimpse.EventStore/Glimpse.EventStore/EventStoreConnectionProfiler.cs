using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Message;

namespace Glimpse.EventStore
{
    class EventStoreConnectionProfiler : IEventStoreConnection
    {
        internal static IInspectorContext InspectorContext;

        private readonly IEventStoreConnection Connection;

        public EventStoreConnectionProfiler(IEventStoreConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            this.Connection = connection;
        }

        public string ConnectionName
        {
            get { return this.Connection.ConnectionName; }
        }

        public ClusterSettings ClusterSettings
        {
            get { return this.Connection.ClusterSettings; }
        }

        public ConnectionSettings Settings
        {
            get { return this.Connection.Settings; }
        }

        public Task<WriteResult> AppendToStreamAsync(string stream, int expectedVersion, IEnumerable<EventData> events, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "AppendToStreamAsync",
                () => this.Connection.AppendToStreamAsync(stream, expectedVersion, events, userCredentials),
                new { stream, expectedVersion, events, userCredentials }
            );
        }

        public Task<WriteResult> AppendToStreamAsync(string stream, int expectedVersion, UserCredentials userCredentials, params EventData[] events)
        {
            return this.ProfileActivity(
                "AppendToStreamAsync",
                () => this.Connection.AppendToStreamAsync(stream, expectedVersion, userCredentials, events),
                new { stream, expectedVersion, userCredentials, events }
            );
        }

        public Task<WriteResult> AppendToStreamAsync(string stream, int expectedVersion, params EventData[] events)
        {
            return this.ProfileActivity(
                "AppendToStreamAsync",
                () => this.Connection.AppendToStreamAsync(stream, expectedVersion, events),
                new { stream, expectedVersion, events }
            );
        }

        public void Close()
        {
            this.ProfileActivity(
                "Close", 
                () => this.Connection.Close()
            );
        }

        public Task ConnectAsync()
        {
            return this.ProfileActivity(
                "Connect",
                () => this.Connection.ConnectAsync())
            ;
        }

        public EventStoreTransaction ContinueTransaction(long transactionId, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "ContinueTransaction",
                () => this.Connection.ContinueTransaction(transactionId, userCredentials),
                new { transactionId, userCredentials }
            );
        }

        public Task<DeleteResult> DeleteStreamAsync(string stream, int expectedVersion, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "DeleteStreamAsync",
                () => this.Connection.DeleteStreamAsync(stream, expectedVersion, userCredentials),
                new { stream, expectedVersion, userCredentials }
            );
        }

        public Task<DeleteResult> DeleteStreamAsync(string stream, int expectedVersion, bool hardDelete, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "DeleteStreamAsync",
                () => this.Connection.DeleteStreamAsync(stream, expectedVersion, hardDelete, userCredentials),
                new { stream, expectedVersion, hardDelete, userCredentials }
            );
        }

        public Task<RawStreamMetadataResult> GetStreamMetadataAsRawBytesAsync(string stream, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "GetStreamMetadataAsRawBytesAsync",
                () => this.Connection.GetStreamMetadataAsRawBytesAsync(stream, userCredentials),
                new { stream, userCredentials }
            );
        }

        public Task<StreamMetadataResult> GetStreamMetadataAsync(string stream, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "GetStreamMetadataAsync",
                () => this.Connection.GetStreamMetadataAsync(stream, userCredentials),
                new { stream, userCredentials }
            );
        }

        public Task<AllEventsSlice> ReadAllEventsBackwardAsync(Position position, int maxCount, bool resolveLinkTos, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "ReadAllEventsBackwardAsync",
                () => this.Connection.ReadAllEventsBackwardAsync(position, maxCount, resolveLinkTos, userCredentials),
                new { position, maxCount, resolveLinkTos, userCredentials }
            );
        }

        public Task<AllEventsSlice> ReadAllEventsForwardAsync(Position position, int maxCount, bool resolveLinkTos, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "ReadAllEventsForwardAsync",
                () => this.Connection.ReadAllEventsForwardAsync(position, maxCount, resolveLinkTos, userCredentials),
                new { position, maxCount, resolveLinkTos, userCredentials }
            );
        }

        public Task<EventReadResult> ReadEventAsync(string stream, int eventNumber, bool resolveLinkTos, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "ReadEventAsync",
                () => this.Connection.ReadEventAsync(stream, eventNumber, resolveLinkTos, userCredentials),
                new { stream, eventNumber, resolveLinkTos, userCredentials }
            );
        }

        public Task<StreamEventsSlice> ReadStreamEventsBackwardAsync(string stream, int start, int count, bool resolveLinkTos, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "ReadStreamEventsBackwardAsync",
                () => this.Connection.ReadStreamEventsBackwardAsync(stream, start, count, resolveLinkTos, userCredentials),
                new { stream, start, count, resolveLinkTos, userCredentials }
            );
        }

        public Task<StreamEventsSlice> ReadStreamEventsForwardAsync(string stream, int start, int count, bool resolveLinkTos, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "ReadStreamEventsForwardAsync",
                () => this.Connection.ReadStreamEventsForwardAsync(stream, start, count, resolveLinkTos, userCredentials),
                new { stream, start, count, resolveLinkTos, userCredentials }
            );
        }

        public Task<WriteResult> SetStreamMetadataAsync(string stream, int expectedMetastreamVersion, byte[] metadata, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "SetStreamMetadataAsync",
                () => this.Connection.SetStreamMetadataAsync(stream, expectedMetastreamVersion, metadata, userCredentials),
                new { stream, expectedMetastreamVersion, metadata, userCredentials }
            );
        }

        public Task<WriteResult> SetStreamMetadataAsync(string stream, int expectedMetastreamVersion, StreamMetadata metadata, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "SetStreamMetadataAsync",
                () => this.Connection.SetStreamMetadataAsync(stream, expectedMetastreamVersion, metadata, userCredentials),
                new { stream, expectedMetastreamVersion, metadata, userCredentials }
            );
        }

        public Task SetSystemSettingsAsync(SystemSettings settings, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "SetSystemSettingsAsync",
                () => this.Connection.SetSystemSettingsAsync(settings, userCredentials),
                new { settings, userCredentials }
            );
        }

        public Task<EventStoreTransaction> StartTransactionAsync(string stream, int expectedVersion, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "StartTransactionAsync",
                () => this.Connection.StartTransactionAsync(stream, expectedVersion, userCredentials),
                new { stream, expectedVersion, userCredentials }
            );
        }

        public Task<EventStoreSubscription> SubscribeToAllAsync(bool resolveLinkTos, Action<EventStoreSubscription, ResolvedEvent> eventAppeared, Action<EventStoreSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "SubscribeToAllAsync",
                () => this.Connection.SubscribeToAllAsync(resolveLinkTos, eventAppeared, subscriptionDropped, userCredentials),
                new { resolveLinkTos, eventAppeared, subscriptionDropped, userCredentials }
            );
        }

        public EventStoreAllCatchUpSubscription SubscribeToAllFrom(Position? lastCheckpoint, bool resolveLinkTos, Action<EventStoreCatchUpSubscription, ResolvedEvent> eventAppeared, Action<EventStoreCatchUpSubscription> liveProcessingStarted = null, Action<EventStoreCatchUpSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null, UserCredentials userCredentials = null, int readBatchSize = 500)
        {
            return this.ProfileActivity(
                "SubscribeToAllFrom",
                () => this.Connection.SubscribeToAllFrom(lastCheckpoint, resolveLinkTos, eventAppeared, liveProcessingStarted, subscriptionDropped, userCredentials, readBatchSize),
                new { lastCheckpoint, resolveLinkTos, eventAppeared, liveProcessingStarted, subscriptionDropped, userCredentials, readBatchSize }
            );
        }

        public Task<EventStoreSubscription> SubscribeToStreamAsync(string stream, bool resolveLinkTos, Action<EventStoreSubscription, ResolvedEvent> eventAppeared, Action<EventStoreSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null, UserCredentials userCredentials = null)
        {
            return this.ProfileActivity(
                "SubscribeToStreamAsync",
                () => this.Connection.SubscribeToStreamAsync(stream, resolveLinkTos, eventAppeared, subscriptionDropped, userCredentials),
                new { stream, resolveLinkTos, eventAppeared, subscriptionDropped, userCredentials }
            );
        }

        public EventStoreStreamCatchUpSubscription SubscribeToStreamFrom(string stream, int? lastCheckpoint, bool resolveLinkTos, Action<EventStoreCatchUpSubscription, ResolvedEvent> eventAppeared, Action<EventStoreCatchUpSubscription> liveProcessingStarted = null, Action<EventStoreCatchUpSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null, UserCredentials userCredentials = null, int readBatchSize = 500)
        {
            return this.ProfileActivity(
                "SubscribeToStreamFrom",
                () => this.Connection.SubscribeToStreamFrom(stream, lastCheckpoint, resolveLinkTos, eventAppeared, liveProcessingStarted, subscriptionDropped, userCredentials, readBatchSize),
                new { stream, lastCheckpoint, resolveLinkTos, eventAppeared, liveProcessingStarted, subscriptionDropped, userCredentials, readBatchSize }
            );
        }

        public event EventHandler<ClientAuthenticationFailedEventArgs> AuthenticationFailed
        {
            add { this.Connection.AuthenticationFailed += value; }
            remove { this.Connection.AuthenticationFailed -= value; }
        }

        public event EventHandler<ClientClosedEventArgs> Closed
        {
            add { this.Connection.Closed += value; }
            remove { this.Connection.Closed -= value; }
        }

        public event EventHandler<ClientConnectionEventArgs> Connected
        {
            add { this.Connection.Connected += value; }
            remove { this.Connection.Connected -= value; }
        }

        public event EventHandler<ClientConnectionEventArgs> Disconnected
        {
            add { this.Connection.Disconnected += value; }
            remove { this.Connection.Disconnected -= value; }
        }

        public event EventHandler<ClientErrorEventArgs> ErrorOccurred
        {
            add { this.Connection.ErrorOccurred += value; }
            remove { this.Connection.ErrorOccurred -= value; }
        }

        public event EventHandler<ClientReconnectingEventArgs> Reconnecting
        {
            add { this.Connection.Reconnecting += value; }
            remove { this.Connection.Reconnecting -= value; }
        }

        public void Dispose()
        {
            this.ProfileActivity(
                "Dispose",
                () => this.Connection.Dispose()
            );
        }

        #region Profiling implementation

        private static bool ProfilingEnabled
        {
            get { return InspectorContext != null && InspectorContext.RuntimePolicyStrategy() != RuntimePolicy.Off; }
        }

        private void ProfileActivity(string activityName, Action activity, object arguments = null)
        {
            if (ProfilingEnabled)
                this.ProfileActivity<object>(activityName, () => { activity(); return null; }, arguments);
            else
                activity();
        }

        private T ProfileActivity<T>(string activityName, Func<T> activity, object arguments = null)
        {
            if (!ProfilingEnabled)
                return activity();

            var startTime = DateTime.UtcNow;
            var stopwatch = Stopwatch.StartNew();
            var result = activity();
            stopwatch.Stop();

            var message = new Messages.ConnectionActivity 
            { 
                ConnectionName = this.Connection.ConnectionName,
                Name = activityName, 
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
                Arguments = arguments,
                Results = result
            };

            InspectorContext.MessageBroker.Publish(message);

            Timeline(activityName, new TimerResult
            {
                StartTime = startTime,
                Offset = startTime.Subtract(InspectorContext.TimerStrategy().RequestStart.ToUniversalTime()),
                Duration = stopwatch.Elapsed
            });

            return result;
        }

        private Task ProfileActivity(string activityName, Func<Task> activity, object arguments = null)
        {
            if (!ProfilingEnabled)
                return activity();

            var startTime = DateTime.UtcNow;
            Stopwatch stopwatch = null;

            return Task.Factory.StartNew(() =>
            {
                startTime = DateTime.UtcNow;
                stopwatch = Stopwatch.StartNew();
            }).ContinueWith(
                _ => activity()
            ).ContinueWith(task =>
            {
                stopwatch.Stop();

                var message = new Messages.ConnectionActivity
                {
                    ConnectionName = this.Connection.ConnectionName,
                    Name = activityName,
                    ElapsedMilliseconds = stopwatch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L * 1000L)),
                    Arguments = arguments,
                    //Results = task.Result
                };

                InspectorContext.MessageBroker.Publish(message);

                Timeline(activityName, new TimerResult
                {
                    StartTime = startTime,
                    Offset = startTime.Subtract(InspectorContext.TimerStrategy().RequestStart.ToUniversalTime()),
                    Duration = stopwatch.Elapsed
                });

                return task;
            });
        }

        private void ProfileEvent<E>(string eventName, object sender, E args)
            where E : EventArgs
        {
            if (!ProfilingEnabled)
                return;

            var message = new Messages.ConnectionActivity
            {
                ConnectionName = this.Connection.ConnectionName,
                Name = eventName,
                ElapsedMilliseconds = 1,
                Arguments = args
            };

            InspectorContext.MessageBroker.Publish(message);

            var startTime = DateTime.UtcNow;

            Timeline(eventName, new TimerResult
            {
                StartTime = startTime,
                Offset = startTime.Subtract(InspectorContext.TimerStrategy().RequestStart.ToUniversalTime()),
                Duration = TimeSpan.FromMilliseconds(1)
            });

        }

        private static void Timeline(string message, TimerResult timer)
        {
            if (!ProfilingEnabled) 
                return;

            InspectorContext.MessageBroker.Publish(
                new Messages.ConnectionActivityTimeline()
                    .AsTimelineMessage(message, Messages.ConnectionActivityTimeline.TimelineCategory)
                    .AsTimedMessage(timer));
        }

        #endregion
    }
}
