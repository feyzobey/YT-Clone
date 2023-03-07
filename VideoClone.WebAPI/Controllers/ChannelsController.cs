using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoClone.Business.Abstract;
using VideoClone.Entities.DTOs;

namespace VideoClone.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChannelsController : ControllerBase 
{
    private readonly IChannelService _channelService;

    public ChannelsController(IChannelService channelService)
    {
        _channelService = channelService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var result = _channelService.GetList();

        return result.Success
            ? Ok(result.Data)
            : BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var channel = _channelService.GetById(id);

        return channel != null
            ? Ok(channel)
            : NotFound();
    }

    [HttpPost]
    [Authorize]
    public IActionResult Add([FromBody] ChannelDto channelDto)
    {
        var result = _channelService.Add(channelDto);

        return result.Success
            ? Ok(result.Message)
            : BadRequest(result.Message);
    }

    [HttpPut("{id}/{name}")]
    [Authorize]
    public IActionResult Update(Guid id, string name)
    {
        var result = _channelService.Update(id, name);

        return result.Success
            ? Ok(result.Message)
            : BadRequest(result.Message);
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(Guid id)
    {
        var result = _channelService.Delete(id);
        
        return result.Success
            ? Ok(result.Message)
            : BadRequest(result.Message);
    }
}