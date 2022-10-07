namespace CSharpPracticeApp
{
    using System.Collections.Generic;

    /* 
    input (nums): [2,7,11,15], target: 9
    output: [0,1] bc 2 + 7 = 9
    */
    public class Class1
    {
        static void Main(string[] args)
        {
            int[] twoSumArr = { 2, 7, 11, 15 };
            int[] twoSumResult = Class1.TwoSum(twoSumArr, 9);
            foreach(int i in twoSumResult)
            {
                Console.WriteLine(i);
            }

            int[] uniqueOccurrencesArr = { 1, 2, 2, 1, 1, 3 };
            Console.WriteLine(UniqueOccurrences(uniqueOccurrencesArr));
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
    }
}