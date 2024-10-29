using Delivery_Winform.Model.OrderModel;
using Delivery_Winform.Model.OrderModel.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Numerics;
using System.Windows.Forms;
using Delivery_Winform.Data;
using Microsoft.EntityFrameworkCore;
using Delivery_Winform.Model.ResultModel;
using Delivery_Winform.Model.ResultModel.Abstractions;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;


namespace Delivery_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Bind_DataGridView_Using_DeliveryService_DB();
            int count = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                count++;
                if (count == 4)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 160;
                }
            }
        }
        private void Bind_DataGridView_Using_DeliveryService_DB()
        {
            using (Data.ApplicationContext db = new Data.ApplicationContext())
            {
                DataTable table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Weight", typeof(int));
                table.Columns.Add("CityDistrict", typeof(int));
                table.Columns.Add("DeliveryDateTime", typeof(string));
                var orders = db.Orders.ToList();
                foreach (Order u in orders)
                {
                    table.Rows.Add(u.Id, u.Weight, u.CityDistrict, u.DeliveryDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                dataGridView1.DataSource = table;
            }
        }
        //Add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxWeight.Text == "" || textBoxCityDistrict.Text == "" ||
            textBoxDeliveryDate.Text == "")
                {
                    MessageBox.Show("Не удалось создать объект Order, \nнеобходимые поля для создания объекта либо пустые, либо заполнены неправильно\n" +
                        "Заполните поля \"Weight\", \"CityDistrict\", \"DeliveryDate\"\n" +
                        "\"Weight\" - 1-100,  \"CityDistrict\" - 100-1000 c шагом 100, \"DeliveryDate\" - \"yyyy-MM-dd HH:mm:ss\"");
                }
                else
                {
                    ValidationData _validationDate = new ValidationData(textBoxDeliveryDate.Text);
                    if (ValidationData.IsCheckedValidation(_validationDate))
                    {
                        Order order = new Order(Convert.ToInt32(textBoxWeight.Text),
                        Convert.ToInt32(textBoxCityDistrict.Text), Convert.ToDateTime(textBoxDeliveryDate.Text));
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
                            MessageBox.Show($"Заказ успешно создан.");
                            using (Data.ApplicationContext db = new Data.ApplicationContext())
                            {
                                db.Orders.Add(order);
                                db.SaveChanges();
                            }
                            Logger.WriteLog("Добавление новой записи в таблицу Orders", 100, "Добавление нового объекта произведено без ошибок");
                            Bind_DataGridView_Using_DeliveryService_DB();
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
        //Filter
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (Data.ApplicationContext db = new Data.ApplicationContext())
                {
                    ValidationData _validationDistrict = new ValidationData(Convert.ToInt32(textBoxFiltCityDistrict.Text));
                    ValidationData _validationDate = new ValidationData(textBoxFiltDeliveryDate.Text);
                    if (textBoxFiltCityDistrict.Text != "" && textBoxFiltDeliveryDate.Text != ""
                      && ValidationData.IsCheckedValidation(_validationDistrict)
                        && ValidationData.IsCheckedValidation(_validationDate))
                    {
                        DateTime _firstDeliveryDateTime = Convert.ToDateTime(textBoxFiltDeliveryDate.Text);
                        var orders = db.Orders.Where(x => x.CityDistrict == Convert.ToInt32(textBoxFiltCityDistrict.Text)
                        && x.DeliveryDateTime >= _firstDeliveryDateTime
                        && x.DeliveryDateTime <= _firstDeliveryDateTime.AddMinutes(30));
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
                                dataGridView1.ClearSelection();
                                DataTable table = new DataTable();
                                table.Columns.Add("Id", typeof(int));
                                table.Columns.Add("Weight", typeof(int));
                                table.Columns.Add("CityDistrict", typeof(int));
                                table.Columns.Add("DeliveryDateTime", typeof(string));
                                var results = db.Results.ToList();
                                foreach (Result i in results)
                                {
                                    table.Rows.Add(i.Id_OrderResult, i.Weight_OrderResult, i.CityDistrict_OrderResult, i.DeliveryDateTime_OrderResult.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                dataGridView1.DataSource = table;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Фильтрация по заданным параметрам вернула пустое значение");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Фильтрация по заданным параметрам", 300, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        //Delete
        private void button3_Click(object sender, EventArgs e)
        {
            using (Data.ApplicationContext db = new Data.ApplicationContext())
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    Order? order = db.Orders.Find(id);
                    if (order != null)
                    {
                        db.Orders.Remove(order);
                        db.SaveChanges();
                        MessageBox.Show("Заказ удален");
                        Bind_DataGridView_Using_DeliveryService_DB();
                    }
                }
                else
                {
                    MessageBox.Show("Выделите всю строку для удаления");
                }
            }
        }
        //Now
        private void button4_Click(object sender, EventArgs e)
        {
            textBoxDeliveryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Bind_DataGridView_Using_DeliveryService_DB();
        }
    }
}
