using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShopCar.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имение не менее 5 символов")]
        public string? name { get; set; }
    
        [Display(Name = "Введите фамилие")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string? surname { get; set; }

        [Display(Name = "Введите телефон")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера не менее 10 символов")]
        public string? phone { get; set; }

        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина email не менее 15 символов")]
        public string? email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] // срыто и не отражено в исходном коде
        public DateTime orderTime { get; set; }
        public List<OrderDetail>? orderDetails { get; set; }

    }
}