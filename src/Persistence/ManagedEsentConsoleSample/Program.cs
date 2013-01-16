using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Isam.Esent.Collections.Generic;
using Persistence.Entities;

namespace ManagedEsentConsoleSample {
    class Program {
        static void Main(string[] args) {
            var path = Path.GetDirectoryName(typeof(Program).GetType().Assembly.Location);
            var students = new PersistentDictionary<int, Student>(path); 
            
            while (true) {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine("1) Create a student.");

                if (students.Count > 0) {
                    Console.WriteLine("2) List students.");
                }
            
                Console.WriteLine("Q. Quit");

                var line = Console.ReadLine();
                if (String.Equals(line, "Q")) {
                    break;
                }
          }
        }
    }
}
