using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoClone.Business.Abstract;
using VideoClone.Entities.DTOs;

namespace VideoClone.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaylistController : ControllerBase
{
    private readonly IPlaylistService _playlistService;
    
    public PlaylistController(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult Add([FromBody] PlaylistCreateUpdateDto playlistCreateUpdateDto)
    {
        var result = _playlistService.Add(playlistCreateUpdateDto);
        
        return result.Success
            ? Ok(result.Message)
            : BadRequest(result.Message);
    }
}