using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal static class ChatHelper
    {
        public static void SendMessage(ICreature creature, string text)
        {
            Console.WriteLine($"{creature.Name} : {text}");
        }
    }
}
