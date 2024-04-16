using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain.Entities
{
    [Table("Product")]
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }   
    }
}
