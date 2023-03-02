using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class ChannelDeleteDto : IDto
{
    public string Name { get; set; }
    public Guid UserId { get; set; }
}