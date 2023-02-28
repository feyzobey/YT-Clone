using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class ChannelUpdateDto : IDto
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string ImagePath { get; set; }
}