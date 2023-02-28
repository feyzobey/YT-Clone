using VideoClone.Core.DataAccess;
using VideoClone.Core.Entities.Concrete;

namespace VideoClone.DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}