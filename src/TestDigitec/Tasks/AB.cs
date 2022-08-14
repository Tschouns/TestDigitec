using System;

namespace Tasks
{
    /// <summary>
    /// Implements task 1 from the test: "AB" strings...
    /// </summary>
    public class AB
    {
        /// <summary>
        /// Calculates the minimum number of A's and B's which would have to be deleted, as specified by task 1.
        /// See task 1 :)
        /// </summary>
        /// <param name="abString">
        /// The A/B string
        /// </param>
        /// <returns>
        /// The minimum required number of delete actions
        /// </returns>
        public int CalcNumberOfRequiredDeleteActions(string abString)
        {
            if (abString == null)
            {
                throw new ArgumentNullException(nameof(abString));
            }

            if (abString.Length == 0)
            {
                return 0;
            }

            // Let's determine the number of delete actions required for each possible "cut" (index to divide
            // the string into an A and B sequence).
            var requiredActionsByCutIndex = new int[abString.Length];

            // Forward-iterate and determine number of B's we'd have to delete from the A sequence.
            // (Also, simultaneously check for illegal characters.)
            var numberOfBs = 0;
            for (var cutIndex = 0; cutIndex < abString.Length; cutIndex++)
            {
                requiredActionsByCutIndex[cutIndex] = numberOfBs;

                // Count B's.
                if (abString[cutIndex] == 'B')
                {
                    numberOfBs++;
                }

                // Let's also check for illegal characters while iterating.
                if (abString[cutIndex] != 'A' &&
                    abString[cutIndex] != 'B')
                {
                    throw new ArgumentException($"The string contains an illegal character '{abString[cutIndex]}' at index {cutIndex}.");
                }
            }

            var minActionsRequired = abString.Length;

            // Reverse-iterate and determine (and add) the number of A's we'd have to delete from the B sequence.
            // (Also, simultaneously determine the best variant.)
            var numberOfAs = 0;
            for (var cutIndex = abString.Length - 1; cutIndex >= 0; cutIndex--)
            {
                requiredActionsByCutIndex[cutIndex] += numberOfAs;

                // Let's determine the best variant on the fly.
                if (requiredActionsByCutIndex[cutIndex] < minActionsRequired)
                {
                    minActionsRequired = requiredActionsByCutIndex[cutIndex];
                }

                // Count A's.
                if (abString[cutIndex] == 'A')
                {
                    numberOfAs++;
                }
            }

            return minActionsRequired;
        }
    }
}
