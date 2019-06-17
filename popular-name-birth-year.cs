using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    class Program //class is just a container  
    {
        static void Main(string[] args)
        {
            var fileNameStorage = new List<string>(); // must return as an array later: string[] arrayOfStrings = listOfStrings.ToArray();
            var files = Directory.EnumerateFiles("names", "*.csv"); // declaring directory where im referecing name data
            foreach (string file in files)
            {
                fileNameStorage.Add(file);
            }

            Console.Write("What is your gender(M/F): ");
            string gender = Console.ReadLine().ToUpper();
            Console.Write("What is your age:");
            int age = Convert.ToInt32(Console.ReadLine()); // converts string to int since ReadLine() can only read string.
            int newAge = 2019 - age;
          
            foreach (var year in files)
            {
                //if filename in the directory 'files' contains the year a person was born read file and print most popular
                if (year.Contains(newAge.ToString()))  
                {
                    using (StreamReader sr = new StreamReader(year))
                    {
                        
                        String line = sr.ReadToEnd();
                        String[] names = line.Split(
                            new[] { Environment.NewLine },
                            StringSplitOptions.None
                        );

                        if (gender == "F" || gender == "FEMALE")
                        {
                            //since we know first line in file is most pop for F, split on commas and return name + births via index
                            List<string> finalValues = new List<string>(
                                 names[0].Split(new string[] { "," }, StringSplitOptions.None));

                           Console.WriteLine("The most common name for your birth year was: " + finalValues[0] + 
                               ", with a total birth number of " + finalValues[2]);
                        }

                        else if (gender == "M" || gender == "MALE")
                        {
                            for (int i = 0; i < names.Length; i++)
                            {
                                List<string> finalValues = new List<string>(
                                 names[i].Split(new string[] { "," }, StringSplitOptions.None));

                                if (finalValues[1] == "M")
                                {
                                    Console.WriteLine("The most common name for your birth year was: " + finalValues[0] +
                               ", with a total birth number of " + finalValues[2]);
                                    break;
                                }
                            }
                        }

                        else
                        {
                            Console.WriteLine("INVALID GENDER"); // need to make this better
                            for (int j = 0; j < 10; j++)
                            {
                                Console.WriteLine("REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                            }
                           
                        }
                    }
                }
            }
            Console.ReadLine();
         
        }
    }
}
//DataSource, US GOVT.
