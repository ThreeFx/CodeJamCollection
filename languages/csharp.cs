/*
 *  The MIT License (MIT)
 *
 *  Copyright (c) 2015 Ben Fiedler
 *
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CodeJamCollection
{
    class Program
    {
        private static void Debug()
        {
            // Do debugging here
        }

        private static string SolveCase()
        {
            return Read<string>();
        }

        public static void Main(string[] args)
        {
            Initialise();
            SolveAllCases(SolveCase);
        }

        private static StreamReader sr;
        private static StreamWriter sw;

        private delegate void Printer(string format, params object[] args);
        private static Printer print;

        private static T Read<T>()
        {
            return (T)Convert.ChangeType(sr.ReadLine(), typeof(T));
        }

        private static string Read()
        {
            return sr.ReadLine();
        }

        private static T[] ReadMany<T>()
        {
            return ReadMany<T>(' ');
        }

        private static T[] ReadMany<T>(params char[] sep)
        {
            return sr.ReadLine().Split(sep).Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray();
        }

        private static void Initialise()
        {
            Console.Write("Input file: ");
            string path = (Environment.OSVersion.Platform == PlatformID.Unix ||
                           Environment.OSVersion.Platform == PlatformID.MacOSX) ?
                           Environment.GetEnvironmentVariable("HOME") :
                           Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            // Change this to your preferences.
            sr = new StreamReader(path + "\\Downloads\\" + Console.ReadLine());
            Console.Write("Output file: ");
            // Change this how you prefer it.
            sw = new StreamWriter(path + "\\Desktop\\codejam\\" + Console.ReadLine());
            print = sw.WriteLine;
            print += ConsolePrint;
        }

        private static void ConsolePrint(string format, params object[] args)
        {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(format, args);
            Console.ForegroundColor = prev;
        }

        private static void SolveAllCases(Func<string> solve)
        {
            int cases = Read<int>();
            for (int c = 1; c <= cases; c++)
            {
                print("Case #{0}: {1}", c, solve());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finished!");

            sr.Close();
            sw.Close();

            Console.ReadKey(true);
        }
    }
}
