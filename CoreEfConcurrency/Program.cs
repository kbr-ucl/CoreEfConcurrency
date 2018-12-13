using System;
using CoreEfConcurrency.Model;

namespace CoreEfConcurrency
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new BloggingContext())
			{

			}
				Console.WriteLine("Hello World!");
		}
	}
}
