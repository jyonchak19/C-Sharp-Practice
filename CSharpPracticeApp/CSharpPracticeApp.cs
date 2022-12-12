namespace CSharpPracticeApp
{
    using System.Collections.Generic;

    /* 
    input (nums): [2,7,11,15], target: 9
    output: [0,1] bc 2 + 7 = 9
    */
    public class CSharpPracticeProblems
    {
        static void Main(string[] args)
        {
            // SOME DIFFERENCES OF C SHARP VS JAVA

            // initialization, ex hashmap/dictionary literals
            var dict = new Dictionary<string, int> {
                {"rafi", 1231},
                {"jacob", 424324},
            };
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement))
                    return new int[] { dict[complement], i };

                dict[nums[i]] = i; // in Java: map.put(nums[i], i);
            }

            return new int[] { };
        }

        public static bool UniqueOccurrences(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = 1;
                else
                    dict[nums[i]]++;
            }

            var set = new HashSet<int>();

            foreach(int numOccurrences in dict.Values)
            {
                if (!set.Contains(numOccurrences))
                    set.Add(numOccurrences);
                else
                    return false;
            }

            return true;
        }

        public static Tuple<string, int> TupleTestMethod() {
            return Tuple.Create("Steve", 1);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}