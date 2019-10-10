using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private List<Pie> _pies;
        public MockPieRepository()
        {
             if(_pies == null)
            {
                InitializePies();
            }

        }

        private void InitializePies()
        {
            _pies = new List<Pie>
            {
                new Pie {Id=1,Name ="Apple pie",Price=12.95M,ShortDescription=@"Here's what you need: vanilla ice cream, flour, salt, butter,
            ice water, granny smith apple, sugar, flour, salt, cinnamon, nutmeg, lemon, egg, sugar.",LongDescription =@"An apple pie is a pie 
        in which the principal filling ingredient is apple. It is, on occasion, served with whipped cream or iced cream,
         or with cheddar cheese. The pastry part is generally used top-and-bottom, making it a double-crust pie; the upper crust may be 
         circular or latticed.",ImageUrl = "https://pie.com/applepie",ImageThumbnailUrl="https://applepie.thubnail", IsPieofTheWeek= true
                },


                new Pie {Id=1,Name ="Blue berry Cheese Cake",Price=18.95M,ShortDescription=@"this is a good pie",
                    LongDescription = "Apple pie are great",ImageUrl = "https://pie.com/applepie",
                    ImageThumbnailUrl="https://applepie.thubnail", IsPieofTheWeek= true},
               
                new Pie {Id=1,Name ="Dutch Apple Pie",Price=12.95M,ShortDescription=@"The difference between classic apple pie and Dutch 
        apple pie is all in the delicious crumb topping. Instead of a pie-crust, Dutch apple pie features a
        generous blanket of sweet",LongDescription = "Apple pie are great",ImageUrl = "https://pie.com/applepie",
                    ImageThumbnailUrl="https://applepie.thubnail", IsPieofTheWeek= true},


                new Pie {Id=1,Name ="Cherry Pie",Price=12.95M,ShortDescription="this is a good pie",LongDescription = "Apple pie are great",
                    ImageUrl = "https://pie.com/applepie",ImageThumbnailUrl="https://applepie.thubnail", IsPieofTheWeek= true},
            };
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _pies;
        }

        public Pie GetPiebyId(int id)
        {
            return _pies.FirstOrDefault(p => p.Id == id);
        }
    }
}
