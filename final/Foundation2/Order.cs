using System.Collections.Generic;
using System.Text;

namespace OnlineOrderingSystem
{
    public class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal GetTotalCost()
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.GetTotalCost();
            }

            if (customer.IsInGhana())
            {
                total += 5; // Shipping cost in the USA
            }
            else
            {
                total += 35; // Shipping cost outside the USA
            }

            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder packingLabel = new StringBuilder();
            foreach (var product in products)
            {
                packingLabel.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
            }
            return packingLabel.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder shippingLabel = new StringBuilder();
            shippingLabel.AppendLine(customer.GetName());
            shippingLabel.Append(customer.GetAddress().GetFullAddress());
            return shippingLabel.ToString();
        }
    }
}
