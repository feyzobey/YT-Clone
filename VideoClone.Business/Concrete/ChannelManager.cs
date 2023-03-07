using VideoClone.Business.Abstract;
using VideoClone.Core.Utilities.Results;
using VideoClone.DataAccess.Abstract;
using VideoClone.Entities.Concrete;
using VideoClone.Entities.DTOs;

namespace VideoClone.Business.Concrete;

public class ChannelManager : IChannelService
{
    private readonly IChannelDal _channelDal;

    public ChannelManager(IChannelDal channelDal)
    {
        _channelDal = channelDal;
    }

    public IDataResult<IList<Channel>> GetList()
    {
        var channels = _channelDal.GetList();
        return new SuccessDataResult<IList<Channel>>(channels);
    }

    public Channel GetById(Guid id)
    {
        return _channelDal.Get(c => c.Id == id);
    }
    
    public IResult Add(ChannelDto channelDto)
    {
        var channel = new Channel
        {
            Name = channelDto.Name,
            Verified = false,
        };

        if (!_channelDal.Add(channel)) return new ErrorResult("Channel cannot created!");

        return new SuccessResult("Channel created.");
    }

    public IResult Update(Guid id, string name)
    {
        var channel = GetById(id);

        if (channel == null) return new ErrorResult("Channel cannot found!");

        channel.Name = name;

        return _channelDal.Update(channel)
            ? new SuccessResult("Channel updated.")
            : new ErrorResult("Channel cannot updated!");
    }

    public IResult Delete(Guid id)
    {
        var channel = GetById(id);

        if (channel == null) return new ErrorResult("Channel cannot found!");

        return _channelDal.Delete(channel)
            ? new SuccessResult("Channel deleted.")
            : new ErrorResult("Channel cannot deleted!");
    }
}