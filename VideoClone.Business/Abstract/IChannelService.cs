using VideoClone.Core.Utilities.Results;
using VideoClone.Entities.Concrete;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Abstract;

public interface IChannelService
{
    IDataResult<IList<Channel>> GetList();
    Channel GetById(Guid channelId);
    Channel GetBySlug(string slug);
    IResult Add(ChannelDto channelDto);
    IResult Update(Guid id, ChannelUpdateDto channelUpdateDto);
}