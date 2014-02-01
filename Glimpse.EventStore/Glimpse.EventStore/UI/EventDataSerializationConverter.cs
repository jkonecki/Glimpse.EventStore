using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using EventStore.ClientAPI;
using Glimpse.Core.Extensibility;

namespace Glimpse.EventStore.UI
{
    class EventDataSerializationConverter : SerializationConverter<EventData>
    {
        public override object Convert(EventData obj)
        {
            var data = Encoding.UTF8.GetString(obj.Data);
            var metadata = Encoding.UTF8.GetString(obj.Metadata);

            var serializer = new JavaScriptSerializer();

            return new
            {
                Data = obj.IsJson ? serializer.DeserializeObject(data) : data,
                obj.EventId,
                obj.IsJson,
                Metadata = obj.IsJson ? serializer.DeserializeObject(metadata) : metadata,
                obj.Type
            };
        }
    }
}
