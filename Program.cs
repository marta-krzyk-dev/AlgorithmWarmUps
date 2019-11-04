using System;
using System.Collections;

namespace LongestSubstring
{
	class Program
	{
		static void Main(string[] args)
		{
			string inputEven = "xracecarz";// "abrkcbaabcdefghijjxxx";
			string answer = "racecar";
			string resultEven = leecode(inputEven);

			Console.WriteLine($"FInding longest palidrome for len={inputEven.Length}, {inputEven}");
			Console.WriteLine($"Longest palidrome: {resultEven}");
			Console.WriteLine($"Correct?: {resultEven == answer}");

			Console.ReadKey();
		}

		//This algorithm is of linear complexity O(n)
		static int lengthOfLongestSubstring(string input)
		{
			if (input is null)
				return 0;
			if (input.Length < 2)
				return input.Length;

			int longest = 1, current = 1;

			Hashtable hashtable = new Hashtable();
			hashtable.Add(input[0], null);

			for(int i = 1; i < input.Length; ++i)
			{
				if (hashtable.ContainsKey(input[i]))
				{
					if (current > longest)
					{ 
						longest = current; 
						Console.WriteLine("Longest substring found is: " + longest); 
					}

					hashtable.Clear();	//Get ready for finding another substring
					current = 0;		//Flush the counter
				}
				else // Every character is unique so far, keep adding
				{ 
					++current;
					hashtable.Add(input[i], null);
				}
			}

			return longest;
		}

		static string leecode(string s)
		{
				if (s is null || s.Length < 1)
					return string.Empty;

				int start = 0, end = 0;
				for (int i = 0; i < s.Length; i++)
				{
					Console.WriteLine($"i = {i}, start = {start}, end = {end}");

					int len1 = expandAroundCenter(s, i, i);
					int len2 = expandAroundCenter(s, i, i + 1);


					int len = Math.Max(len1, len2);
					Console.WriteLine($"len = {len} > {end-start} ? == {(len > end - start)}");
					if (len > end - start)
					{
						start = i - (len - 1) / 2;
						end = i + len / 2;
					Console.WriteLine($"Assign new start and end...");
				}
				}
				return s.Substring(start, end + 1 - start);
		}

			private static int expandAroundCenter(String s, int left, int right)
			{
				int L = left, R = right;
			
				while (L >= 0 && R < s.Length && s[L] == s[R])
				{
				Console.WriteLine($"Comparing {s[L]} == {s[R]}, expanding..");

				//it's a palidrome, keep going
				L--;
					R++;

				
			}
				//Stopped when it's not a palidrome anymore
			Console.WriteLine($"Return {R} - {L} - 1 = {R - L - 1}");
			return R - L - 1;
			}
	}
}
