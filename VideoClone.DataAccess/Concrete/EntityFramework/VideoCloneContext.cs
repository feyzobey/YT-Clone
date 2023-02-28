using Microsoft.EntityFrameworkCore;
using VideoClone.Core.Entities.Concrete;
using VideoClone.Entities.Concrete;

namespace VideoClone.DataAccess.Concrete.EntityFramework;

public class VideoCloneContext : DbContext
{
    public VideoCloneContext(DbContextOptions<VideoCloneContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Feeling> Feelings { get; set; }
    public DbSet<History> History { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<PlaylistVideo> PlaylistVideo { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Video> Videos { get; set; }
}