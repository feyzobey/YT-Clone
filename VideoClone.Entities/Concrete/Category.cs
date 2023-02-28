using VideoClone.Core.Entities;

namespace VideoClone.Entities.Concrete;

public class Category : EntityBase
{
    public string Name { get; set; }
    public virtual ICollection<Video> Videos { get; set; }
}