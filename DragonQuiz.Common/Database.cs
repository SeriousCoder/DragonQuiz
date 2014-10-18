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
		public List<DQuestion> GetPack(DRequest request);

		public void PushQuestions(List<DQuestion>);
    }
}
