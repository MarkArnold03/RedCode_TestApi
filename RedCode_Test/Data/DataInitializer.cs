using Microsoft.EntityFrameworkCore;
using RedCode_Test.Models;
using System.Xml.Linq;

namespace RedCode_Test.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();

        }
        private void SeedData()
        {
            if (!_dbContext.Books
            .Any(e => e.Title == "Harry Potter"))
            {
                _dbContext.Add(new Book
                {
                    Title = "Harry Potter",
                    Writer = "J.K. Rowling",
                    PublishDate = new DateTime(1997, 6, 26)

                });
            }
            if (!_dbContext.Books
            .Any(e => e.Title == "The Lord of the Rings"))
            {
                _dbContext.Add(new Book
                {
                    Title = "The Lord of the Rings",
                    Writer = "J.R.R. Tolkien",
                    PublishDate = new DateTime(1954, 7, 29)

                });
            }

            if (!_dbContext.Books
            .Any(e => e.Title == "The Autobiography of Malcolm X"))
            {
                _dbContext.Add(new Book
                {
                    Title = "The Autobiography of Malcolm X",
                    Writer = "Malcolm X",
                    PublishDate = new DateTime(1965, 10, 29)

                });
            }

            if(!_dbContext.Citats
                .Any(e => e.Name == "John 3:16"))
            {
                _dbContext.Add(new Citat
                {
                    Name = "John 3:16",
                    Text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.",
                    Writer = "John the Apostle."

                });
            }

            if (!_dbContext.Citats
               .Any(e => e.Name == "Romans 8:28"))
            {
                _dbContext.Add(new Citat
                {
                    Name = "Romans 8:28",
                    Text = "And we know that in all things God works for the good of those who love him, who have been called according to his purpose.",
                    Writer = "Paul the Apostle"

                });
            }

            if (!_dbContext.Citats
               .Any(e => e.Name == "Proverbs 3:5-6"))
            {
                _dbContext.Add(new Citat
                {
                    Name = "Proverbs 3:5-6",
                    Text = "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.",
                    Writer = "King Solomon"

                });
            }

            if (!_dbContext.Citats
               .Any(e => e.Name == "Psalm 23:1"))
            {
                _dbContext.Add(new Citat
                {
                    Name = "Psalm 23:1",
                    Text = "The Lord is my shepherd, I lack nothing.",
                    Writer = "King David"

                });
            }

            if (!_dbContext.Citats
               .Any(e => e.Name == "Philippians 4:13"))
            {
                _dbContext.Add(new Citat
                {
                    Name = "Philippians 4:13",
                    Text = " I can do all things through Christ who strengthens me",
                    Writer = "Paul the Apostle."

                });
            }
        }
    }
}
