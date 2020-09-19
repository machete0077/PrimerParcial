using System.Data.Entity;

namespace EvalEnriqueArce.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
        public System.Data.Entity.DbSet<EvalEnriqueArce.Models.Pais> Students { get; set; }
    }
}