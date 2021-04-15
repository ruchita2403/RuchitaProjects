using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCEmployeeModel
    {
        public int EmployeeID { get; set; }

       [Required(ErrorMessage ="This field is mandatory")]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Salary { get; set; }
        public Nullable<int> Age { get; set; }
    }
}