using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Winform.Model.OrderModel.Abstractions
{
    public interface IOrder
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public int CityDistrict { get; set; }
        public DateTime DeliveryDateTime { get; set; }

    }
}
