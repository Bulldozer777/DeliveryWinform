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
        public double Weight { get; set; }
        public int CityDistrict { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public Order(int id, double _weight, int _cityDistrict, DateTime _deliveryDateTime)
        {
            Id = id;
            Weight = _weight;
            CityDistrict = _cityDistrict;
            DeliveryDateTime = _deliveryDateTime;
        }
        public Order(double _weight, int _cityDistrict, DateTime _deliveryDateTime)
        {         
            Weight = _weight;
            CityDistrict = _cityDistrict;
            DeliveryDateTime = _deliveryDateTime;
        }
        public Order()
        { 

        }
    }
}
