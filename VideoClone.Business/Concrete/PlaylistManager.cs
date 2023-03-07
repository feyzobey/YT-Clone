using VideoClone.Business.Abstract;
using VideoClone.Core.Utilities.Results;
using VideoClone.DataAccess.Abstract;
using VideoClone.Entities.Concrete;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Concrete;

public class PlaylistManager : IPlaylistService
{
    private readonly IPlaylistDal _playlistDal;

    public PlaylistManager(IPlaylistDal playlistDal)
    {
        _playlistDal = playlistDal;
    }

    public IResult Add(PlaylistCreateUpdateDto playlistCreateUpdateDto)
    {
        var playlist = new Playlist
        {
            Name = playlistCreateUpdateDto.Name,
            ChannelId = playlistCreateUpdateDto.ChannelId,
            Description = playlistCreateUpdateDto.Description
        };

        if (!_playlistDal.Add(playlist)) return new ErrorResult("Playlist cannot created!");

        return new SuccessResult("Playlist created.");
    }
}