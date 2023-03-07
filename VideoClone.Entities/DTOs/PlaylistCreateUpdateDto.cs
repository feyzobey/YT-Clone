using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class PlaylistCreateUpdateDto : IDto
{
    public string Name { get; set; }
    public Guid ChannelId { get; set; }
    public string Description { get; set; }
}