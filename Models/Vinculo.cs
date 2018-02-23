using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PmspProjeto.Models
{
    public class Vinculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int Vinc { get; set; }

        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Required]
        [StringLength(100)]
        public string UnidadeLotacao { get; set; }

        [Required]
        [StringLength(100)]
        public string UnidadeExercicio { get; set; }

        public Servidor Servidor { get; set; }

        public int ServidorId { get; set; }
    }
}