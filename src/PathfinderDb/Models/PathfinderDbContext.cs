using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace PathfinderDb.Models
{
    public sealed class PathfinderDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets traits documents.
        /// </summary>
        public DbSet<TraitDocument> TraitDocs { get; set; }

        public DbSet<Document> Docs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TraitDocument>().Key(a => a.Id);
            builder.Entity<Document>().Key(a => a.Id);

            base.OnModelCreating(builder);
        }
    }
}
