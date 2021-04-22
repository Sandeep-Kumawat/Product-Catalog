using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2.Entities
{
    public class CategoryOperation
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category()
            {
                Category_ID = Category.GenerateCategoryId(),
                Category_Name="Commodities",
                CategoryShortCode="Comm",
                CategoryDescription="Common type of goods"
            },
            new Category
            {
              Category_ID = Category.GenerateCategoryId(),
              Category_Name="Capital Goods",
              CategoryShortCode="Capg",
              CategoryDescription="Technoly type of goods"
            },
            new Category
            {
                Category_ID = Category.GenerateCategoryId(),
                Category_Name="Luxury Goods",
                CategoryShortCode="Luxu",
                CategoryDescription="Luxury type of goods"
            }

        };
        public  static void CategoryOperationMenu()
        {
            Console.WriteLine("Please Select Category Operation");
            Console.WriteLine("a. Enter a Category");
            Console.WriteLine("b. List all Categories");
            Console.WriteLine("c. Delete a Category");
            Console.WriteLine("d. Search a Category");
            Console.WriteLine("e. Main Menu");
            char ch1 = Convert.ToChar(Console.ReadLine());

            switch(ch1)
            {
                case 'a':
                    Console.WriteLine("Enter Category Name");
                    var categoryName = Console.ReadLine();
                    while(string.IsNullOrWhiteSpace(categoryName) || int.TryParse(categoryName,out _))
                    {
                        Console.WriteLine("Please Enter Only Char and It can not be Empty");
                        categoryName = Console.ReadLine();
                        //break;
                    }
                    Console.WriteLine("Enter Short Code");
                    var shortCode = Console.ReadLine();
                    var sc = categories.FindAll((i) => i.CategoryShortCode == shortCode);
                   
                    while ((string.IsNullOrWhiteSpace(shortCode) || int.TryParse(shortCode, out _)) || shortCode.Length > 4 || (sc.Count > 0))
                    {
                        Console.WriteLine("Please Enter Only Char/can't null/max 4 char/It should be Unique");
                        shortCode = Console.ReadLine();
                        sc = categories.FindAll((i) => i.CategoryShortCode == shortCode);

                    }
                    
                    Console.WriteLine("Enter Description");
                    var desc = Console.ReadLine();
                    while(string.IsNullOrWhiteSpace(desc)||int.TryParse(desc,out _))
                    {
                        Console.WriteLine("Please Enter Only Char and It can not be Empty");
                        desc = Console.ReadLine();
                    }
                    AddCategory(categoryName, shortCode, desc);
                    break;
                case 'b':
                    ListOfAllCategories();
                    Console.ReadKey();
                    break;
                case 'c':
                    DeleteCategory();
                    break;
                case 'd':
                    SearchCategory();
                    break;
                    case 'e':
                    
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    CategoryOperationMenu();
                    break;

            }
        }

        public static void AddCategory(string categoryName, string shortCode, string desc)
        {
            
            categories.Add(new Category
            {

                Category_ID = Category.GenerateCategoryId(),
                Category_Name = categoryName,
                CategoryShortCode = shortCode,
                CategoryDescription = desc

            });
            ListOfAllCategories();
            Console.ReadKey();
        }
        public static void ListOfAllCategories()
        {
            //Console.WriteLine("Category Id" + "\t" + "Category Name" + "\t" + "Category Short Code" + "\t" + "Category Description\n");
            categories.ForEach((i) =>
            {
                Console.WriteLine($"{i.Category_ID} \n {i.Category_Name}\n{i.CategoryShortCode}\n{i.CategoryDescription}");
            });
           
        }

        public static void DeleteCategory()
        {
            ListOfAllCategories();
            Console.WriteLine("a. Delete By ID");
            Console.WriteLine("b. Delete By Short Code");
            char ch2 = Convert.ToChar(Console.ReadLine());
            switch(ch2)
            {
                case 'a':
                    Console.WriteLine("Enter Id Number to delete");
                    int a = Convert.ToInt32(Console.ReadLine());
                    DeleteById(a);
                    break;
                case 'b':
                    Console.WriteLine("Enter Short Code of Category to Delete");
                    var sc = Console.ReadLine();
                    DeleteByShortCode(sc);
                    break;
            }

        }
        public static void DeleteById(int id)
        {
            try
            {
                var data = categories.Single((i) => i.Category_ID == id);
                categories.Remove(data);

                ListOfAllCategories();
                
            }
            catch
            {
                Console.WriteLine("Id not Found");
            }
            Console.ReadKey();

        }
        public static void DeleteByShortCode(string shortCode)
        {
            try
            {
                var data = categories.Single((i) => i.CategoryShortCode == shortCode);
                categories.Remove(data);
                ListOfAllCategories();
                
            }
            catch
            {
                Console.WriteLine("Short Code not Found");
            }
            Console.ReadKey();
        }

        public static void SearchCategory()
        {
            Console.WriteLine("a. Search By ID");
            Console.WriteLine("b. Search By Name");
            Console.WriteLine("c. Search By Short Code");
            char ch3 = Convert.ToChar(Console.ReadLine());
            switch (ch3)
            {
                case 'a':
                    Console.WriteLine("Enter Id Number to Search");
                    int a = Convert.ToInt32(Console.ReadLine());
                    SearchByID(a);
                    break;
                case 'b':
                    Console.WriteLine("Enter Neme of Category to Search");
                    var name = Console.ReadLine();
                    SearchByName(name);
                    break;
                case 'c':
                    Console.WriteLine("Enter Short Code of Category to Search");
                    var sc = Console.ReadLine();
                    SearchByShortCode(sc);
                    break;
            }

        }
        public static void SearchByID(int id)
        {
           
            
            var data=categories.FindAll((i) => i.Category_ID == id);
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    Console.WriteLine($"{i.Category_ID} \t\t {i.Category_Name}\t\t{i.CategoryShortCode}\t\t{i.CategoryDescription}");
                });
            }
            else
            {
                Console.WriteLine("Id Not Found");
            }
           
        }
        public static void SearchByName(string name)
        {
            var data = categories.FindAll((i) => i.Category_Name==name);
            if (data.Count > 0)
            {
                data.ForEach((i) =>
                {
                    Console.WriteLine($"{i.Category_ID} \t\t {i.Category_Name}\t\t{i.CategoryShortCode}\t\t{i.CategoryDescription}");
                });
            }
            else
            {
                Console.WriteLine("Name Not Found");
            }
           
        }
        public static void SearchByShortCode(string shortCode)
        {
                var data = categories.FindAll((i) => i.CategoryShortCode==shortCode);
                if (data.Count > 0)
                {
                    data.ForEach((i) =>
                    {
                        Console.WriteLine($"{i.Category_ID} \t\t {i.Category_Name}\t\t{i.CategoryShortCode}\t\t{i.CategoryDescription}");
                    });
                }
                else
                {
                    Console.WriteLine("Short Code Not Found");
                }
            }
    }
}
