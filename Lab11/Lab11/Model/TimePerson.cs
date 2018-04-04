using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11.Model
{
    public class TimePerson
    {
        //Code and properties given in directions
        //Headers for the display table and properties for the TimePerson Object
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        //CSV converstion mothod returns a list of people based on year range
        public List<TimePerson> GetPersons(int begYear, int endYear)
        {
            List<TimePerson> people = new List<TimePerson>(); //Int a new list of TimePerson
            string path = Environment.CurrentDirectory; //Set the base path
            //set the path for the csv file
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            //USe the File.System to pull in data from the csv
            string[] myFile = File.ReadAllLines(newPath);
            //Setup the the loop to seperate the data
            for (int i = 1; i < myFile.Length; i++) //Start at 1 to avoid header row
            {
                //Setup a string[] that will hold our fields by line split on ","
                string[] fields = myFile[i].Split(',');
                //Build a new person based on the field data in each index
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]), //convert because it comes in as a string.
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    //If empty retunr 0 otherwise convert to int
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }
            //Filter the list based on year range
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            //return the filtered list
            return listofPeople;
        }
    }
}
