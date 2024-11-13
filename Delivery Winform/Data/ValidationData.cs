using Delivery_Winform.Model.OrderModel;
using Delivery_Winform.Model.OrderModel.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_Winform.Data
{
    public class ValidationData
    {
        //[RegularExpression(@"^(?:[1-9]\d*(?:\.\d+)?|0\.0*[1-9]\d*)$", ErrorMessage = "Вeс должен быть в диапазоне 1-2 кг")]
        //[RegularExpression(@"^([1-9][0-9]{0,1}(\.[\d]{1,2})?|100)$", ErrorMessage = "Вeс должен быть в диапазоне 1-2 кг")]
        ////[property: Range(1, 100, ErrorMessage = "Вeс должен быть в диапазоне {1}-{2} кг")]
        public double Weight { get; set; }

        [RegularExpression("^(?:10|[1-9])00(?:,\\s*(?:10|[1-9])00)*$", ErrorMessage = "Идентификатор района должен быть в диапазоне 100-1000 и кратным 100")]
        public int? CityDistrict { get; set; }

        [RegularExpression("^([0-9]{4})-((01|02|03|04|05|06|07|08|09|10|11|12|(?:J(anuary|u(ne|ly))|February|Ma(rch|y)|A(pril|ugust)|(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)|(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SENTTEMBER|OCTÜBER|NOVEMBER|DECEMBER)|(September|October|Novem бер|декабрь)|(янв|фев|март|апр|май|июн|июл|авг|сен|окт|ноя|дек)|(ЯНВ|ФЕВ|МАР|АПР|МАЙ|ИЮН|ИЮЛ|АВГ|СЕН|ОКТ|НОЯ|ДЕК)))|(янв|февраль|март|апрель|май|июнь|июль|август|сентябрь|октябрь|ноябрь|декабрь))-([0-3][0-9])\\s([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$",
        ErrorMessage = "Похоже, что вы ввели не дату," +
        "\nнеобходимый формат даты\"yyyy-MM-dd HH:mm:ss\" \nгод-месяц-день часы:минуты:секунды")]
        public string? ValidationDateTime { get; set; }
        public ValidationData(string _validationDateTime) => ValidationDateTime = _validationDateTime;
        public ValidationData(int _cityDistrict) => CityDistrict = _cityDistrict;
        public ValidationData(double _weight) => Weight = _weight;
        public static bool IsCheckedValidation(ValidationData validation)
        {
            var context = new ValidationContext(validation);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(validation, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsCheckedValidation(double validation)
        {
            if (validation < 0.1 || validation > 70)
            {  
                MessageBox.Show("Вeс должен быть в диапазоне 0,1-70 кг");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
