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
    [Table("Brands")]
    public class Brand
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey(nameof(Sport))]
        public int SuggestedSportId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Owner { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Sport sports { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Shoe> shoes { get; set; }

    }
}
