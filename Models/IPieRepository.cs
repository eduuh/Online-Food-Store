using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
   public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPiebyId(int id);
    }
}
