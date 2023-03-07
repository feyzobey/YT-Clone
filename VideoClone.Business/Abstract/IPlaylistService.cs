using VideoClone.Core.Utilities.Results;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Abstract;

public interface IPlaylistService
{
    //IDataResult<IList<Video>> GetPlaylistVideos();
    IResult Add(PlaylistCreateUpdateDto playlistCreateUpdateDto);
}