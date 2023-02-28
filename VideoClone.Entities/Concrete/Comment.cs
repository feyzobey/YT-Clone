using System.ComponentModel.DataAnnotations.Schema;
using VideoClone.Core.Entities;

namespace VideoClone.Entities.Concrete;

public class Comment : EntityBase
{
    [ForeignKey("Video")] public Guid VideoId { get; set; }

    public virtual Video Video { get; set; }

    [ForeignKey("Channel")] public Guid ChannelId { get; set; }

    public virtual Channel Channel { get; set; }

    public string Text { get; set; }
}