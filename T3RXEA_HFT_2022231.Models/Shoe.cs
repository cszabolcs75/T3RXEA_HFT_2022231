using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace T3RXEA_HFT_2022231.Models
{
    [Table("Shoes")]
    
    public class Shoe
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [ForeignKey(nameof(Sport))]
        public int SportId { get; set; }
        [Required]
        public int Prize { get ; set; }
        [Required]
        public string  Name { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Brand brands { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Sport sports { get; set; }

    }
}
