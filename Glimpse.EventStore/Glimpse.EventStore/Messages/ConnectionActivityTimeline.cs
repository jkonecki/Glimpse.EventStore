using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glimpse.Core.Message;

namespace Glimpse.EventStore.Messages
{
    public class ConnectionActivityTimeline : MessageBase, ITimelineMessage
    {
        internal static TimelineCategoryItem TimelineCategory = new TimelineCategoryItem("EventStore", "#5a8a00", "#6ba300");

        public TimelineCategoryItem EventCategory { get; set; }

        public string EventName { get; set; }

        public string EventSubText { get; set; }

        public TimeSpan Duration { get; set; }

        public TimeSpan Offset { get; set; }

        public DateTime StartTime { get; set; }
    }}
