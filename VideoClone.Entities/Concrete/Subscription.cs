using System.ComponentModel.DataAnnotations.Schema;
using VideoClone.Core.Entities;

namespace VideoClone.Entities.Concrete;

public class Subscription : EntityBase
{
    [ForeignKey("Subscriber")] public Guid SubscriberId { get; set; } // Subscriber channel id

    public virtual Channel Subscriber { get; set; }

    [ForeignKey("Channel")] public Guid ChannelId { get; set; }

    public virtual Channel Channel { get; set; }

    public bool Notification { get; set; }
}