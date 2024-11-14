using Delivery_Winform.Model.ResultModel.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Winform.Model.ResultModel
{
    public class Result : IResult
    {
        public int Id { get; set; }
        public int Id_OrderResult { get; set; }
        public double Weight_OrderResult { get; set; }
        public int CityDistrict_OrderResult { get; set; }
        public DateTime DeliveryDateTime_OrderResult { get; set; }
        public Result(int id, double weight, int _cityDistrict, DateTime _deliveryDateTime)
        {
            Id_OrderResult = id;
            Weight_OrderResult = weight;
            CityDistrict_OrderResult = _cityDistrict;
            DeliveryDateTime_OrderResult = _deliveryDateTime;
        }
        public Result(double weight, int _cityDistrict, DateTime _deliveryDateTime)
        {
            Weight_OrderResult = weight;
            CityDistrict_OrderResult = _cityDistrict;
            DeliveryDateTime_OrderResult = _deliveryDateTime;
        }
        public Result()
        {

        }
    }
}
