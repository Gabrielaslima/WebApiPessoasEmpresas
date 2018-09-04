using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiExercicio.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [MinLength(14)]
        [MaxLength(18)]
        public string Cnpj { get; set; }

        public Empresa(int id, string nome, string cnpj)
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
        }
    }
}