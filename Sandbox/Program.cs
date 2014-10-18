using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DragonQuiz;

namespace Sandbox
{
	class Program
	{
		static void Main(string[] args) 
		{
			using (var db = new ServerDbContext()) 
			{ 
				// Create and save a new Question
				// db.Questions.Add(new DQuestion(0, "Sample?", "Sample!", "", "common")); 
				// db.SaveChanges(); 
 
				// Display all Blogs from the database 
				var query = from b in db.Questions
							orderby b.Content
							select b; 
 
				Console.WriteLine("All questions in the database:"); 
				foreach (var item in query) 
				{ 
					Console.WriteLine(String.Format("ID: {0}\n\tQ: {1}\n\tA: {2}\n\tComment: {3}\n\tTags: \n",
						item.Id, item.Content, item.Answer, item.Comment, item.Tags)); 
				} 
 
				Console.WriteLine("Press any key to exit..."); 
				Console.ReadKey(); 
			} 
		}
	}
}
