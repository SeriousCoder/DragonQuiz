using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace DragonQuiz.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public string Get()
		{
			using (var db = new DragonQuiz.ServerDbContext())
			{
				// Display all Blogs from the database 
				var query = from b in db.Questions
							orderby b.Content
							select b;

				return JsonConvert.SerializeObject(query.ToArray<DQuestion>());
			}
			
			/* return new List<DQuestion>() {
				new DQuestion(0, "Epic win?", "Epic win!", "", "common")
			}; */
		}

		// GET api/values/5
		public DQuestion[] Get(int qNum, string tags)
		{
			using (var db = new DragonQuiz.ServerDbContext())
			{
				// Display all Blogs from the database 
				var query = from b in db.Questions
							
							where b.Tags == tags // HACK: отвратительный костыль; а если тегов несколько?
							
							select b;

				//DQuestion[] qArr = query.ToArray<DQuestion>(); 

				Random rnd = new Random();
				var res = query.Take(qNum).ToArray();
				//if (qArr.Length < qNum)
				//string s = JsonConvert.SerializeObject(res);
				////return s;

				//var r = new HttpResponseMessage()
				//{
				//	Content = s;
					
				//};

				return res;
			}
		}

		// POST api/values
		public void Post([FromBody]List<DQuestion> questionsList)
		{
			// posts or updates each item from the received question list
			using (var db = new DragonQuiz.ServerDbContext())
			{
				foreach (var item in questionsList)
				{
					var foundItem = db.Questions
						  .Where(p => p.Content == item.Content).FirstOrDefault();

					if (foundItem == null)
					{
						db.Questions.Add(item);
					}
					else
					{
						db.Entry(foundItem).CurrentValues.SetValues(item);
					}
				}

				db.SaveChanges();
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
