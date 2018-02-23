using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PmspProjeto.Models
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Servidor Servidor { get; set; }
        
        public int ServidorId { get; set; }
        

        [Required]
        [StringLength(50)]
        public string Logradouro { get; set; }
        
        [Required]
        public int Numero { get; set; }
        
        public string Complemento { get; set; }
        
        [Required]
        [StringLength(10)]
        public string CEP { get; set; }
    }
}