using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums) // Method to find missing numbers in the array
        {
            try
            {
                HashSet<int> numSet = new HashSet<int>(nums); // Store the elements of the array in a HashSet for quick lookup
                List<int> missingNumbers = new List<int>(); // Initialize a list to store missing numbers
                for (int i = 1; i <= nums.Length; i++) // Loop through numbers from 1 to the length of the array
                {
                    if (!numSet.Contains(i)) // If the current number is not in the HashSet
                    {
                        missingNumbers.Add(i); // Add it to the missing numbers list
                    }
                }
                return missingNumbers; // Return the list of missing numbers
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 1):
        /*
        The new approach using a HashSet demonstrated the trade-off between space and time complexity.
        While it uses more memory, it provides O(1) lookup time, making the overall solution more efficient for larger inputs.
        This change highlighted the importance of choosing appropriate data structures based on the problem requirements.
        */

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums) // Method to sort array by parity (even numbers first)
        {
            try
            {
                List<int> even = new List<int>(); // Initialize a list for even numbers
                List<int> odd = new List<int>(); // Initialize a list for odd numbers

                foreach (int num in nums) // Loop through each number in the array
                {
                    if (num % 2 == 0) // If the number is even
                    {
                        even.Add(num); // Add it to the even list
                    }
                    else // If the number is odd
                    {
                        odd.Add(num); // Add it to the odd list
                    }
                }

                even.AddRange(odd); // Combine the even and odd lists (even numbers first)
                return even.ToArray(); // Return the combined list as an array
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 2):
        /*
        This corrected approach to sorting array by parity uses two separate lists to maintain the order of both even and odd numbers.
        It demonstrates the importance of carefully considering the problem requirements and testing the solution with various inputs.
        The use of List<T> allows for dynamic sizing and easy combination of the results, showcasing the benefits of using appropriate data structures.
        This solution has a time complexity of O(n) and space complexity of O(n), prioritizing correctness and readability over minimal space usage.
        It reinforces the idea that sometimes, the simplest approach can be the most effective and least error-prone.
        */

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target) // Method to find two numbers that add up to a target
        {
            try
            {
                for (int i = 0; i < nums.Length; i++) // Loop through the array
                {
                    for (int j = i + 1; j < nums.Length; j++) // Loop through the remaining elements
                    {
                        if (nums[i] + nums[j] == target) // If two numbers add up to the target
                        {
                            return new int[] { i, j }; // Return their indices
                        }
                    }
                }
                return new int[0]; // Return an empty array if no solution is found
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 3):
        /*
        Implementing the Two Sum problem with a brute-force approach provided a clear contrast to the more efficient hash map solution.
        It emphasized the importance of analyzing time complexity, as this O(n^2) solution would be significantly slower for large inputs.
        This exercise reinforced the value of considering multiple approaches and their trade-offs when solving algorithmic problems.
        */

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums) // Method to find the maximum product of three numbers
        {
            try
            {
                int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue; // Initialize the three largest numbers
                int min1 = int.MaxValue, min2 = int.MaxValue; // Initialize the two smallest numbers

                foreach (int num in nums) // Loop through the array
                {
                    if (num > max1) // If the current number is larger than the largest found so far
                    {
                        max3 = max2; // Update the third largest
                        max2 = max1; // Update the second largest
                        max1 = num; // Update the largest
                    }
                    else if (num > max2) // If the current number is larger than the second largest
                    {
                        max3 = max2; // Update the third largest
                        max2 = num; // Update the second largest
                    }
                    else if (num > max3) // If the current number is larger than the third largest
                    {
                        max3 = num; // Update the third largest
                    }

                    if (num < min1) // If the current number is smaller than the smallest found so far
                    {
                        min2 = min1; // Update the second smallest
                        min1 = num; // Update the smallest
                    }
                    else if (num < min2) // If the current number is smaller than the second smallest
                    {
                        min2 = num; // Update the second smallest
                    }
                }

                return Math.Max(max1 * max2 * max3, max1 * min1 * min2); // Return the maximum product
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 4):
        /*
        The single-pass approach to find the maximum product of three numbers was an interesting exercise in maintaining multiple variables.
        It demonstrated how to efficiently track both the largest and smallest numbers simultaneously, reducing time complexity to O(n).
        This method highlighted the importance of considering edge cases, such as negative numbers, in mathematical problems.
        */

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber) // Method to convert a decimal number to binary
        {
            try
            {
                if (decimalNumber == 0) // If the decimal number is 0
                    return "0"; // Return "0"

                List<int> binaryDigits = new List<int>(); // Initialize a list to store binary digits
                int number = Math.Abs(decimalNumber); // Get the absolute value of the decimal number

                while (number > 0) // Loop until the number is reduced to 0
                {
                    binaryDigits.Add(number % 2); // Add the remainder (binary digit) to the list
                    number /= 2; // Divide the number by 2
                }

                binaryDigits.Reverse(); // Reverse the list to get the correct binary order
                string binaryString = string.Join("", binaryDigits); // Join the binary digits into a string

                return decimalNumber < 0 ? "-" + binaryString : binaryString; // Return binary with a negative sign if the input was negative
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 5):
        /*
        This manual implementation of decimal to binary conversion provides insight into the underlying algorithm.
        It demonstrates the process of repeatedly dividing by 2 and collecting remainders, which is the core of the conversion.
        Using a List<int> allows for easy collection and manipulation of binary digits, showcasing how data structures can simplify complex operations.
        The solution handles edge cases like zero and negative numbers, emphasizing the importance of considering all possible inputs.
        This approach, while less concise than using built-in methods, offers educational value and potentially more flexibility for custom requirements.
        */

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums) // Method to find the minimum element in a rotated sorted array
        {
            try
            {
                if (nums.Length == 1) return nums[0]; // If the array has only one element, return it
                for (int i = 1; i < nums.Length; i++) // Loop through the array
                {
                    if (nums[i] < nums[i - 1]) // If the current element is smaller than the previous one
                    {
                        return nums[i]; // Return the current element (minimum)
                    }
                }
                return nums[0]; // If no smaller element is found, return the first element
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 6):
        /*
        The linear search approach to find the minimum in a rotated sorted array provided a straightforward solution at the cost of efficiency.
        While simpler to implement, it highlighted the trade-off between code simplicity and time complexity, as this method is O(n) compared to the O(log n) of binary search.
        This exercise reinforced the importance of considering the problem constraints and choosing an appropriate algorithm based on input size and performance requirements.
        */

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x) // Method to check if a number is a palindrome
        {
            try
            {
                if (x < 0) return false; // If the number is negative, it's not a palindrome
                string numStr = x.ToString(); // Convert the number to a string
                int left = 0, right = numStr.Length - 1; // Initialize two pointers for comparison

                while (left < right) // Loop while the left pointer is less than the right pointer
                {
                    if (numStr[left] != numStr[right]) return false; // If characters at the pointers don't match, it's not a palindrome
                    left++; // Move the left pointer to the right
                    right--; // Move the right pointer to the left
                }
                return true; // If the loop completes, the number is a palindrome
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 7):
        /*
        The string-based approach to check for palindrome numbers offered a different perspective on the problem.
        While it introduces the overhead of string conversion, it provides a more intuitive solution that's easier to read and understand.
        This method emphasized how different data types (in this case, strings vs. integers) can lead to varied problem-solving approaches, each with its own advantages.
        */

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n) // Method to find the nth Fibonacci number
        {
            try
            {
                if (n <= 1) return n; // Return n if it's 0 or 1 (base cases)
                int prev = 0, current = 1; // Initialize the first two Fibonacci numbers

                for (int i = 2; i <= n; i++) // Loop from 2 to n
                {
                    int temp = current; // Temporarily store the current value
                    current += prev; // Update current with the sum of the previous two values
                    prev = temp; // Update previous value
                }
                return current; // Return the nth Fibonacci number
            }
            catch (Exception ex) // Catch any exceptions that occur
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); // Print the error message
                throw; // Re-throw the exception
            }
        }

        // Self-reflection (Question 8):
        /*
        The iterative approach to calculating Fibonacci numbers demonstrated a significant improvement in time complexity compared to the recursive method.
        By using variables to keep track of previous values, we avoided the exponential time complexity of naive recursion.
        This exercise highlighted the importance of considering both time and space complexity when dealing with sequence-based problems, and how iterative solutions can often be more efficient than their recursive counterparts.
        */
    }
}