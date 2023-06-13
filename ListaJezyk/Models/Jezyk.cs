using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaJezyk.Models
{
    public class Jezyk
    {
        [Key]
        public int JezykId { get; set; }
        [Column(TypeName ="nvarchar(20)")]
        [Required]
        public string JezykNazwa { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string DataRozpoczecia { get; set; }
        [Required]
        public int KategoriaId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string Ocena { get; set; }
    }
}
