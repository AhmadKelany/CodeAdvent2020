using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code
{
    public class Day11
    {
        public enum Status { Floor , Empty , Occupied}
        public record Seat (int Id , Status Status , List<int> ConnectedSeatIds);
        public static List<Seat> GetSeats()
        {
            var lines = File.ReadAllLines("InputFiles/Day11.txt");
            var width = lines.First().Length;
            var height = lines.Count();
            var maxId = (width * height) - 1;


        }

    }
}
