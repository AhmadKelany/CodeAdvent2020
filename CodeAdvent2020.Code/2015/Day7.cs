using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent.Code._2015
{
    public class Day7
    {
        public static List<string> GetInput() => File.ReadAllLines("2015/InputFiles/Day7.txt").ToList();
        static Dictionary<string, int> wires = new Dictionary<string, int>();
        static bool IsInt(string s)
        {
            return int.TryParse(s, out _);
        }

        public record Action(string Command, string OtherKey1, string OtherKey2, int O1, int O2, string key)
        {
            public override string ToString()
            {
                return $"C:{Command},K:{key},O1:{O1},O2:{O2},O1K:{OtherKey1},O2K:{OtherKey2}";
            }
            public bool CanCalculate()
            {
                bool result = Command switch
                {
                    "ASSIGN" or "NOT" => O1 > -1 || wires.ContainsKey(OtherKey1),
                    _ => (O1 > -1 || wires.ContainsKey(OtherKey1)) && (O2 > -1 || wires.ContainsKey(OtherKey2))
                };
                return result;
            }
        }
        public static Action GetAction(string s)
        {
            var a = s.Split(' ');
            string key = a[a.Length - 1];
            string command = "";
            // operands (o1,o2) : -1:other key has value, -2:operand not considered
            int o1 = -1;
            int o2 = -2;
            string otherKey1 = "";
            string otherKey2 = "";
            switch (a.Length)
            {
                case 3: // assignment
                    command = "ASSIGN";
                    AssignOperandData(a[0], ref o1, ref otherKey1);
                    break;
                case 4: // not
                    command = "NOT";
                    AssignOperandData(a[1], ref o1, ref otherKey1);
                    break;
                case 5: // and, or, lshift, rshift
                    command = a[1];
                    AssignOperandData(a[0], ref o1, ref otherKey1);
                    AssignOperandData(a[2], ref o2, ref otherKey2);
                    break;
                default:
                    break;
            }



            return new Action(command, otherKey1, otherKey2, o1, o2, key);
        }

        static void AssignOperandData(string input, ref int operand, ref string key)
        {
            if (IsInt(input))
            {
                operand = int.Parse(input);
            }
            else
            {
                key = input;
                operand = -1;
            }

        }
        public static void ApplyAction(Action action)
        {
            var o1 = action.O1 == -1 ? wires[action.OtherKey1] : action.O1;
            var o2 = action.O2 == -2 ? 0 : (action.O2 == -1 ? wires[action.OtherKey2] : action.O2);

            wires[action.key] = action.Command switch
            {
                "ASSIGN" => o1,
                "AND" => o1 & o2,
                "OR" => o1 | o2,
                "NOT" => UInt16.MaxValue - o1,
                "LSHIFT" => o1 << o2,
                "RSHIFT" => o1 >> o2
            };
        }

        public static int Part2()
        {
            var aSignalFromPart1 = Part1();
            var allActions = GetInput().Select(GetAction).ToList();
            var bAction = allActions.FirstOrDefault(a => a.key == "b");
            allActions.Remove(bAction);
            bAction = new Action("ASSIGN", "", "", aSignalFromPart1, -2, "b");
            allActions.Add(bAction);
            var result = ProcessActions(allActions);
            Screen.WriteLine($"Part 2 result = {result}" , ConsoleColor.Cyan);
            return result;

        }

        private static int ProcessActions(List<Action> allActions)
        {
            wires.Clear();
            while (allActions.Count > 0)
            {
                var action = allActions.FirstOrDefault(a => a.CanCalculate());
                ApplyAction(action);
                allActions.Remove(action);

            }


            var result = wires["a"];


            return result;
        }

        public static int Part1()
        {
            
            var allActions = GetInput().Select(GetAction).ToList();
            var result = ProcessActions(allActions);
            Screen.WriteLine($"Part 1 result = {result}" , ConsoleColor.Green);
            return result;
           
        }
    }
}
