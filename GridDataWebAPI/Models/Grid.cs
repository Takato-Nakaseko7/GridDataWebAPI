using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GridDataWebAPI.Models
{
    [Table("Grid")]
    public class Grid
    {
        [Key]
        public int GridId { get; set; }

        public string? GridName { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }

        // navigation property
        public Regions? Region { get; set; }
    }
}
