using VideoClone.Core.Entities;

namespace VideoClone.Entities.DTOs;

public class ChangePasswordDto : IDto
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}