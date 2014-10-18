using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DragonQuiz.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public List<DQuestion> Get()
		{
			using (var db = new DragonQuiz.ServerDbContext())
			{
				// Display all Blogs from the database 
				var query = from b in db.Questions
							orderby b.Content
							select b;

				return (List<DQuestion>)query;
			}
			
			/* return new List<DQuestion>() {
				new DQuestion(0, "Epic win?", "Epic win!", "", "common")
			}; */
		}

		// GET api/values/5
		public List<DQuestion> Get(DRequest request)
		{
			using (var db = new DragonQuiz.ServerDbContext())
			{
				// Display all Blogs from the database 
				var query = from b in db.Questions
							where b.Tags == request.Tags // HACK: отвратительный костыль; а если тегов несколько?
							select b;

				return (List<DQuestion>)query;
			}

			 /* return new List<DQuestion>() {
				new DQuestion(0, "Epic win?", "Epic win!", "", "common")
			}; */
		}

		// POST api/values
		public void Post([FromBody]List<DQuestion> questionsList)
		{
			// TODO: post the questions to DB
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
