using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery_Winform.Model.OrderModel;
using Microsoft.Extensions.Logging;
using Delivery_Winform.Model.ResultModel;
using System.Linq.Expressions;
using Microsoft.VisualBasic.ApplicationServices;


namespace Delivery_Winform.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Result> Results { get; set; }

        public ApplicationContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Cоздание базы данных, если она не существует, и инициализирует её схему", 200, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DeliveryService;Trusted_Connection=True;Multipleactiveresultsets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().
                Property(p => p.DeliveryDateTime)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
            Order order_obj1 = new Order
            {
                Id = 1,
                Weight = 1.290,
                CityDistrict = 100,
                DeliveryDateTime = new DateTime(2024, 10, 29, 18, 30, 25)
            };

            Order order_obj2 = new Order
            {
                Id = 2,
                Weight = 12.832,
                CityDistrict = 400,
                DeliveryDateTime = new DateTime(2024, 10, 29, 22, 45, 00)
            };

            Order order_obj3 = new Order
            {
                Id = 3,
                Weight = 4.750,
                CityDistrict = 200,
                DeliveryDateTime = new DateTime(2024, 10, 29, 22, 30, 00)
            };
            Order order_obj4 = new Order
            {
                Id = 4,
                Weight = 7.134,
                CityDistrict = 200,
                DeliveryDateTime = new DateTime(2024, 10, 29, 22, 37, 00)
            };

            Order order_obj5 = new Order
            {
                Id = 5,
                Weight = 7.800,
                CityDistrict = 300,
                DeliveryDateTime = new DateTime(2024, 10, 29, 20, 37, 00)
            };
            Order order_obj6 = new Order
            {
                Id = 6,
                Weight = 17.469,
                CityDistrict = 300,
                DeliveryDateTime = new DateTime(2024, 10, 29, 22, 35, 00)
            };
            Order order_obj7 = new Order
            {
                Id = 7,
                Weight = 13.210,
                CityDistrict = 400,
                DeliveryDateTime = new DateTime(2024, 10, 29, 22, 37, 00)
            };
            Order order_obj8 = new Order
            {
                Id = 8,
                Weight = 15.950,
                CityDistrict = 400,
                DeliveryDateTime = new DateTime(2024, 10, 29, 22, 38, 00)
            };
            modelBuilder.Entity<Order>().HasData(order_obj1, order_obj2, order_obj3,
                order_obj4, order_obj5, order_obj6, order_obj7, order_obj8);
        }
    }
}
