using VideoClone.Core.DataAccess.EntityFramework;
using VideoClone.DataAccess.Abstract;
using VideoClone.Entities.Concrete;

namespace VideoClone.DataAccess.Concrete.EntityFramework;

public class EfChannelDal : EfEntityRepositoryBase<Channel, VideoCloneContext>, IChannelDal
{
    public EfChannelDal(VideoCloneContext context) : base(context)
    {
        
    }
}