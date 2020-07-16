﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            //var locations = lines.Select(parser.Parse).ToArray();
            var locations = lines.Select(parser.Parse).ToArray();
            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable localA = null;
            ITrackable localB = null;
            double t = 0.000621371; // convertion rate meter to mile 
            double distance = 0;


            for (var i = 0; i< locations.Length; i++)
            {
                for(var j=0; j<locations.Length; j++)
                {
                    var firstLocal = new GeoCoordinate(locations[i].Location.Latitude, locations[i].Location.Longitude);
                    var secondLocal = new GeoCoordinate(locations[j].Location.Latitude, locations[j].Location.Longitude);

                    var distanceB2in = (firstLocal.GetDistanceTo(secondLocal))*t; // here I use converting meters into miles which is t 

                    if (distanceB2in > distance)
                    {
                        localA = locations[i];
                        localB = locations[j];
                        distance = distanceB2in ;
                    }

                }
            }

            Console.WriteLine($"the locals with the logest distance between are : {localA.Name} and {localB.Name}");
            Console.WriteLine($"there we got {Math.Round(distance, 2)} between them");

            // this is the new Branch






            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }

        //public static void JuanTester(string line)
        //{
        //    TacoParser actualJuan = new TacoParser();

        //    var actualJuanParse = actualJuan.Parse("34.073638, -84.677017, Taco Bell Acwort...");



        //        Console.WriteLine(actualJuanParse.Location.Longitude);

        //}
    }
}
