using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Business.Models
{
   public class ProductModel:RecordBase
    {
        [Required(ErrorMessage ="{0} is required!")]
        [MinLength(5,ErrorMessage ="{0} must be minumum {1} characters!")]
        [MaxLength(200, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Name { get; set; }

        [StringLength(500,ErrorMessage ="{0} must be maximum {1} characters!")]
        public string Description { get; set; }

        [DisplayName("Unit Price")]
        [Required(ErrorMessage = "{0} is required!")]
        public double UnitPrice { get; set; }

        [DisplayName("Unit Price")]
        [Required(ErrorMessage = "{0} is required!")]
        public string UnitPriceText { get; set; }

        //public string UnitPriceText => UnitPrice.ToString(new CultureInfo("en"));

        [DisplayName("Stock Amount")]

       
        public int StockAmount { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} is required!")]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
