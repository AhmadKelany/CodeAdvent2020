using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2020.Code._2020
{
    public class Day11
    {
        public enum Status { Floor , Empty , Occupied}
        public class Seat
        {
            public override string ToString()
            {
                return $"{Id}-{Status}";
            }
            public int Id { get; set; }
            public Status Status { get; set; }
            public List<int> ConnectedSeatIds { get; set; }
            public Seat(int id, Status status , List<int> connectedSeatIds)
            {
                Id = id;
                Status = status;
                ConnectedSeatIds = connectedSeatIds;
            }
        }

        public static int Part1()
        {
            var seatsList = GetSeats();
            //Screen.WriteLine("Before loop:");
            //PrintOutSeatsList(seatsList);
            bool hasChanges = false;
            int loopCounter = 1;
            do
            {
                var result = ProcessSeats(seatsList);
                hasChanges = result.hasChanges;
                seatsList = result.newSeatsList;
                //Screen.WriteLine($"After {loopCounter} iteration:", ConsoleColor.Red);
                //PrintOutSeatsList(seatsList);
                //Screen.WriteLine();
                loopCounter++;
            } while (hasChanges);
            return seatsList.Count(s => s.Status == Status.Occupied);
        }

        public static (bool hasChanges,List<Seat> newSeatsList) ProcessSeats(List<Seat> oldSeatsList)
        {
            bool hasChanges = false;
            List<Seat> newSeatsList = new List<Seat>();
            foreach (var seat in oldSeatsList)
            {
                switch (seat.Status)
                {
                    case Status.Empty:
                        if (!oldSeatsList.Where(s => seat.ConnectedSeatIds.Contains(s.Id)).Any(s => s.Status == Status.Occupied))
                        {
                            newSeatsList.Add(new Seat( seat.Id ,  Status.Occupied ,  seat.ConnectedSeatIds ));
                            hasChanges = true;
                        }
                        else
                        {
                            newSeatsList.Add(seat);
                        }
                        break;
                    case Status.Occupied:
                        if ( oldSeatsList.Count(s => seat.ConnectedSeatIds.Contains(s.Id) && s.Status == Status.Occupied) >= 4)
                        {
                            newSeatsList.Add(new Seat(seat.Id, Status.Empty, seat.ConnectedSeatIds));
                            hasChanges = true;
                        }
                        else
                        {
                            newSeatsList.Add(seat);
                        }
                        break;
                    default:
                        break;
                }
            }
            return (hasChanges, newSeatsList);
        }


        //public static void PrintOutSeatsList(List<Seat> seats)
        //{
        //    var orig = Enumerable.Range(0, 100);
        //    foreach (var se in orig)
        //    {
        //        var seat = seats.FirstOrDefault(s => s.Id == se);
        //        if (seat == null)
        //        {
        //            Screen.Write("*", ConsoleColor.Gray);
        //        }
        //        else
        //        {
        //            Screen.Write(seat.Status == Status.Empty ? "L" : "#", seat.Status == Status.Empty ? ConsoleColor.DarkYellow : ConsoleColor.Green);
        //        }
        //        if (se>0 && (se+1)%10 == 0)
        //        {
        //            Screen.WriteLine();
        //        }
        //    }
        //}
        public static List<Seat> GetSeats()
        {
            var lines = File.ReadAllLines("InputFiles/Day11.txt");
            var width = lines.First().Length;
            var height = lines.Count();
            var maxId = (width * height) - 1;
            var fullString = string.Join("", lines);
            var result = new List<Seat>();
            for (int i = 0; i < fullString.Length; i++)
            {
                int id = i;
                if (fullString[i] == '.') continue;
                List<int> connectedIds = new List<int>();
                bool hasLefts, hasRights, hasUps, hasDowns;
                hasLefts = !(i % width == 0);
                hasRights = !((i + 1) % width == 0);
                hasUps = i >= width;
                hasDowns = i < (width * height) - width;
                if (hasLefts)
                {
                    connectedIds.Add(i - 1);
                    if (hasUps)
                    {
                        connectedIds.Add(i - width - 1);
                    }
                    if (hasDowns)
                    {
                        connectedIds.Add(i + width - 1);
                    }
                }
                if (hasRights)
                {
                    connectedIds.Add(i + 1);
                    if (hasUps)
                    {
                        connectedIds.Add(i - width + 1);
                    }
                    if (hasDowns)
                    {
                        connectedIds.Add(i + width + 1);
                    }
                }
                if (hasUps)
                {
                    connectedIds.Add(i - width);
                }
                if (hasDowns)
                {
                    connectedIds.Add(i + width);
                }
                result.Add(new Seat(id, Status.Empty, connectedIds));
            }
            return result ;
        }

    }
}
