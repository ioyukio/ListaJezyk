using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaJezyk.Models
{
    public class Kategoria
    {
        [Key]
        public int KategoriaId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string KategoriaNazwa { get; set; }  
    }
}
