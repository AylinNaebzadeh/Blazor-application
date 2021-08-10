using System;
using System.Collections.Generic;

namespace BlazorDB.Shared.Models
{
    public static class MyCart
    {
        public static Dictionary<Product,int> cart;
        static MyCart()
        {
            cart= new Dictionary<Product, int>();
        }
        public static void MySet(Product key, int value)
        {
            if(cart.ContainsKey(key))
            {
                cart[key] = value;
            }
            else
            {
                cart.Add(key,value);
            }
        }
        public static int MyGet(Product key)
        {
            int result=0;
            if(cart.ContainsKey(key))
            {
                result = cart[key];
            }
            return result;
        }
    }
}