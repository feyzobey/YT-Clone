using VideoClone.Core.DataAccess.EntityFramework;
using VideoClone.DataAccess.Abstract;
using VideoClone.Entities.Concrete;

namespace VideoClone.DataAccess.Concrete.EntityFramework;

public class EfPlaylistDal:EfEntityRepositoryBase<Playlist, VideoCloneContext>, IPlaylistDal
{
    public EfPlaylistDal(VideoCloneContext context) : base(context)
    {
    }
}