using BlogApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BlogRecordsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any blog posts.
            if (context.BlogPosts.Any())
            {
                return;   // DB has been seeded
            }

            var blogPosts = new BlogPost[]
            {
                new BlogPost{HeaderText="Välkommen!", BodyText="Avsluta julmiddagen med en riktigt bra juldessert. Saffran, citrus, pepparkakor eller lingon smakar extra juligt och gott. ", CategoryName="Matlagning", PublishDate=DateTime.Parse("2016-09-01") },
                new BlogPost{HeaderText="Julgodis", BodyText="Knäck, kola, fudge, fransk nougat, rocky road - vilken är din godisfavorit? Här hittar du massor av gott julgodis", CategoryName="Jul", PublishDate=DateTime.Parse("2016-10-05") },
                new BlogPost{HeaderText="Fiskgryta", BodyText="Fiskgryta med tomat, saffran, fänkål och aioli. En mustig fiskgryta är aldrig fel. Det här är en tacksam rätt där det går lika bra att använda fryst som färsk fisk.", CategoryName="Matlagning", PublishDate=DateTime.Parse("2015-06-23") },
                new BlogPost{HeaderText="Högrev i ugn", BodyText="Bjud på klassisk stek till helgen! Den behöver visserligen några timmar på sig i ugnen, men när den väl ligger där sköter den sig själv. En smakrik potatisgratäng smakar gott till.", CategoryName="Kött", PublishDate=DateTime.Parse("2006-01-13") },
                new BlogPost{HeaderText="Pizza", BodyText="Pizza utan tomatsås och med en blandning av ricotta och en lagrad ost är gott som tilltugg till ett glas rödvin till exempel. Receptet kommer från webbtidningen Le Parfait.", CategoryName="Italienskt", PublishDate=DateTime.Parse("2016-11-01") },
            };
            foreach (BlogPost s in blogPosts)
            {
                context.BlogPosts.Add(s);
            }
            context.SaveChanges();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category {CategoryName = "Matlagning" },
                new Category {CategoryName = "Italienskt" }
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();


        }
    }
}