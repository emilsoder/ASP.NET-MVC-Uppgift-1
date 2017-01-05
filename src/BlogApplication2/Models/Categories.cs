using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication2.Models
{
    public class Category
    {
        //public static string[] CategoryList
        //{
        //    get
        //    {
        //        return new string[]
        //        {
        //            "Matlagning",
        //            "Jul",
        //            "Kött",
        //            "Bakning",
        //            "Fisk",
        //            "Italienskt",
        //            "Franskt",
        //            "Vegetariskt"
        //        };
        //    }
        //}

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}