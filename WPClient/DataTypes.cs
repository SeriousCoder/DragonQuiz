using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuiz
{
	public class DQuestion
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public string Answer { get; set; }
		public string Comment { get; set; }
		public string Tags { get; set; }
		public DQuestion(int id, string content, string answer, string comment, string tags)
		{
			this.Id = id;
			this.Content = content;
			this.Answer = answer;
			this.Comment = comment;
			this.Tags = tags;
		}
		public DQuestion() { }
	}

	public class DRequest
	{
		public int QuestionsNumber { get; set; }
		public string Tags { get; set; }
		public DRequest(int questionsNumber, string tags)
		{
			QuestionsNumber = questionsNumber;
			Tags = tags;
		}

		public override string ToString()
		{
			return "?qNum=" + QuestionsNumber + "&tags=" + Tags;
		}
	}
}
