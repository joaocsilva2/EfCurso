using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCurso.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        public override string ToString()
        {
            return "id:" + this.Id + " Nome:" + this.Nome + " Categoria [" + this.Categoria.ToString() + "]";
        }
    }
}
