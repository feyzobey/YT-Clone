using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class CurrentUserDto : DtoBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}