using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class PlaylistAddVideoDto : IDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid ChannelId { get; set; }
    public Guid VideoId { get; set; }
}