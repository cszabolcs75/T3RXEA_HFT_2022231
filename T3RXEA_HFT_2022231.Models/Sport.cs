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
    [Table("Sports")]
    public class Sport
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsOlimpic { get; set; }
        [Required]
        public string Inventor { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Brand> brands { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Shoe> shoes { get; set; }
    }
}
