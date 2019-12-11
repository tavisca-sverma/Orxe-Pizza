using System;
using System.Collections.Generic;
using System.Text;

namespace Orxe_Pizza
{
    public class Cart
    {
        public Dictionary<Pizza, int> PizzaList = new Dictionary<Pizza, int>();
        private int _totalPrice;

        public void AddPizzaToCart(int pizzaId,int count)
        {  
            if(Menu.ValidatePizzaId(pizzaId) == true)
            {
                if (this.IsPizzaInCart(pizzaId) == true) {
                    PizzaList[Menu.PizzaList[pizzaId - 1]] += count ;
                }
                else
                {
                    PizzaList.Add(Menu.PizzaList[pizzaId - 1], count);
                }

                Console.WriteLine("Pizza added to cart successfully! ");
            }
            
        }

        public void DeletePizzaFromCart(int pizzaId)
        {
            PizzaList.Remove(Menu.PizzaList[pizzaId-1]);

            Console.WriteLine("Pizza removed from cart successfully! ");
        }

        public void ShowCart()
        {
            if (PizzaList.Count == 0)
            {
                Console.WriteLine("Cart is Empty!!");
            }
            else
            {
                _totalPrice = 0;
                Console.WriteLine("<-Pizza's in your Cart->");
                foreach (KeyValuePair<Pizza, int> pizza in PizzaList)
                {
                    pizza.Key.ShowPizzaDetails();
                    Console.WriteLine(" X "+pizza.Value);
                    _totalPrice += pizza.Key.Price * pizza.Value;
                }

                Console.WriteLine("Total amount to be paid :" + _totalPrice);
            }
            
        }

        public void ClearCart()
        {
            PizzaList.Clear();

            Console.WriteLine("Cart is now Empty!!");
        }

        public void CheckOut()
        {
            if(PizzaList.Count < 2 )
            {
                Console.WriteLine(" Add atleast 2 pizza's to complete the order! ");
            }else
            {
                Console.WriteLine(" Your order has been placed successfully! ");
                Console.WriteLine(" Summary of your Order--> ");
                ShowCart();
            }
        }

        public  bool IsPizzaInCart(int pizzaId)
        {
            bool validationResult = false;
            foreach (KeyValuePair<Pizza, int> pizza in PizzaList)
            {
                if (pizza.Key.Id == pizzaId)
                {
                    validationResult = true;
                    break;
                }
            }
            return validationResult;
        }
    }
}
