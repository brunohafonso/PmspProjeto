using System;
using System.Collections.Generic;
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
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }

        [Required]
        [StringLength(10)]
        public string RF { get; set; }

        [ForeignKey("VinculoId")]
        public ICollection<Vinculo> Vinculos { get; set; }

        public int VinculoId { get; set; }
    }
}