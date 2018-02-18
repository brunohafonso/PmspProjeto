using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PmspProjeto.Models
{
    public class Servidor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength=2)]
        public string Nome { get; set; }
        
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        
        [Required]
        [StringLength(50)]
        public string EndLogradouro { get; set; }
        
        [Required]
        public int EndNumero { get; set; }
        
        public string EndComplemento { get; set; }
        
        [Required]
        [StringLength(10)]
        public string EndCEP { get; set; }
        
        [Required]
        [StringLength(50)]
        public string EndBairro { get; set; }
        
        [Required]
        [StringLength(9)]
        public string RF { get; set; }
        
        [Required]
        public int Vinculo { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }
        
        [Required]
        [StringLength(50)]
        public string UnidadeLotacao { get; set; }
        
        [Required]
        [StringLength(50)]
        public string UnidadeExercicio { get; set; } 
    }
}