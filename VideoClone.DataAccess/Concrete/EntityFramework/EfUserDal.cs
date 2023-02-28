using VideoClone.Core.DataAccess.EntityFramework;
using VideoClone.Core.Entities.Concrete;
using VideoClone.DataAccess.Abstract;

namespace VideoClone.DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, VideoCloneContext>, IUserDal
{
    public EfUserDal(VideoCloneContext context) : base(context)
    {
    }

    public List<OperationClaim> GetClaims(User user)
    {
        var result = from operationClaim in Context.OperationClaims
            join userOperationClaim in Context.UserOperationClaims
                on operationClaim.Id equals userOperationClaim.OperationClaimId
            where userOperationClaim.UserId == user.Id
            select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
        return result.ToList();
    }
}