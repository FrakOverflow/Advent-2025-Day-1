namespace Advent_2025_Day_1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Static class for decoding dial rotations into password counts
    /// </summary>
    internal class Decoder
    {
        /// <summary>
        /// Modulus for the dial calculations (number of positons on the dial)
        /// </summary>
        private static int MODULUS = 100;

        /// <summary>
        /// For a given dial position and rotation sequence, get the number of time the dial points to 0
        /// </summary>
        /// <param name="origin">Dial starting position</param>
        /// <param name="rotations">List of rotation codes</param>
        /// <returns>Integer indicating the number of times the dial pointed at 0</returns>
        public static int Decode(int origin, IEnumerable<string> rotations)
        {
            Console.WriteLine($"Origin Position = {origin}");
            var position = origin;
            var password = 0;

            // Increment count if starting position is 0

            // Complete each rotation in sequence, counting each time the dial points to 0
            foreach (var rotation in rotations)
            {
                Console.WriteLine($"----------------------------");
                Console.WriteLine($"Starting Password = {password}");
                Console.WriteLine($"Starting Position = {position}");

                // Count each full rotation as a pass over 0
                var clicks = GetRealRotation(rotation);
                var fullTurns = clicks / MODULUS;
                var remainingClicks = clicks % MODULUS; // C# modulo here because we want true remainder, not modulus
                var destination = AddMod(position, clicks, MODULUS);

                Console.WriteLine($"Rotation = {rotation}");
                Console.WriteLine($"Clicks = {clicks}");
                Console.WriteLine($"Destination = {destination}");
                Console.WriteLine($"Full Turns = {fullTurns}");
                Console.WriteLine($"Remaining Clicks = {remainingClicks}");

                // Each full turn passes over 0 once
                password += Math.Abs(fullTurns);

                // If we pass over 0 in the remaining clicks, but did not start at 0, count an extra pass
                // (if we started at 0 in this iteration, it was already counted in the previous)
                if (position != 0 && ((position + remainingClicks) > 99 || (position + remainingClicks) < 1))
                {
                    Console.WriteLine($"Extra Turn Counted!");
                    password++;
                }

                Console.WriteLine($"Password Count = {password}");

                position = destination;
            }

            // Return the final count
            return password;
        }

        /// <summary>
        /// Get the number of clicks represented by the rotation code, with left turns as negative and right turns as positive
        /// </summary>
        /// <param name="rotation">Rotation code</param>
        /// <returns>Integer indicating the number of clicks the dial will be turned for a given rotation</returns>
        private static int GetRealRotation(string rotation)
        {
            // Determine positive (R) or negative (L) direction and number of clicks
            var direction = rotation[0] == 'L' ? -1 : 1;
            return (int.Parse(rotation[1..])) * direction;
        }

        /// <summary>
        /// Modulo function that only returns positive values
        /// </summary>
        /// <param name="a">dividend</param>
        /// <param name="b">modulus</param>
        /// <returns>Positive result of a mod b</returns>
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        /// <summary>
        /// Add two integers under modulo arithmetic
        /// </summary>
        /// <param name="a">Addend</param>
        /// <param name="b">Addend</param>
        /// <param name="mod">Modulus</param>
        /// <returns>Integer result of modulus additon</returns>
        private static int AddMod(int a, int b, int mod)
        {
            return Mod(a + b, mod);
        }
    }
}
