
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using wmj.userManagerServer.Domain.Models;

namespace wmj.userManagerServer.Domain.Maps
{
    public class AppUserMaps : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
        }
    }
}
