using HCID_HM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HCID_HM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<FavoritesList> FavoritesLists { get; set; }
        public virtual DbSet<TopicInFavoritesList> TopicInFavoritesLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TopicInFavoritesList>().HasKey(c => new { c.TopicId, c.FavoritesListId });
        }
    }
}
