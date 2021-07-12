using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class CategoryModel : RecordBase
    {

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(2, ErrorMessage = "{0} must be minumum {1} characters!")]
        [MaxLength(200, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Description { get; set; }
        [DisplayName("Product Count")]
        public int ProductCount{ get; set; }
    }
}
