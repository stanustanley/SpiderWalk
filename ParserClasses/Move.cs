using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Parser.Enums;

namespace Parser
{
    public class Move
    {
        public MoveType moveType { get; set; }
        public int range { get; set; }
        public Move(MoveType moveType, int range) : base()
        {
            this.moveType = moveType;
            this.range = range;
        }
        public Move(string command) : base()
        {
            MoveParser moveParser = new MoveParser(command);
            this.moveType = moveParser.GetMoveType();            
            this.range = moveParser.GetNumber();
        }
        private Move() { }
        public Move GetMove()
        {
            return this;
        }
        public void PerformMove()
        {
            switch (this.moveType)
            {
                case MoveType.wait:
                    Console.WriteLine($"Czekam {this.range}ms");
                    break;
                case MoveType.nogi_L:
                    Console.WriteLine($"Ruszam nogami lewymi o wartość {this.range}");
                    break;
                case MoveType.nogi_P:
                    Console.WriteLine($"Ruszam nogami prawymi o wartość {this.range}");
                    break;
                case MoveType.nogi_S:
                    Console.WriteLine($"Ruszam nogami środkowymi o wartość {this.range}");
                    break;
                case MoveType.unknown:
                    Console.WriteLine("Nieznany typ ruchu lub błąd konwersji");
                    break;
                default:
                    Console.WriteLine("Coś poszło bardzo nie tak");
                    break;
            }
        }
    }
}
