﻿using System;
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
        }

        static void AddToStack(string key , List<Action> data , Stack<Action> stack)
        {
            var action = data.FirstOrDefault(a => a.key == key);
            stack.Push(action);
            //Console.WriteLine($"added{action}");
            
            if (action.O1 != -1 && action.O2 != -1) return;
            var oa1 = stack.FirstOrDefault(a => a.key == action.OtherKey1);
            var oa2 = stack.FirstOrDefault(a => a.key == action.OtherKey2);
            var ob1 = !stack.Any(a => a.key == action.OtherKey1);
            var ob2 = !stack.Any(a => a.key == action.OtherKey2);
            if (action.OtherKey1 != "" && !stack.Any(a => a.key == action.OtherKey1)) AddToStack(action.OtherKey1, data, stack);
            if (action.OtherKey2 != "" && !stack.Any(a => a.key == action.OtherKey2)) AddToStack(action.OtherKey2, data, stack);
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
        static int processed = 0;
        public static void ApplyAction(Action action, Dictionary<string, int> wires )
        {
            //if ((action.O1 == -1 && !data.ContainsKey(action.OtherKey1)) || (action.O2 == -1 && !data.ContainsKey(action.OtherKey2)))
            //{
            //    actions.Enqueue(action);
            //    return;
            //}
            var o1 = action.O1 == -1 ? wires[action.OtherKey1] : action.O1;
            var o2 = action.O2 == -2 ? 0 : (action.O2 == -1 ? wires[action.OtherKey2] : action.O2);

            wires[action.key] = action.Command switch
            {
                "ASSIGN" => o1,
                "AND" => o1 & o2,
                "OR" => o1 | o2,
                "NOT" => UInt16.MaxValue - o1,
                "LSHIFT" => o1 >> o2,
                "RSHIFT" => o1 << o2
            };
            processed += 1;
        }
        //public static void ProcessData(string s, Dictionary<string, int> data)
        //{
        //    var a = s.Split(' ');

        //    switch (a.Length)
        //    {
        //        case 3: // assignment, to a number or to another variable
        //            if (IsInt(a[0]) || data.ContainsKey(a[0]))
        //            {
        //                data[a[2]] = data.ContainsKey(a[0]) ? data[a[0]] : int.Parse(a[0]);
        //            }
        //            break;
        //        case 4: // not

        //            data[a[3]] = UInt16.MaxValue - int.Parse(a[1]);
        //            break;
        //        case 5: // and, or, lshift, rshift
        //            int o1 = data.ContainsKey(a[0]) ? data[a[0]] : int.Parse(a[0]);
        //            int o2 = data.ContainsKey(a[2]) ? data[a[2]] : int.Parse(a[2]);
        //            switch (a[1])
        //            {
        //                case "AND":
        //                    data[a[4]] = o1 & o2;
        //                    break;
        //                case "OR":
        //                    data[a[4]] = o1 | o2;
        //                    break;
        //                case "LSHIFT":
        //                    data[a[4]] = o1 >> o2;
        //                    break;
        //                case "RSHIFT":
        //                    data[a[4]] = o1 << o2;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}



        public static int Part1()
        {
            var stack = new Stack<Action>();
            var allActions = GetInput().Select(GetAction).ToList();
            AddToStack("a", allActions, stack);
            var t = stack.Count;







            var wires = new Dictionary<string, int>();
            //var actions = new Queue<Action>();
            //GetInput().Reverse();
            //foreach (var input in GetInput())
            //{
            //    actions.Enqueue(GetAction(input));
            //}
            //var stack = new Stack<Action>();
            //while (true)
            //{

            //}
            //var u = actions.Select(a => a.key).Distinct();
            while (stack.Count > 0)
            {
                var a = stack.Pop();
                ApplyAction(a, wires);
            }
            var result = wires["a"];


            Screen.WriteLine($"Part 1 result = {result}");
            return result;
           
        }
    }
}