using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Entities
{
     public class Category
    {
        private static int ID = 1;
        public int Category_ID { get; set; }
        public static int  GenerateCategoryId()
        {
            return ID++;
        }
        public string Category_Name { get; set; }
        public string CategoryShortCode { get; set; }
        public string CategoryDescription { get; set; }
        

    }
}
