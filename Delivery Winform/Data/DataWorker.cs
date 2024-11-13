using Delivery_Winform.Model.OrderModel;
using Delivery_Winform.Model.OrderModel.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery_Winform.Data
{
    public class DataWorker
    {
        public static List<Order> ReadOrdersFromDBDeliveryService()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Orders.ToList();
        }

        public static IEnumerable<Order> FilterOrders(IEnumerable<Order> orders, string district, DateTime firstDeliveryTime)
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Orders.Where(x => x.CityDistrict == Convert.ToInt32(district)
                    && x.DeliveryDateTime >= firstDeliveryTime
                    && x.DeliveryDateTime <= firstDeliveryTime.AddMinutes(30));
        }
        public static void SaveAddOrdersInDBDeliveryService(Order order)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public static void AddOrdersInDBDeliveryService(string textBoxWeight,
            string textBoxCityDistrict, string textBoxDeliveryDate, DataGridView dataGrid)
        {
            try
            {
                if (IsCheckedData(textBoxWeight) && IsCheckedData(textBoxCityDistrict) &&
                IsCheckedData(textBoxDeliveryDate))
                {
                    ValidationData _validationWeight = new ValidationData(Convert.ToDouble(textBoxWeight));
                    ValidationData _validationCityDistrict = new ValidationData(Convert.ToInt32(textBoxCityDistrict));
                    ValidationData _validationDate = new ValidationData(textBoxDeliveryDate);
                    if (ValidationData.IsCheckedValidation(Convert.ToDouble(textBoxWeight)) && ValidationData.IsCheckedValidation(_validationCityDistrict)
                        && ValidationData.IsCheckedValidation(_validationDate))
                    {
                        Order order = new Order(Convert.ToDouble(textBoxWeight),
                        Convert.ToInt32(textBoxCityDistrict), Convert.ToDateTime(textBoxDeliveryDate));
                        var context = new ValidationContext(order);
                        var results = new List<ValidationResult>();
                        if (!Validator.TryValidateObject(order, context, results, true))
                        {
                            MessageBox.Show("Не удалось создать заказ");
                            foreach (var error in results)
                            {
                                MessageBox.Show(error.ErrorMessage);
                            }
                        }
                        else
                        {
                            DataWorker.SaveAddOrdersInDBDeliveryService(order);
                            MessageBox.Show($"Заказ успешно создан.");
                            Logger.WriteLog("Добавление новой записи в таблицу Orders", 100, "Добавление нового объекта произведено без ошибок");
                            Bind_DataGridView_Using_DeliveryService_DB(DataWorker.ReadOrdersFromDBDeliveryService(), dataGrid);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Добавление нового заказа", 300, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        public static bool IsCheckedData(string textBox)
        {
            if (textBox == "")
            {
                MessageBox.Show("Не удалось создать объект Order, \nнеобходимые поля для создания объекта либо пустые, либо заполнены неправильно\n" +
                    "Заполните поля \"Weight\", \"CityDistrict\", \"DeliveryDate\"\n" +
                    "\"Weight\" - 1-100,  \"CityDistrict\" - 100-1000 c шагом 100, \"DeliveryDate\" - \"yyyy-MM-dd HH:mm:ss\"");
                return false;
            }
            return true; 
            
        }
        public static void Bind_DataGridView_Using_DeliveryService_DB(List<Order> orders,DataGridView dataGrid)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Weight", typeof(double));
            table.Columns.Add("CityDistrict", typeof(int));
            table.Columns.Add("DeliveryDateTime", typeof(string));
            foreach (Order u in orders)
            {
                table.Rows.Add(u.Id, u.Weight, u.CityDistrict, u.DeliveryDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            dataGrid.DataSource = table;
        }

    }
}
