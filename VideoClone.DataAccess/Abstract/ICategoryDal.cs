using VideoClone.Core.DataAccess;
using VideoClone.Entities.Concrete;

namespace VideoClone.DataAccess.Abstract;

public interface ICategoryDal : IEntityRepository<Category>
{
}