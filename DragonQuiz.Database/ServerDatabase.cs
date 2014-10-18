using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuiz
{
	public class ServerDbContext : DbContext
    {
		public DbSet<DQuestion> Questions { get; set; }
    }
}
