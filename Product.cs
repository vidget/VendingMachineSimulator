using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_Simulator___Midterm
{
    class Product
    {

            private string _name;
            private double _price;
            private int _quantity;

            public Product()
            {
                _name = "";
                _price = 0.00;
                _quantity = 0;
            }



            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }

      }
}
