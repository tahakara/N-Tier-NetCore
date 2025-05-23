﻿using Buisness.Concrete;
using DataAccess.Concrete.EF;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();

            CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal(),new CategoryManager(new EFCategoryDal()));
            
            var result = productManager.GetProductDetail();

            if (result.Success) // if(result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductId + " - " + product.ProductName + " - " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}