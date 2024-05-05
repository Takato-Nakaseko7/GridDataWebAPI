using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GridDataWebAPI.Models
{
    [Table("Measures")]
    public class Measures
    {
        [Key]
        public int MeasureId { get; set; }

        [ForeignKey("Nodes")]
        public int NodeId { get; set; }

        public int Value { get; set; }

        public DateTime RecordTime { get; set; }

        public DateTime TargetTime { get; set; }

        // navigation property
        public Nodes? Node { get; set; }


    }
}
