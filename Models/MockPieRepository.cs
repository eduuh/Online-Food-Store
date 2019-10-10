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
            if (_pies == null)
            {
                InitializePies();
            }

        }

        private void InitializePies()
        {
            _pies = new List<Pie>
            {
                new Pie {Id=1,Name ="Apple pie",Price=14.55M,ShortDescription=@"Here's what you need: vanilla ice cream, flour, salt, butter,
            ice water, granny smith apple, sugar, flour, salt, cinnamon, nutmeg, lemon, egg, sugar.",LongDescription =@"An apple pie is a pie 
        in which the principal filling ingredient is apple. It is, on occasion, served with whipped cream or iced cream,
         or with cheddar cheese. The pastry part is generally used top-and-bottom, making it a double-crust pie; the upper crust may be 
         circular or latticed.",ImageUrl = "https://pie.com/applepie",ImageThumbnailUrl="https://applepie.thubnail", IsPieofTheWeek= true
                },


                new Pie {Id=2,Name ="Blue berry Cheese Cake",Price=18.95M,ShortDescription=@"Great Place to Try It: Patisserie on Newbury in Boston’s Back Bay neighborhood makes delectable cheesecake in-house.",
                    LongDescription = @"Distinguishing Features: First off—yes, this is a pie, since it uses a graham-cracker crust that’s synonymous with pies. 
                    The other main ingredient is cream cheese or ricotta, which can be combined with myriad other flavors
                     (mocha, Oreos, peanut butter, etc.)",ImageUrl = "https://pie.com/blueberry",
                    ImageThumbnailUrl="https://blueberry.thubnail", IsPieofTheWeek= true},

                new Pie {Id=3,Name ="Dutch Apple Pie",Price=11.95M,ShortDescription=@"The difference between classic apple pie and Dutch 
        apple pie is all in the delicious crumb topping. Instead of a pie-crust, Dutch apple pie features a
        generous blanket of sweet",LongDescription = "Apple pie are great",ImageUrl = "https://pie.com/applepie",
                    ImageThumbnailUrl="https://applepie.thubnail", IsPieofTheWeek= true},

                new Pie {Id=4,Name ="Sugar Cream pie",Price=18.25M,ShortDescription=@"Mrs. Wick’s Pie Shop in Winchester, IN, might be the best place on earth to eat Hoosier
                 Pie—the Wick family once sold them out of the back of a 1934 Buick.",LongDescription = @"Distinguishing Features: Brown sugar, butter, and cream; a simple treat, but one of the most addictive types of pies; popular in French and Quebecois cuisines, 
                 as well as the Midwest USA, where it is also called “Hoosier Pie” due to its association with Indiana.",
                    ImageUrl = "https://pie.com/sugarcreampie",ImageThumbnailUrl="https://sugarcreampie.thubnail", IsPieofTheWeek= true},

                new Pie {Id=5,Name ="Pecan Pie",Price=17.55M,ShortDescription=@"The pie should not be overly jiggly when you remove it from the oven (though it will jiggle a bit). 
                If it shakes a lot, cover with foil and bake for an additional 20 minute or until set.",LongDescription = @"Pecan pie is a pie of pecan nuts mixed with a filling of eggs, butter, and sugar. Variations may include white or brown sugar, sugar syrup, molasses, maple syrup, or honey. 
                It is popularly served at holiday meals in the United States and is considered a specialty of Southern U.S. origin.",
                    ImageUrl = "https://pie.com/pecanpie",ImageThumbnailUrl="https://pecanpie.thubnail", IsPieofTheWeek= true},


                new Pie {Id=6,Name ="Pumpkin Pie",Price=10.95M,ShortDescription=@"mean old-fashioned pumpkin pie, but only three months
                 out of the year.",LongDescription = @"Pumpkin-flavored custard, ginger, nutmeg; it’s a Thanksgiving classic, in part 
                 because you can use your leftover Halloween jack-o-lantern for its stuffing; the pecan pie is its heated rival.",
                    ImageUrl = "https://pie.com/pumkinpie",ImageThumbnailUrl="https://pumpkin.thubnail", IsPieofTheWeek= true},



                 new Pie {Id=7,Name ="Key Lime Pie",Price=14.95M,ShortDescription=@"Philadelphia has been concocting dozens of pastries for 90+ years, 
                 including a toasted coconut-topped key lime pie.",LongDescription = @"Lime juice (specifically one from a Key lime),
                  meringue topping, and graham-cracker crust; naturally, the pie is heavily associate with the Florida Keys, 
                 and Key West holds a festival for the pie every 4th of July Weekend.",
                    ImageUrl = "https://pie.com/keylimepie",ImageThumbnailUrl="https://keylime.thubnail", IsPieofTheWeek= true},



                new Pie {Id=8,Name ="Cherry Pie",Price=12.95M,ShortDescription=@"Norman, OK, offers a scrumptious cherry pie to nearby 
                University of Oklahoma students.",LongDescription=@"Cherries, namely Montmorency cherries, which are tarter and more sour than your usual Bing cherry; a 
                favorite during the 4th of July; namesake of the 1990 chart-topping hit from glam-rockers Warrant.",
                    ImageUrl = "https://pie.com/cherrypie",ImageThumbnailUrl="https://cherrypie.thubnail", IsPieofTheWeek= true},


                new Pie {Id=9,Name ="Lemon Meringue Pie",Price=16.75M,ShortDescription=@"Supreme Bakery in West Orange, NJ, offers a miniature version of a lemon 
                meringue pie that will leave you thinking about eating another.",LongDescription = @"Distinguishing Features: Lemon custard with a meringue topping; this is that pie with the puffy, 
                enlarged top that looks so soft and inviting, you kinda want to use it as a pillow; it’s also grandma’s favorite pie, often.",
                ImageUrl = "https://pie.com/lemonmeriguepie",ImageThumbnailUrl="https://lemonmeringuepie.thubnail", IsPieofTheWeek= true},

                new Pie {Id=10,Name ="Rhubarb Pie",Price=13.95M,ShortDescription=@"Great Place to Try It: San Diego Chicken Pie Shop is (unsurprisingly) more famous for its chicken pie meals; 
                but it also whips up a fantastic rhubarb pie that you can eat afterwards.",LongDescription = @"Distinguishing Features: A whole lot of rhubarb, often paired with strawberries; one of the tartest pie flavors; 
                a tempting treat for anyone on the “rhubarb diet” (yes, this is real).",ImageUrl = "https://pie.com/rhubarbpie",
                ImageThumbnailUrl="https://rhubarb.thubnail", IsPieofTheWeek= true},

              new Pie {Id=11,Name ="Sweet Potato Pie",Price=10.95M,ShortDescription=@"Great Place to Try It: Snag a homemade Sweet Potato Pie in 
              the Bay Area at Just Pies! By Tara.",LongDescription = @"Distinguishing Features: Sweet potato filling, often with a dollop of whipped cream on top, 
              sometimes topped with a layer of marshmallows instead; a staple of Southern soul food, especially during the holidays.  ",
                    ImageUrl = "https://pie.com/sweetpotatoes",ImageThumbnailUrl="https://sweetpotatoes.thubnail", IsPieofTheWeek= true},

              new Pie {Id=12,Name ="Pot pie",Price=12.95M,ShortDescription=@"Great Place to Try It: The pot pie at The Pie Hole in Venice Beach, Los Angeles, was named one of the city’s best by LA Weekly.",LongDescription = @"Distinguishing Features: The ultimate savory pie; gravy meets chicken, beef, or lamb (plus veggies), tucked inside a pie crust and served steaming hot; 
              second only to chicken-noodle soup for best dishes to enjoy on a cold winter’s day, ideally from inside a log cabin while seated next to a roaring fire.",
                    ImageUrl = "https://pie.com/potpie",ImageThumbnailUrl="https://potpie.thubnail", IsPieofTheWeek= true},

             new Pie {Id=13,Name ="Peach Pie",Price=09.45M,ShortDescription=@"Great Place to Try It: You gotta try one in Georgia, right? Panbury’s Double-Crust Pies in Atlanta landed on 
             Eater’s “Nine Must-Visit Pie Destinations in Atlanta” list.",LongDescription = @"Distinguishing Features: Peaches, plus a sprinkling of nutmeg or cinnamon; it’s especially popular in peach-producing regions, like Georgia; some take their 
             love of peach pie to the next level and create “peace pie moonshine” out of peach schnapps and grain alcohol.",
                    ImageUrl = "https://pie.com/peachpie",ImageThumbnailUrl="https://peachpie.thubnail", IsPieofTheWeek= true},


            new Pie {Id=14,Name ="Coconut Cream Pie",Price=08.95M,ShortDescription=@"Great Place to Try It: Don’t miss Brooklyn’s Miss American Pies,
             home to dozens of pie flavors, including a to-die-for coconut cream.",LongDescription = @"Distinguishing Features: The king of cream pies, it’s a messy conglomeration of coconut custard, whipped cream, and toasted coconut flakes; eat this and 
             imagine you’re on some deserted tropical island with rows of coconut trees (and somehow you have access to pie-making supplies).",
                    ImageUrl = "https://pie.com/coconutpie",ImageThumbnailUrl="https://coconutpie.thubnail", IsPieofTheWeek= true},


                new Pie {Id=15,Name ="Blakckberry Pie",Price=16.95M,ShortDescription=@"Great Place to Try It: You could visit Minnesota’s North Shore and Betty’s 
                Pies—one of America’s great pie shops—for all sorts of flavors, but we’ll take its blackberry-peach pie.",LongDescription = @"Distinguishing Features: Either fresh blackberries or a blackberry jam, 
                a small mountain of sugar, and sometimes some lemon zest or lemon juice.",
                    ImageUrl = "https://pie.com/blueberrypie",ImageThumbnailUrl="https://blueberry.thubnail", IsPieofTheWeek= true},



                new Pie {Id=16,Name ="BlueBerry Pie",Price=17.95M,ShortDescription=@"Great Place to Try It: San Antonio’s Baklovah Bakery offers way more than than its signature baklava, 
                including a delectable blueberry pie.",LongDescription = @"Distinguishing Features: The best blueberries you can find, plus cinnamon; official state dessert of Maine, but don’t sleep on blueberry 
                pies from Michigan, Washington, Maryland, and Oregon—all high blueberry-producing states.",
                    ImageUrl = "https://pie.com/blueberrypie",ImageThumbnailUrl="https://blueberry.thubnail", IsPieofTheWeek= true},


                new Pie {Id=17,Name ="French Silk Pie",Price=12.00M,ShortDescription=@"Great Place to Try It: You might visit The Pie Factory in the Tampa area for its Key Lime pie, but don’t sleep on its French Silk either.",LongDescription = @"Distinguishing Features: It’s the chocolate pie: chocolate mousse, whipped cream, and bittersweet chocolate shavings; favorite pie of children at 
                family reunions everywhere; despite its name, French Silk is a purely American invention, the winner of a 1951 Pillsbury competition.",
                    ImageUrl = "https://pie.com/frenchsilkpie",ImageThumbnailUrl="https://frenchsilk.thubnail", IsPieofTheWeek= true},





                new Pie {Id=18,Name ="Mixed Berry Pie",Price=11.75M,ShortDescription=@"Great Place to Try It: Achatz Handmade Pie Co. in suburban Detroit 
                offers a mixed-berry pie that uses local Michigan berries.",LongDescription = @"Distinguishing Features: A little bit of this, a little bit of that; these pies usually include two or three of the following: blueberries, raspberries, blackberries, strawberries; if you’re in the upper Atlantic Canadian provinces, this might be called a “bumbleberry pie,” 
                which is just delightful, isn’t it?",ImageUrl = "https://pie.com/mixedberrypie",ImageThumbnailUrl="../wwwroot/images/blackberrypie.jpg", IsPieofTheWeek= true},




                new Pie {Id=19,Name ="Banoffee",Price=22.95M,ShortDescription=@"Great Place to Try It: When in New York, stop by Bubby’s in Tribeca for a diner meal finished with a slice of Banoffee, 
                lined with a graham-cracker crust",LongDescription = @"Distinguishing Features: An almost exclusively English pie, Banoffee is one of the best-known versions of the banana cream pie; bananas and toffee are its two must-have ingredients (the name Banoffee is a combo of the two), 
                but you might also find a good heaping of dulce de leche.  ",
                    ImageUrl = "https://pie.com/banoffee",ImageThumbnailUrl="https://banoffe.thubnail", IsPieofTheWeek= true},



                new Pie {Id=20,Name ="Apple Crisp (or Apple Crumble)",Price=22.95M,ShortDescription=@"Great Place to Try It: Pie Town Cafe in suburban 
                Dallas offers a tart green-apple pie with a cinnamon glaze.",LongDescription = @"Distinguishing Features: A variant of the apple pie, the Apple Crisp/Apple Crumble adds a crumbly, buttery topping that gives the pie extra texture. 
                It’s mostly an autumn pie (to correspond with apple harvest in cooler climate), but no one will judge you if you want want one in the summer.",
                    ImageUrl = "https://pie.com/applecrisp",ImageThumbnailUrl="https://applecrisp.thubnail", IsPieofTheWeek= true},


                new Pie {Id=21,Name ="Mississippi Mud Pie",Price=20.95M,ShortDescription=@"Great Place to Try It: In Mississippi, of course! We recommend Mary Mahoney’s Old French House in Biloxi.",LongDescription = @"Distinguishing Features: Chocolate filling, chocolate sauce drizzled on top, and—in case that wasn’t enough chocolate—a chocolate graham-cracker crust; 
                it’s usually infused with other flavors (think coffee liqueur or butterscotch); as you might imagine, it’s a favorite in Mississippi.",
                    ImageUrl = "https://pie.com/mississippipie",ImageThumbnailUrl="https://mississipipie.thubnail", IsPieofTheWeek= true},



                new Pie {Id=22,Name ="Strawberry Pie",Price=19.75M,ShortDescription = @"Great Place to Try It: Every year in May, Jim’s 
                Steak & Spaghetti in Huntington, WV, has a “Strawberry Pie Week,” where they sell more than 10,000 pies.",LongDescription = @"Distinguishing Features: Strawberries. 
                Lots and lots and lots of strawberries (ideally fresh strawberries), often mixed with a strawberry gelatin. 
                We recommend some whipped cream on top to cut some of the sweetness.",
                    ImageUrl = "https://pie.com/strawberrypie",ImageThumbnailUrl="https://strawbery.thubnail", IsPieofTheWeek= true}


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
