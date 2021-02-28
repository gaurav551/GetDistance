using System;
using System.Collections.Generic;
using System.Linq;

namespace GetNearbyLocation
{
    class Program
    {
            static List<Place> places = new List<Place>(){
            new Place(){Id=1,Name="Baneshwor", Longitude=85.335284, Latitude=27.688630},
            new Place(){Id=2, Name="Shantinagar", Longitude=85.348330, Latitude=27.684678},
            new Place(){Id=3,Name="Baneshwor Height", Longitude=85.339232, Latitude=27.701398},
            new Place(){Id=4, Name="Lagankhel", Longitude=85.322603, Latitude=27.665895},
            new Place(){Id=5,Name="Jawalakhel", Longitude=85.311766, Latitude=27.676621},
            new Place(){Id=6, Name="Ekantakuna", Longitude=85.308349, Latitude=27.666833},
            new Place(){Id=7,Name="Balkot", Longitude=85.377856, Latitude=27.666283},
             new Place(){Id=8, Name="Sanepa", Longitude=85.305875, Latitude=27.684505},
            new Place(){Id=9,Name="Lazimpat", Longitude= 85.323316, Latitude=  27.725161},
             new Place(){Id=10,Name="Kalimati", Longitude=85.288120, Latitude=27.697179},
             new Place(){Id=11, Name="Bhotahiti", Longitude=85.314090, Latitude=27.706860},
            new Place(){Id=12,Name="Kuleshwor", Longitude= 85.296663, Latitude=  27.692186},
              new Place(){Id=11, Name="Kritipur", Longitude= 85.277480, Latitude= 27.664402},
            new Place(){Id=12,Name="Chobhar", Longitude= 85.277377, Latitude= 27.655596},
            new Place(){Id=12,Name="Panauti", Longitude= 85.517106, Latitude=   27.591603}

          
           
          
           
        };
        static void Main(string[] args)
        {
            double lat, longitude;
            System.Console.WriteLine("Where are you?");
            string location = Console.ReadLine();
            Console.WriteLine("You are in "+ location);
            //Get Nearby within certain area
            int withInKtm = 2;
            var coord = places.FirstOrDefault(x=>x.Name.Equals(location, StringComparison.OrdinalIgnoreCase));
            if(coord!=null)
            {
                lat = coord.Latitude;
                longitude = coord.Longitude;
                var data = places.Select(x=> new Results(){
                  PlaceId = x.Id,
                  PlaceName = x.Name,
                  Distance = GetDistance.DistanceTo(x.Latitude, x.Longitude, lat, longitude)
                }).OrderBy(p=>p.Distance).Where(e=>e.PlaceId!=coord.Id && e.Distance<withInKtm).Take(2).ToList();

                if(data.Count<=0)
                {
                    System.Console.WriteLine("Sorry!  No places in "+ location + " around  " + withInKtm + " KM");
                }
               // System.Console.WriteLine("Nearest Places Are " + string.Join(",", data.PlaceName) );
               foreach (var item in data)
               {
                    System.Console.WriteLine(item.PlaceName + " Is " + item.Distance + " KM");  
               }

            }
            else
            {
                System.Console.WriteLine("Sorry Place doesnt exist");
            }
            //System.Console.WriteLine(GetDistance.DistanceTo(27.688630, 85.335284 , 27.684678, 85.348330));
           
            
        }
    }
}
