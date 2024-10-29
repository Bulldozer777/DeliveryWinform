using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Delivery_Winform.Model.OrderModel.Abstractions;

namespace Delivery_Winform.Model.OrderModel
{
    public class Order : IOrder
    {
        public int Id { get; set; }

        [property: Range(1, 100, ErrorMessage = "Вeс должен быть в диапазоне {1}-{2} кг")]
        public int Weight { get; set; }

        [RegularExpression("^(?:10|[1-9])00(?:,\\s*(?:10|[1-9])00)*$", ErrorMessage = "Идентификатор района должен быть в диапазоне 100-1000 и кратным 100")]
        public int CityDistrict { get; set; }

        public DateTime DeliveryDateTime { get; set; }
        public Order(int id, int weight, int _cityDistrict, DateTime _deliveryDateTime)
        {
            Id = id;
            Weight = weight;
            CityDistrict = _cityDistrict;
            DeliveryDateTime = _deliveryDateTime;
        }
        public Order(int weight, int _cityDistrict, DateTime _deliveryDateTime)
        {         
            Weight = weight;
            CityDistrict = _cityDistrict;
            DeliveryDateTime = _deliveryDateTime;
        }
        public Order()
        { 

        }
    }
}
