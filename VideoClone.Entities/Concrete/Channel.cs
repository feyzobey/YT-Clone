using System.ComponentModel.DataAnnotations.Schema;
using VideoClone.Core.Entities;
using VideoClone.Core.Entities.Concrete;

namespace VideoClone.Entities.Concrete;

public class Channel : EntityBase
{
    [ForeignKey("User")] public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public string Name { get; set; }
    public bool Verified { get; set; }

    public ICollection<Video> Videos { get; set; }
}