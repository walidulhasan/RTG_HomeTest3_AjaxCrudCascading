using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxCrudCascading.Models
{
    public class PersonDbContext:DbContext
    {
     

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> citys { get; set; }
        public DbSet<Person> persons { get; set; }
    }
}
