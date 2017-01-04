#define CodeForces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CodingChallenge
{
	// Test
	public class Program
	{




#if CodeForces
		private static object solve()
		{
			return null;
		}
#endif




#if GoogleCodeJam
		private static string solveCase()
		{
			return "";
		}
#endif





		private static Queue<string> testqueue = new Queue<string>(@"

1 1


".Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));



// *********************** HERE BE BOILERPLATE *********************** //


#region input
		private static void Read<T>(out T t)
		{
			t = Read<T>();
		}

		private static void Read<T, S>(out T t, out S s)
		{
			string[] vals = ReadMany<string>();
			t = (T)Convert.ChangeType(vals[0], typeof(T));
			s = (S)Convert.ChangeType(vals[1], typeof(S));
		}

		private static void Read<T, S, R>(out T t, out S s, out R r)
		{
			string[] vals = ReadMany<string>();
			t = (T)Convert.ChangeType(vals[0], typeof(T));
			s = (S)Convert.ChangeType(vals[1], typeof(S));
			r = (R)Convert.ChangeType(vals[2], typeof(R));
		}

		private static void Read<T, S, R, A>(out T t, out S s, out R r, out A a)
		{
			string[] vals = ReadMany<string>();
			t = (T)Convert.ChangeType(vals[0], typeof(T));
			s = (S)Convert.ChangeType(vals[1], typeof(S));
			r = (R)Convert.ChangeType(vals[2], typeof(R));
			a = (A)Convert.ChangeType(vals[3], typeof(A));
		}

		private static void Read<T, S, R, A, B>(out T t, out S s, out R r, out A a, out B b)
		{
			string[] vals = ReadMany<string>();
			t = (T)Convert.ChangeType(vals[0], typeof(T));
			s = (S)Convert.ChangeType(vals[1], typeof(S));
			r = (R)Convert.ChangeType(vals[2], typeof(R));
			a = (A)Convert.ChangeType(vals[3], typeof(A));
			b = (B)Convert.ChangeType(vals[4], typeof(B));
		}

		private static T Read<T>()
		{
			return (T)Convert.ChangeType(Read(), typeof(T));
		}

		private static T[] ReadMany<T>(char[] sep = null)
		{
			return Read<string>().Split(sep ?? new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray();
		}

		private static T[][] ReadField<T>(int len, char[] sep = null)
		{
			T[][] result = new T[len][];
			for (int i = 0; i < len; i++)
			{
				result[i] = ReadMany<T>(sep);
			}
			return result;
		}
#endregion

#region dynamic programming
		private static Func<A, B> DP<A, B>(Func<A, Func<A, B>, B> f)
		{
			Dictionary<A, B> cache = new Dictionary<A, B>();
			Func<A, B> res = null;
			res = a => 
			{
				if (!cache.ContainsKey(a))
					cache.Add(a, f(a, res));
				return cache[a];
			};
			return res;
		}

		private static Func<A, B, C> DP<A, B, C>(Func<A, B, Func<A, B, C>, C> f)
		{
			Dictionary<Tuple<A, B>, C> cache = new Dictionary<Tuple<A, B>, C>();
			Func<A, B, C> res = null;
			res = (a, b) => 
			{
				Tuple<A, B> t = Tuple.Create(a, b);
				if (!cache.ContainsKey(t))
					cache.Add(t, f(a, b, res));
				return cache[t];
			};
			return res;
		}

		private static Func<A, B, C, D> DP<A, B, C, D>(Func<A, B, C, Func<A, B, C, D>, D> f)
		{
			Dictionary<Tuple<A, B, C>, D> cache = new Dictionary<Tuple<A, B, C>, D>();
			Func<A, B, C, D> res = null;
			res = (a, b, c) => 
			{
				Tuple<A, B, C> t = Tuple.Create(a, b, c);
				if (!cache.ContainsKey(t))
					cache.Add(t, f(a, b, c, res));
				return cache[t];
			};
			return res;
		}

		private static Func<A, B, C, D, E> DP<A, B, C, D, E>(Func<A, B, C, D, Func<A, B, C, D, E>, E> f)
		{
			Dictionary<Tuple<A, B, C, D>, E> cache = new Dictionary<Tuple<A, B, C, D>, E>();
			Func<A, B, C, D, E> res = null;
			res = (a, b, c, d) => 
			{
				Tuple<A, B, C, D> t = Tuple.Create(a, b, c, d);
				if (!cache.ContainsKey(t))
					cache.Add(t, f(a, b, c, d, res));
				return cache[t];
			};
			return res;
		}
#endregion

#region utils

		private static IEnumerable<int> Range(int start, int stop, int step)
		{
			for (int l = start; start <= stop; l+=step)
				yield return l;
		}

		private static IEnumerable<long> Range(long start, long stop, long step)
		{
			for (long l = start; start <= stop; l+=step)
				yield return l;
		}

		public static T[][] NewArray<T>(int x, int y)
		{
			T[][] res = new T[x][];
			for (int i = 0; i < x; i++)
				res[i] = new T[y];
			return res;
		}

		public static T[][][] NewArray<T>(int x, int y, int z)
		{
			T[][][] res = new T[x][][];
			for (int i = 0; i < x; i++)
			{
				res[i] = new T[y][];
				for (int j = 0; j < y; j++)
					res[i][j] = new T[z];
			}
			return res;
		}

#endregion

#if GoogleCodeJam
		private static StreamReader inf;
		private static StreamReader outf;

		private delegate void o(string format, params object[] args);
		private static o Output;

		private static void Init()
		{
			const string downloads = "/home/ben/downloads/";
			Console.Write($"Download folder prefix: {downloads}\nEnter file to read from: ");
			StreamReader inf = new StreamReader(Console.ReadLine());
			Console.Write("Enter file to write to (in current directory): ");
			StreamWriter outf = new StreamWriter(Console.ReadLine());
			Output += highlightedPrinting;
#if !DEBUG
			Output += outf.WriteLine;
#endif
		}

		private static void highlightedPrinting(string format, params object[] args)
		{
			ConsoleColor c = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(format, args);
			Console.ForegroundColor = prev;
		}

		public static void Main(string[] args)
		{
			Init();
			int n = Read<int>();
			for (int i = 1; i <= n; i++)
				Output($"Case #{i}: {solveCase()}");
			inf.Close();
			outf.Close();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Done!");
		}

		private static string Read()
		{
#if DEBUG
			return testqueue.Dequeue();
#else
			return inf.ReadLine();
#endif
		}
#endif

#if CodeForces
		private static string show(object o)
		{
			IEnumerable e = o as IEnumerable;
			if (e != null && !(e is string))
			{
				// Don't do this with nested arrays
				return string.Join(" ", e.OfType<object>().Select(show));
			}
			else if (o is double)
			{
				return ((double)o).ToString("0.000000000", CultureInfo.InvariantCulture);
			}
			else
			{
				return o.ToString();
			}
		}

		public static void Main(string[] args)
		{
#if DEBUG
			Stopwatch sw = new Stopwatch();
			sw.Start();
#endif
			object res = solve();
			string s = show(res);
			if (!string.IsNullOrEmpty(s))
				Console.WriteLine(s);
#if DEBUG
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
#endif
		}

		private static string Read()
		{
#if DEBUG
			return testqueue.Dequeue();
#else
			return Console.ReadLine();
#endif
		}
#endif
	}

	static class Extensions
	{
		public static IEnumerable<T> Times<T>(this int n, Func<T> f)
		{
			for (int i = 0; i < n; i++)
				yield return f();
		}

		public static IEnumerable<T> Times<T>(this int n, Func<int, T> f)
		{
			for (int i = 0; i < n; i++)
				yield return f(i);
		}


#region binary search (SearchBinary)

		public static int SearchBinary<T>(this IList<T> array, T elem, bool highest = false) where T : IComparable<T>
		{
			return array.SearchBinary(elem, 0, array.Count - 1, highest);
		}

		public static int SearchBinary<T>(this IList<T> array, T elem, int low, int high, bool getHighest) where T : IComparable<T>
		{
			while (low <= high) {
				int m = (low + high) / 2;
				if (elem.Equals(array[m]))
				{
					while (m >= 0 && m < array.Count && elem.Equals(array[m])) m += getHighest ? 1 : -1;
					return m;
				}
				if (elem.CompareTo(array[m]) < 0) high = m - 1;
				else low = m + 1;
			}
			return -1;
		}

		public static int SearchBinary<T>(this Func<int, T> map, T elem, int low, int high, bool highest = false) where T : IComparable<T>
		{
			while (low <= high)
			{
				int m = (low + high) / 2;
				T k = map(m);
				if (elem.Equals(k))
				{
					// use pre-in/decrement because of oder of operations
					while (elem.Equals(k)) k = map(highest ? ++m : --m);
					return m;
				}
				if (elem.CompareTo(k) < 0) high = m - 1;
				else low = m + 1;
			}
			return int.MinValue;
		}

#endregion

#region cartesian product

		public static IEnumerable<C> Cartesian<A, B, C>(this IEnumerable<A> a, IEnumerable<B> b, Func<A, B, C> f)
		{
			return a.SelectMany(aa => b.Select(bb => f(aa, bb)));
		}

		public static IEnumerable<Tuple<A, B>> Cartesian<A, B>(this IEnumerable<A> a, IEnumerable<B> b)
		{
			return a.Cartesian(b, Tuple.Create);
		}

		public static IEnumerable<Tuple<A, B, C>> Cartesian<A, B, C>(this IEnumerable<Tuple<A, B>> ab, IEnumerable<C> c)
		{
			return ab.Cartesian(c, (t, cc) => Tuple.Create(t.Item1, t.Item2, cc));
		}

		public static IEnumerable<Tuple<A, B, C, D>> Cartesian<A, B, C, D>(this IEnumerable<Tuple<A, B, C>> abc, IEnumerable<D> d)
		{
			return abc.Cartesian(d, (t, dd) => Tuple.Create(t.Item1, t.Item2, t.Item3, dd));
		}

		public static IEnumerable<Tuple<A, B, C, D, E>> Cartesian<A, B, C, D, E>(this IEnumerable<Tuple<A, B, C, D>> abcd, IEnumerable<E> e)
		{
			return abcd.Cartesian(e, (t, ee) => Tuple.Create(t.Item1, t.Item2, t.Item3, t.Item4, ee));
		}

#endregion

#region haskell list funcs

		// Haskell's sequence
		public static IEnumerable<IEnumerable<T>> Sequence<T>(this IEnumerable<IEnumerable<T>> seq)
		{
			IEnumerable<T>[] arr = seq as IEnumerable<T>[] ?? seq.ToArray();
			IEnumerable<IEnumerable<T>> res = arr.First().Select(Pure);
			foreach (IEnumerable<T> sequence in seq.Skip(1))
			{
				res = res.Cartesian(sequence, (cur, s) => cur.Concat(Pure(s)));
			}
			return res;
		}

		// Haskell's replicateM (generate all words from an alphabet)
		public static IEnumerable<IEnumerable<T>> ReplicateM<T>(this IEnumerable<T> en, int num)
		{
			return Enumerable.Repeat(en, num).Sequence();
		}

		public static IEnumerable<T> Demask<T>(this IEnumerable<Tuple<T, bool>> en)
		{
			return en.Where(t => t.Item2).Select(t => t.Item1);
		}

		public static IEnumerable<IEnumerable<T>> Powerset<T>(IEnumerable<T> en)
		{
			T[] inp = en.ToArray();
			foreach (IEnumerable<bool> config in new[] { true, false }.ReplicateM(inp.Length))
			{
				yield return inp.Zip(config, Tuple.Create).Demask();
			}
		}

#endregion

#region utils

		private static IEnumerable<T> Pure<T>(T item)
		{
			yield return item;
		}

		private static T Id<T>(T t)
		{
			return t;
		}

#endregion

#region reshaping
		public static T[][] Reshape<T>(this IEnumerable<T> seq, int x, int y)
		{
			int i = 0, j = 0;
			T[][] res = Program.NewArray<T>(x, y);
			while (true) {
				foreach(T item in seq) {
					res[i][j] = item;
					j++;
					if (j == y) {
						i++;
						j = 0;
						if (i == x)
							break;
					}
				}
				if (i == x)
					break;
			}
			return res;
		}

		public static T[][][] Reshape<T>(this IEnumerable<T> seq, int x, int y, int z)
		{
			int i = 0, j = 0, k = 0;
			T[][][] res = Program.NewArray<T>(x, y, z);
			while (true) {
				foreach(T item in seq) {
					res[i][j][k] = item;
					k++;
					if (k == z) {
						j++;
						k = 0;
						if (j == y) {
							i++;
							j = 0;
							if (i == x)
								break;
						}
					}
				}
				if (i == x)
					break;
			}
			return res;
		}
#endregion

	}
}
