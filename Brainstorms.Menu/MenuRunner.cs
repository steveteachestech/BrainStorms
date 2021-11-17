using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Brainstorms.Menu
{
    public static class MenuRunner
    {
        private static object[] args;

        public static void Execute(Assembly executingAssembly)
        {
            while(true)
            {
                Console.Clear();

                var types = executingAssembly.DefinedTypes
                    .Select(t => GetMain(t))
                    .Where(t => t != null && t.Name != executingAssembly.EntryPoint.DeclaringType.Name).ToList();

                int icount = 0;
                foreach (var itemType in types)
                {

                    Console.WriteLine($"{icount} - {itemType.Name}");
                    icount++;
                }
                Console.WriteLine("\n\nPress Q or Return key to Quit or choose a number...");
                var k = Console.ReadLine();
                if (k.ToUpper() == "Q" || k.Count() == 0)
                {
                    return;
                }
                else if (!IsNumeric(k))
                {
                    continue;
                }
                
                var selected = int.Parse(k.ToString());

                if (selected > types.Count - 1)
                {
                    continue;
                }
                Console.Clear();
                var t = types[selected].AsType();
                var m = types[selected].DeclaredMethods.SingleOrDefault(m => m.IsStatic && m.Name == "Main");
                m.Invoke(null,null);
                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey();
            }

        }

        private static TypeInfo GetMain(TypeInfo t)
        {
            if (t.DeclaredMethods.Any(m => m.IsStatic && m.Name == "Main"))
            {
                return t;
            }
            return null;
        }

        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
