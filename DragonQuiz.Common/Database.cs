using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace DragonQuiz
{
    public class Database
    {
		public List<DQuestion> GetPack(DRequest request)
		{
			// TODO: stub
			List<DQuestion> stub = new List<DQuestion>();
			stub.Add(new DQuestion(0, "Кто лучше всех?", "МАТМЕХ", "", "common"));
			stub.Add(new DQuestion(0, "ПТУ при ЛГУ?", "Факультет ПМ-ПУ", "", "common"));
			stub.Add(new DQuestion(0, "Кто не нужен?", "Юрфак", "", "common"));
			stub.Add(new DQuestion(0, "Широкую на?", "Широкую", "", "common"));
			return stub;
		}

		public void PushQuestions(List<DQuestion> questionsList) {
			return;
		}
    }
}
