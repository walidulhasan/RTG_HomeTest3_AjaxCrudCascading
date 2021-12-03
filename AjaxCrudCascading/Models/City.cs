using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxCrudCascading.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string DivisionName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
