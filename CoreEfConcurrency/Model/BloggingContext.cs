using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreEfConcurrency.Model
{
	public class BloggingContext : DbContext
	{
		private readonly string _connectionString = @"Server=.;Database=MyCMS;Trusted_Connection=True;";

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Blog>().HasData(new Blog {Id = 1, Url = "http://sample.com"});
			modelBuilder.Entity<Post>().HasData(
				new Post {BlogId = 1, Id = 1, Title = "First post", Content = "Test 1"});
			modelBuilder.Entity<Post>().HasData(
				new {BlogId = 1, Id = 2, Title = "Second post", Content = "Test 2"});
		}
	}

	public class Blog
	{
		public int Id { get; set; }
		public string Url { get; set; }

		public ICollection<Post> Posts { get; set; }
	}

	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public int BlogId { get; set; }
		public Blog Blog { get; set; }
	}
}