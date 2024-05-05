using Microsoft.EntityFrameworkCore;
using GridDataWebAPI.Models;

namespace GridDataWebAPI
{
    public class GridDataContext: DbContext
    {
        public DbSet<Grid> Grids { get; set; }

        public DbSet<Nodes> Nodes { get; set; }

        public DbSet<Regions> Regions { get; set; }    

        public DbSet<Measures> Measures { get; set; }


        public GridDataContext()
        {

        }

        public GridDataContext(DbContextOptions<GridDataContext> options) : base(options) 
        {

        }
    }
}
