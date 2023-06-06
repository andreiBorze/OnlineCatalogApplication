using Data.Models;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        #region seed
        public void Seed()
        {
            ctx.Add(new Student
            {
                Name = "Marin Chitac",
                Age = 43,
                Address = new Address
                {
                    City = "Iași",
                    Street = "Revoluției",
                    Number = 32
                }
            });
            ctx.Add(new Student
            {
                Name = "Ana Popescu",
                Age = 21,
                Address = new Address
                {
                    City = "București",
                    Street = "Victoriei",
                    Number = 10
                }
            });
            ctx.Add(new Student
            {
                Name = "Ion Ionescu",
                Age = 25,
                Address = new Address
                {
                    City = "Cluj-Napoca",
                    Street = "Avram Iancu",
                    Number = 5
                }
            });
            ctx.Add(new Student
            {
                Name = "Alexandra Munteanu",
                Age = 19,
                Address = new Address
                {
                    City = "Timișoara",
                    Street = "Eroilor",
                    Number = 15
                }
            });
            ctx.Add(new Student
            {
                Name = "Mihai Popa",
                Age = 22,
                Address = new Address
                {
                    City = "Oradea",
                    Street = "Mihai Viteazu",
                    Number = 8
                }
            });
            ctx.Add(new Student
            {
                Name = "Elena Andreescu",
                Age = 24,
                Address = new Address
                {
                    City = "Constanța",
                    Street = "Mircea cel Bătrân",
                    Number = 12
                }
            });
            ctx.Add(new Student
            {
                Name = "Adrian Mărgineanu",
                Age = 20,
                Address = new Address
                {
                    City = "Sibiu",
                    Street = "Hermann Oberth",
                    Number = 7
                }
            });
            ctx.Add(new Student
            {
                Name = "Cristina Istrate",
                Age = 23,
                Address = new Address
                {
                    City = "Pitești",
                    Street = "Victor Babeș",
                    Number = 14
                }
            });
            ctx.Add(new Student
            {
                Name = "Andrei Popescu",
                Age = 18,
                Address = new Address
                {
                    City = "Timișoara",
                    Street = "Mihai Eminescu",
                    Number = 5
                }
            });
            ctx.Add(new Student
            {
                Name = "Maria Ionescu",
                Age = 20,
                Address = new Address
                {
                    City = "Cluj-Napoca",
                    Street = "Avram Iancu",
                    Number = 15
                }
            });
            ctx.Add(new Student
            {
                Name = "Alexandru Georgescu",
                Age = 22,
                Address = new Address
                {
                    City = "București",
                    Street = "Bălcescu",
                    Number = 25
                }
            });

            ctx.SaveChanges();
        }
        #endregion
    }
}
