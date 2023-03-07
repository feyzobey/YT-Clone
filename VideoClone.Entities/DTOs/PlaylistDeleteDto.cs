using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class PlaylistDeleteDto : IDto
{
    public string Name { get; set; }
    public Guid VideoId { get; set; }
}
