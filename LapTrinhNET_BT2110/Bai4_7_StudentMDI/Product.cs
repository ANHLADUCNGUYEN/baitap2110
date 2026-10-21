using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bai4_7_StudentMDI
{
    public class Product : INotifyPropertyChanged
    {
        private string productId = string.Empty;
        private string productName = string.Empty;
        private string category = string.Empty;
        private decimal price;
        private int quantity;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string ProductId
        {
            get => productId;
            set
            {
                if (productId != value)
                {
                    productId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ProductName
        {
            get => productName;
            set
            {
                if (productName != value)
                {
                    productName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalValue));
                }
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalValue));
                }
            }
        }

        public decimal TotalValue => Price * Quantity;

        public Product()
        {
        }

        public Product(string productId, string productName, string category, decimal price, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
