using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class CategoryCreateUpdateDto : IDto
{
    public string Name { get; set; }
}