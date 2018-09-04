using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExercicio.Models;

namespace WebApiExercicio.Repository
{
    public class EmpresaContexto
    {
        private static readonly List<Empresa> _empresa = new List<Empresa>()
        {
            new Empresa(1,"Baldan","02.883.783/0001-24"),
            new Empresa(2,"Marchesan","77.861.154/0001-00"),
            new Empresa(3,"Palomax","41.310.129/0001-83"),
            new Empresa(4,"Atacadao","48.852.682/0001-97"),
        };

        public static void Add(Empresa empresa)
        {
            int codigo = 0;

            if (_empresa.Any())
                codigo = _empresa.LastOrDefault().Id;

            empresa.Id = ++codigo;

            _empresa.Add(empresa);
        }

        public static void Remove(Empresa empresa)
        {
            _empresa.Remove(empresa);
        }

        public static List<Empresa> ConsultarTodos()
        {
            return _empresa;
        }

        public static Empresa ConsultarPor(Func<Empresa, bool> expressao)
        {
            return _empresa.FirstOrDefault(expressao);
        }

        public static bool Update(Predicate<Empresa> expressao, Empresa empresa)
        {
            var index = _empresa.FindIndex(expressao);

            if (index >= 0)
            {
                _empresa[index] = empresa;
                return true;
            }

            return false;
        }
    }
}