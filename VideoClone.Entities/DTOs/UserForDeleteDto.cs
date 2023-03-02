using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class UserForDeleteDto:IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}