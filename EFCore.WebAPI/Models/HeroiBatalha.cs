using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class HeroiBatalha
    {
        public int HeroiID { get; set; }
        public int BatalhaID { get; set; }
        public Heroi Heroi { get; set; }
        public Batalha Batalha { get; set; }
    }
}
