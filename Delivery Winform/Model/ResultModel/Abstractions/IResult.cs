using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Winform.Model.ResultModel.Abstractions
{
    public interface IResult
    {
        public int Id { get; set; }
        public int Id_OrderResult { get; set; }
        public double Weight_OrderResult { get; set; }
        public int CityDistrict_OrderResult { get; set; }
        public DateTime DeliveryDateTime_OrderResult { get; set; }
    }
}
