using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServices_MyProducts.Models
{
    public class Smartphone
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public string SousTitre { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
