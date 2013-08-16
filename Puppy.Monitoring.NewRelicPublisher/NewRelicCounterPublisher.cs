using Puppy.Monitoring.Events;
using Puppy.Monitoring.Publishing;

namespace Puppy.Monitoring.NewRelicPublisher
{
    internal static class NewRelicMetricName
    {
        public static string Create(IEvent @event)
        {
            return string.Format("{0}/{1}", @event.Categorisation.Category, @event.Categorisation.SubCategory);
        }
    }

    internal class NewRelicCounterPublisher : IPublishEvents
    {
        public void Publish(IEvent @event)
        {
            NewRelic.Api.Agent.NewRelic.IncrementCounter(NewRelicMetricName.Create(@event));
        }
    }

    internal class NewRelicResponseTimePublisher : IPublishEvents
    {
        public void Publish(IEvent @event)
        {
            NewRelic.Api.Agent.NewRelic.RecordResponseTimeMetric(NewRelicMetricName.Create(@event), @event.Timings.Took);
        }
    }

    internal class NewRelicErrorPublisher : IPublishEvents
    {
        public void Publish(IEvent @event)
        {
            NewRelic.Api.Agent.NewRelic.NoticeError(NewRelicMetricName.Create(@event));
        }
    }
}