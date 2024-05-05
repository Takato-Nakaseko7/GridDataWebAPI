using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GridDataWebAPI.Models
{
    [Table("Regions")]
    public class Regions
    {
        [Key]
        public int RegionId { get; set; }

        public string? RegionName { get; set; }

        public ICollection<Grid>? Grids { get; set; }

        public ICollection<Nodes>? Nodes { get; set; }
    }
}
