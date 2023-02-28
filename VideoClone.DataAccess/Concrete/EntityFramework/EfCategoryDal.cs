using VideoClone.Core.DataAccess.EntityFramework;
using VideoClone.DataAccess.Abstract;
using VideoClone.Entities.Concrete;

namespace VideoClone.DataAccess.Concrete.EntityFramework;

public class EfCategoryDal : EfEntityRepositoryBase<Category, VideoCloneContext>, ICategoryDal
{
    public EfCategoryDal(VideoCloneContext context) : base(context)
    {
    }
}