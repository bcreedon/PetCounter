using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pets
{
    class Program
    {
        
        static void Main(string[] args)
        {           
            ReplaceJsonValue();      
        }

        public static string SortCommaSeparatedString(string name)
        {
            string[] stringArray = name.Split(',');
            Array.Sort(stringArray, StringComparer.InvariantCulture);
            string returnValue = "";
            for (int i = stringArray.GetLowerBound(0); i <= stringArray.GetUpperBound(0); i++)
            {
                returnValue = returnValue + stringArray[i] + ",";
            }
            return returnValue.Remove(returnValue.Length - 1, 1);
        }


        // Reads JSON file and adds each record to a comma separated list of pets in a home.
        public static void ReplaceJsonValue()
        {
            string filepath = "c:/home/pets.json";
            string json = File.ReadAllText(filepath).ToString();
            string json2 = "{'results':" + json + "}";

            var jsonData = System.IO.File.ReadAllText(filepath);
            var Home = JsonConvert.DeserializeObject<List<Home>>(jsonData)
                                  ?? new List<Home>();

            List<string> list = new List<string>();
            foreach (var pets in Home)
            {
                string strPets = "";
                string strBreak = "";
                for (int i = 0; i < pets.pets.Length; i++)
                {
                    if (i == 0) { 
                    strBreak = "";
                }
                    else
                    {

                        strBreak = ",";
                    }
                    strPets = strPets + strBreak + pets.pets[i];

                }
                // Sorts comma separted lists so they can be counted properly(i.e. dog,cat = cat,dog)
                string strpetsOrdered = SortCommaSeparatedString(strPets);
                list.Add(strpetsOrdered);
            }

            var q = from x in list
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };
            // Outputs top 25 pet combinations including count of each
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
             int i2 = 0;
            foreach (var x in q)
            {
                if (i2++ > 25) break;
                Console.WriteLine("Rank: " + i2 + " " + x.Value + " Count: " + x.Count);
            }
            Console.ReadLine();
            
        }
       
        




    }
   
}














    




