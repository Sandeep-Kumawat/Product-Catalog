﻿using Assignment2.Entities;
using System;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit) {
                Console.WriteLine("Hello, Please Select Option");
                Console.WriteLine("a. Category");
                Console.WriteLine("b. Product");
                Console.WriteLine("c. Exit App!");

                char ch = Convert.ToChar(Console.ReadLine());

                switch (ch)
                {
                    case 'a':
                        CategoryOperation.CategoryOperationMenu();
                        break;
                    case 'b':
                        ProductOperation.ProductOperationMenu();
                        break;
                    case 'c':
                        Console.WriteLine("Exit");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
                Console.Clear();
            }
        }
    }
}
