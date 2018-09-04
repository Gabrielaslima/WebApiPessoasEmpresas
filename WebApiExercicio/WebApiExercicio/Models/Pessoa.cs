using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiExercicio.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(14)]
        public string Cpf { get; set; }

        public Pessoa(int id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}