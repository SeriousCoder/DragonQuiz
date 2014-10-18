using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DragonQuiz;
using Newtonsoft.Json;

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
 
				// Display all DQuestions from the database 
				/* var query = from b in db.Questions
							orderby b.Content
							select b; 
 
				Console.WriteLine("All questions in the database:"); 
				foreach (var item in query) 
				{ 
					Console.WriteLine(String.Format("ID: {0}\n\tQ: {1}\n\tA: {2}\n\tComment: {3}\n\tTags: \n",
						item.Id, item.Content, item.Answer, item.Comment, item.Tags)); 
				} */

				 /*DQuestion question = new DQuestion(0, "Sample?", "Sample!", "", "common");
				

				var list = new List<DQuestion>() {
					new DQuestion(0, "Sample?", "Sample!", "", "common"),
					new DQuestion(1, "Sample 2?", "Sample 2, ORLY!", "", "common")
				};

				string s = JsonConvert.SerializeObject(list);
				Console.WriteLine(s + "\n");

				var newList = JsonConvert.DeserializeObject<List<DQuestion>>(s); */

				// kick server
				var list = DatabaseIO.GetPack(new DRequest(5, "FirstTag"));

				if (list == null)
				{
					Console.WriteLine("Null response.");
					Console.ReadKey();
					return;
				}

				try
				{
					foreach (var item in list)
					{
						Console.WriteLine(String.Format("ID: {0}\n\tQ: {1}\n\tA: {2}\n\tComment: {3}\n\tTags: \n",
							item.Id, item.Content, item.Answer, item.Comment, item.Tags));
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
 
				Console.WriteLine("Press any key to exit..."); 
				Console.ReadKey(); 
			} 
		}
	}
}
