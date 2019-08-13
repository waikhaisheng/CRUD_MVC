using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_MVC.Models
{
    [Table("TestStudent")]
    public class TestStudent
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}