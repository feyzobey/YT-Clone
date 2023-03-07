using Autofac;
using VideoClone.Business.Abstract;
using VideoClone.Business.Concrete;
using VideoClone.Core.Utilities.Security.Jwt;
using VideoClone.DataAccess.Abstract;
using VideoClone.DataAccess.Concrete.EntityFramework;

namespace VideoClone.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ChannelManager>().As<IChannelService>();
        builder.RegisterType<EfChannelDal>().As<IChannelDal>();

        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();

        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        builder.RegisterType<PlaylistManager>().As<IPlaylistService>();
        builder.RegisterType<EfPlaylistDal>().As<IPlaylistDal>();
    }
}