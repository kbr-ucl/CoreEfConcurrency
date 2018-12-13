﻿using System.Data.SqlClient;
using System.Linq;
using CoreEfConcurrency.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CoreEfConcurrencyTests
{
	public class BloggingContextTests
	{
		[Fact]
		public void Concurrency_Db_Update_Exception()
		{
			// Arrange
			using (var sut = new BloggingContext())
			{
				var post = sut.Posts.FirstOrDefault(a => a.Id == 1);
				post.Title += " 1";

				// Act

				using (var context = new BloggingContext())
				{
					var post2 = context.Posts.FirstOrDefault(a => a.Id == 1);
					post2.Title += " 1";
					context.SaveChanges();
				}

				// Assert
				Assert.Throws<DbUpdateConcurrencyException>(() => sut.SaveChanges());
			}
		}

		[Fact]
		public void Concurrency_Db_Update_External_Exception()
		{
			// Arrange
			using (var sut = new BloggingContext())
			{
				var post = sut.Posts.FirstOrDefault(a => a.Id == 1);
				post.Title += " 1";

				// Act
				using (var con = new SqlConnection(BloggingContext.ConnectionString))
				{
					con.Open();
					using (var command = new SqlCommand("UPDATE Posts SET Title = 1234  WHERE Id = 1", con))
					{
						command.ExecuteNonQuery();
					}
				}

				// Assert
				Assert.Throws<DbUpdateConcurrencyException>(() => sut.SaveChanges());
			}
		}

		[Fact]
		public void No_Concurrency_Db_Update()
		{
			// Arrange
			var expected = 1;
			using (var sut = new BloggingContext())
			{
				var post = sut.Posts.FirstOrDefault(a => a.Id == 1);
				post.Title += " 1";

				// Act
				var actual = sut.SaveChanges();

				// Assert
				Assert.Equal(expected, actual);
			}
		}

		[Fact]
		public void No_Concurrency_Db_Works()
		{
			// Arrange
			using (var sut = new BloggingContext())
			{
				// Act
				var post = sut.Posts.FirstOrDefault(a => a.Id == 1);

				// Assert
				Assert.NotNull(post);
			}
		}
	}
}