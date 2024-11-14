using Delivery_Winform.Model.OrderModel;
using Delivery_Winform.Model.OrderModel.Abstractions;
using Delivery_Winform.Model.ResultModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery_Winform.Data
{
    public class DataWorker
    {
        public static List<Order> Read_Orders_From_DB_DeliveryService()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Orders.ToList();
        }
        public static List<Result> Read_Results_From_DB_DeliveryService()
        {
            using ApplicationContext db = new ApplicationContext();
            return db.Results.ToList();
        }
        public static IEnumerable<Order> Filter_Orders(out ApplicationContext db, string _cityDistrict, string _firstDeliveryDateTime)
        {
                db = new ApplicationContext();
                Logger.WriteLog("Фильтрация по заданным параметрам таблицы Orders", 100, "Успешная фильтрация объекта, произведено без ошибок");
                return db.Orders.Where(x => x.CityDistrict == Convert.ToInt32(_cityDistrict)
                && x.DeliveryDateTime >= Convert.ToDateTime(_firstDeliveryDateTime)
                && x.DeliveryDateTime <= Convert.ToDateTime(_firstDeliveryDateTime).AddMinutes(30));
        }
        public static void Add_Filter_Orders_In_Results_Table(IEnumerable<Order> orders, ApplicationContext db)
        {
                db.Results.ExecuteDelete();
                if (orders.ToList().Count > 0)
                {
                    foreach (Order u in orders)
                    {
                        Result result1 = new Result
                        {
                            Id_OrderResult = u.Id,
                            Weight_OrderResult = u.Weight,
                            CityDistrict_OrderResult = u.CityDistrict,
                            DeliveryDateTime_OrderResult = u.DeliveryDateTime
                        };
                        db.Results.Add(result1);
                        db.SaveChanges();
                        Logger.WriteLog("Добавление новой записи в таблицу Results", 100, "Добавление нового объекта произведено без ошибок");
                    }
                }
                else
                {
                    MessageBox.Show("Фильтрация по заданным параметрам вернула пустое значение");
                }
        }
        public static void Delete_Orders_From_DB_DeliveryService(DataGridView dataGrid)
        {
            try
            {
                using ApplicationContext db = new ApplicationContext();
                if (dataGrid.SelectedRows.Count > 0)
                {
                    int index = dataGrid.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGrid[0, index].Value.ToString(), out id);
                    Order? order = db.Orders.Find(id);
                    if (order != null)
                    {
                        db.Orders.Remove(order);
                        db.SaveChanges();
                        MessageBox.Show("Заказ удален");
                        Logger.WriteLog("Удаление выделенной записи таблицы Orders", 100, "Удаление объекта произведено без ошибок");
                    }
                }
                else
                {
                    MessageBox.Show("Выделите всю строку для удаления");
                }
            }   
            catch (Exception ex)
            {
                Logger.WriteLog("Удаление выделенной записи таблицы Orders", 300, ex.Message);
                MessageBox.Show(ex.Message);
            }
}
        public static void Add_Orders_In_DB_DeliveryService(Order order)
        {
            try
            {
                if (order != null)
                {
                    using ApplicationContext db = new ApplicationContext();
                    db.Orders.Add(order);
                    db.SaveChanges();
                    MessageBox.Show($"Заказ успешно создан.");
                    Logger.WriteLog("Добавление новой записи в таблицу Orders", 100, "Добавление нового объекта произведено без ошибок");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Добавление нового заказа", 300, ex.Message);
                MessageBox.Show(ex.Message);
            }
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
        public static void Bind_DataGridView_Using_DeliveryService_DB(List<Result> results, DataGridView dataGrid)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Weight", typeof(double));
            table.Columns.Add("CityDistrict", typeof(int));
            table.Columns.Add("DeliveryDateTime", typeof(string));
            foreach (Result i in results)
            {
                table.Rows.Add(i.Id_OrderResult, i.Weight_OrderResult, i.CityDistrict_OrderResult, i.DeliveryDateTime_OrderResult.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            dataGrid.DataSource = table;
        }
       
    }
}
