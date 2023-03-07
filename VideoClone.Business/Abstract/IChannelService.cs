using VideoClone.Core.Utilities.Results;
using VideoClone.Entities.Concrete;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Abstract;

public interface IChannelService
{
    IDataResult<IList<Channel>> GetList();
    Channel GetById(Guid id);
    IResult Add(ChannelDto channelDto);
    IResult Update(Guid id, string name);
    IResult Delete(Guid id);
}