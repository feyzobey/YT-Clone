using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class PlaylistDeleteVideoDto: IDto
{
    public Guid VideoId { get; set; }
}