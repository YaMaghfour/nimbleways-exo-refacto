using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refacto.DotNet.DAL.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("lead_time")]
        public int LeadTime { get; set; }

        [Column("available")]
        public int Available { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("max_sale_qty")]
        public int? MaxSellQuantity { get; set; }
    }
}
