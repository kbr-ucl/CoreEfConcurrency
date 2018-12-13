using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreEfConcurrency.Model
{
	public class BloggingContext : DbContext
	{
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.;Database=MyCMS;Trusted_Connection=True;");
		}
	}

	public class Blog
	{
		public int BlogId { get; set; }
		public string Url { get; set; }

		public ICollection<Post> Posts { get; set; }
	}

	public class Post
	{
		public int PostId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public int BlogId { get; set; }
		public Blog Blog { get; set; }
	}
}