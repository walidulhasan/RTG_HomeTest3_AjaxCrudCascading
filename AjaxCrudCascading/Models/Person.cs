using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxCrudCascading.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [ForeignKey("Countrys")]
        public int CountryId { get; set; }
        [ForeignKey("Citys")]
        public int CitysId { get; set; }
        //nev
        public Country Countrys { get; set; }
        public City Citys { get; set; }
    }
}
