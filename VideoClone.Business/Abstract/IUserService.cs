using VideoClone.Core.Entities.Concrete;
using VideoClone.Core.Utilities.Results;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Abstract;

public interface IUserService
{
    User GetById(Guid id);
    User GetByEmail(string email);
    IResult Add(User user);
    List<OperationClaim> GetClaims(User user);
    IResult ChangePassword(Guid userId, ChangePasswordDto changePasswordDto);
}