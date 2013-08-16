using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Puppy.Monitoring.Events;
using Puppy.Monitoring.Publishing;

namespace Puppy.Monitoring.NewRelicPublisher
{
    public class NewRelicPublisher : IPublishEvents
    {
        private static readonly ILog log = LogManager.GetLogger<NewRelicPublisher>();
        private readonly IDictionary<Func<IEvent, bool>, IPublishEvents> factory = new Dictionary<Func<IEvent, bool>, IPublishEvents>()
            {
                {@event => @event.Timings.Took == int.MinValue, new NewRelicCounterPublisher()},
                {@event => @event.GetType() == typeof(FailureEvent), new NewRelicErrorPublisher()},
                {@event => @event.Timings.Took != int.MinValue, new NewRelicResponseTimePublisher()},
            };

        public void Publish(IEvent @event)
        {
            var publisher = factory.FirstOrDefault(f => f.Key(@event));
            if (publisher.Value == null)
            {
                log.DebugFormat("Failed to get a New Relic publisher for {0}", @event);
                return;
            }

            publisher.Value.Publish(@event);
        }
    }
}