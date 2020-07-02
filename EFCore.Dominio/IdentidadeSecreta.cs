using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class IdentidadeSecreta
    {
        public int Id { get; set; }
        public string NomeReal { get; set; }
        public int HeroiID { get; set; }
        public Heroi Herois { get; set; }
    }
}
