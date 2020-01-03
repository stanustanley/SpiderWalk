using System;
using System.Diagnostics;
using static Parser.Enums;

namespace Parser
{
    public class MoveParser
    {
        private string command { get; set; }

        public MoveParser(string command)
        {
            this.command = command;
        }

        public int GetNumber()
        {
            MoveType moveType = GetMoveType();
            if (moveType == MoveType.wait)
            {
                string strTimeMs = command.Split('(')[1].Split(')')[0].Trim();
                int timeMs = -1;
                try
                {
                    timeMs = int.Parse(strTimeMs);
                }
                catch (FormatException ex)
                {
                    if (DotBehaviorScript.delayVariable == 0)
                    {
                        timeMs = GetRangeFromUser(strTimeMs);
                        DotBehaviorScript.delayVariable = timeMs;
                    }
                    else
                        timeMs = DotBehaviorScript.delayVariable;
                }
                return timeMs;
            }
            if (moveType == MoveType.unknown)
            {
                return -1;
            }
            else
            {
                string strRange = command.Split(',')[1].Split(')')[0].Trim();
                int range = -1;
                try
                {
                    range = int.Parse(strRange);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    moveType = MoveType.unknown;
                    range = -1;
                }
                return range;
            }
        }
        public MoveType GetMoveType()
        {
            MoveType moveType;
            string strCommand = command.Split('(')[0].Trim();
            switch (strCommand)
            {
                case "delay":
                    moveType = MoveType.wait;
                    break;
                case "analogWrite":
                    moveType = parseAnalogWriteMethod(command);
                    break;
                default:
                    moveType = MoveType.unknown;
                    Debug.WriteLine("Error with: " + command);
                    break;
            }
            return moveType;

        }
        private MoveType parseAnalogWriteMethod(string command)
        {
            MoveType moveType;
            string strMove = command.Split('(')[1].Split(',')[0].Trim(); // analogWrite(nogi_S,1); => nogi_S

            switch (strMove)
            {
                case "nogi_S":
                    moveType = MoveType.nogi_S;
                    break;
                case "nogi_P":
                    moveType = MoveType.nogi_P;
                    break;
                case "nogi_L":
                    moveType = MoveType.nogi_L;
                    break;
                default:
                    moveType = MoveType.unknown;
                    Debug.WriteLine("Error with: " + command);
                    break;
            }
            return moveType;

        }
        private int GetRangeFromUser(string variable)
        {
            int i = 0;
            Console.WriteLine($"Podaj wartość zmiennej {variable}");
            string x = Console.ReadLine();
            try
            {
                i = int.Parse(x);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Podana wartość nie jest liczbą");
                i = GetRangeFromUser(variable);
            }
            return i;

        }
    }
}
