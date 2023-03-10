using System.ComponentModel.DataAnnotations.Schema;
using VideoClone.Core.Entities;

namespace VideoClone.Entities.Concrete;

public enum Emotion
{
    Like,
    Dislike
}

public class Feeling : EntityBase
{
    [ForeignKey("Video")] public Guid VideoId { get; set; }

    public virtual Video Video { get; set; }

    [ForeignKey("Channel")] public Guid ChannelId { get; set; }

    public virtual Channel Channel { get; set; }

    public Emotion Emotion { get; set; }
}