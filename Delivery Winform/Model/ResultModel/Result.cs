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

        [property: Range(1, 100, ErrorMessage = "Вeс должен быть в диапазоне {1}-{2} кг")]
        public int Weight_OrderResult { get; set; }

        [RegularExpression("^(?:10|[1-9])00(?:,\\s*(?:10|[1-9])00)*$", ErrorMessage = "Идентификатор района должен быть в диапазоне 100-1000 и кратным 100")]
        public int CityDistrict_OrderResult { get; set; }

        [RegularExpression("^([0-9]{4})-((01|02|03|04|05|06|07|08|09|10|11|12|(?:J(anuary|u(ne|ly))|February|Ma(rch|y)|A(pril|ugust)|(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)|(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SENTTEMBER|OCTÜBER|NOVEMBER|DECEMBER)|(September|October|Novem бер|декабрь)|(янв|фев|март|апр|май|июн|июл|авг|сен|окт|ноя|дек)|(ЯНВ|ФЕВ|МАР|АПР|МАЙ|ИЮН|ИЮЛ|АВГ|СЕН|ОКТ|НОЯ|ДЕК)))|(янв|февраль|март|апрель|май|июнь|июль|август|сентябрь|октябрь|ноябрь|декабрь))-([0-3][0-9])\\s([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$",
        ErrorMessage = "Похоже, что вы ввели не дату," +
        "\nнеобходимый формат даты\"yyyy-MM-dd HH:mm:ss\" \nгод-месяц-день часы:минуты:секунды")]
        public DateTime DeliveryDateTime_OrderResult { get; set; }
        public Result(int id, int weight, int _cityDistrict, DateTime _deliveryDateTime)
        {
            Id_OrderResult = id;
            Weight_OrderResult = weight;
            CityDistrict_OrderResult = _cityDistrict;
            DeliveryDateTime_OrderResult = _deliveryDateTime;
        }
        public Result(int weight, int _cityDistrict, DateTime _deliveryDateTime)
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
