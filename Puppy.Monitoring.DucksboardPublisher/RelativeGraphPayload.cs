﻿using Puppy.Monitoring.Events;

namespace Puppy.Monitoring.DucksboardPublisher
{
    internal class RelativeGraphPayload : IDucksboardPayload
    {
        public string GeneratePayload(IEvent @event)
        {
            return string.Format("[{{\"timestamp\":{0}, \"value\":{1}}}]", @event.EventAudit.Buckets.UnixTimestamp, @event.Timings.Took);
        }
    }
}