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
                    if (error.ErrorMessage != null)
                        Logger.WriteLog("Валидация не пройдена", 400, error.ErrorMessage);
                }
                return false;
            }
            else
            {
                Logger.WriteLog("Валидация пройдена успешно", 100, "Произведено без ошибок");
                return true;
            }
        }
        public static bool IsCheckedData(string textBox)
        {
            if (textBox == "")
            {
                MessageBox.Show("Не удалось создать объект Order, \nнеобходимые поля для создания объекта либо пустые, либо заполнены неправильно\n" +
                    "Заполните поля \"Weight\", \"CityDistrict\", \"DeliveryDate\"\n" +
                    "\"Weight\" - 0.1-70,  \"CityDistrict\" - 100-1000 c шагом 100, \"DeliveryDate\" - \"yyyy-MM-dd HH:mm:ss\"");
                return false;
            }
            return true;
        }
        public static bool IsCheckedValidationFilter(string _cityDistrict, string _firstDeliveryDateTime)
        {
            try
            {
                ValidationData _validationDistrict = new ValidationData(Convert.ToInt32(_cityDistrict));
            ValidationData _validationDate = new ValidationData(_firstDeliveryDateTime);
            if (IsCheckedData(_cityDistrict) && IsCheckedData(_firstDeliveryDateTime)
              && IsCheckedValidation(_validationDistrict)
                && IsCheckedValidation(_validationDate))
            {
                return true;
            }
            return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Заполнение полей для фильтрации", 300, ex.Message);
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool IsCheckedValidationOrder(string _weight, string _cityDistrict, string _deliveryDateTime, out Order order)
        {
            try
            {
                if (IsCheckedData(_weight) && IsCheckedData(_cityDistrict) &&
                    IsCheckedData(_deliveryDateTime))
                {
                    ValidationData _validationDistrict = new ValidationData(Convert.ToInt32(_cityDistrict));
                    ValidationData _validationDate = new ValidationData(_deliveryDateTime);
                    if (_weight.Length <= 6)
                    {
                        if (IsCheckedValidation(Convert.ToDouble(_weight)) && IsCheckedValidation(_validationDistrict)
                                && IsCheckedValidation(_validationDate))
                        {
                            order = new Order(Math.Round(Convert.ToDouble(_weight),3),
                            Convert.ToInt32(_cityDistrict), Convert.ToDateTime(_deliveryDateTime));
                            return true;
                        }
                        else
                        {
                            order = new Order();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Максимальное число хх.ххх\n" +
                            "Если введете число х.хххх,то программа округлит к макету числа х.ххх");
                        order = new Order();
                        return false;
                    }
                }
                order = new Order();
                return false;
            }
            catch (Exception ex)
            {
                order = new Order();
                Logger.WriteLog("Заполнение полей для добавления нового заказа", 300, ex.Message);
                MessageBox.Show(ex.Message);
                return false;
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
