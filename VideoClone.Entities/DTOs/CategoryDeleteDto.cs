using VideoClone.Core.Entities;
using VideoClone.Entities.Concrete;

namespace VideoClone.Entities.DTOs;

public class CategoryDeleteDto : IDto
{
    public string Name { get; set; }
}