using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExercicio.Models;

namespace WebApiExercicio.Repository
{
    public class PessoaContexto
    {
        private static readonly List<Pessoa> _pessoas = new List<Pessoa>()
        {
            new Pessoa(1,"Gabriel","164.430.508-94"),
            new Pessoa(2,"Jose","223.583.648-86"),
            new Pessoa(3,"Maria","652.545.488-35"),
            new Pessoa(4,"Ana","619.540.048-34"),
        };

        public static void Add(Pessoa pessoa)
        {
            int codigo = 0;

            if (_pessoas.Any())
                codigo = _pessoas.LastOrDefault().Id;

            pessoa.Id = ++codigo;

            _pessoas.Add(pessoa);
        }

        public static void Remove(Pessoa pessoa)
        {
            _pessoas.Remove(pessoa);
        }

        public static List<Pessoa> ConsultarTodos()
        {
            return _pessoas;
        }

        public static Pessoa ConsultarPor(Func<Pessoa, bool> expressao)
        {
            return _pessoas.FirstOrDefault(expressao);
        }

        public static bool Update(Predicate<Pessoa> expressao, Pessoa pessoa)
        {
            var index = _pessoas.FindIndex(expressao);

            if (index >= 0)
            {
                _pessoas[index] = pessoa;
                return true;
            }

            return false;
        }
    }
}