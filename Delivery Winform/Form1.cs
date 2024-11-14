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
            DataWorker.Bind_DataGridView_Using_DeliveryService_DB(DataWorker.Read_Orders_From_DB_DeliveryService(), dataGridView1);
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
        //Add
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidationData.IsCheckedValidationOrder(textBoxWeight.Text, textBoxCityDistrict.Text, textBoxDeliveryDate.Text, out Order order))
            DataWorker.Add_Orders_In_DB_DeliveryService(order);
            DataWorker.Bind_DataGridView_Using_DeliveryService_DB(DataWorker.Read_Orders_From_DB_DeliveryService(), dataGridView1);
        }
        //Filter
        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidationData.IsCheckedValidationFilter(textBoxFiltCityDistrict.Text, textBoxFiltDeliveryDate.Text))
            {
                var filtered_order = DataWorker.Filter_Orders(out Data.ApplicationContext db, textBoxFiltCityDistrict.Text, textBoxFiltDeliveryDate.Text);
                DataWorker.Add_Filter_Orders_In_Results_Table(filtered_order, db);
                dataGridView1.ClearSelection();
                DataWorker.Bind_DataGridView_Using_DeliveryService_DB(DataWorker.Read_Results_From_DB_DeliveryService(), dataGridView1);
            }
        }
        //Delete
        private void button3_Click(object sender, EventArgs e)
        {
            DataWorker.Delete_Orders_From_DB_DeliveryService(dataGridView1);
            DataWorker.Bind_DataGridView_Using_DeliveryService_DB(DataWorker.Read_Orders_From_DB_DeliveryService(), dataGridView1);
        }
        //Now
        private void button4_Click(object sender, EventArgs e)
        {
            textBoxDeliveryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DataWorker.Bind_DataGridView_Using_DeliveryService_DB(DataWorker.Read_Orders_From_DB_DeliveryService(), dataGridView1);
        }
    }
}
