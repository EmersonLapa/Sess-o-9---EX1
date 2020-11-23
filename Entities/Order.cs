using System;
using System.Collections.Generic;
using System.Text;
using EX2.Entities.Enums;
using System.Globalization;

namespace EX2.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Itens { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            Itens.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Itens.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem item in Itens)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine();
            stringBuilder.AppendLine("ORDER SUMMARY: ");
            stringBuilder.AppendLine("Order moment: "  + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            stringBuilder.AppendLine("Order status: " + Status);
            stringBuilder.AppendLine("Client: " + Client);
            stringBuilder.AppendLine("Order items: ");
            foreach(OrderItem item in Itens)
            {
                stringBuilder.AppendLine(item.ToString());
            }
            stringBuilder.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return stringBuilder.ToString();
        }
        
    }
}
