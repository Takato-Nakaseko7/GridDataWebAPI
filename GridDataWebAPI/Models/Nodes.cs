using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GridDataWebAPI.Models
{
    [Table("Nodes")]
    public class Nodes
    {
        [Key]
        public int NodeId { get; set; }

        public string? NodeName { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }

        // navigation property
        public Regions? Region { get; set; }

        public ICollection<Measures>? Measures { get; set; }
    }
}
