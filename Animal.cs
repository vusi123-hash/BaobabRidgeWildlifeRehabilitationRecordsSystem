using System;

namespace BaobabRidgeWildlifeRehabilitationRecordsSystem
{
    /// <summary>
    /// Represents a single animal record at Baobab Ridge Wildlife Rehabilitation Centre.
    /// </summary>
    public class Animal
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; } = string.Empty;
        public string HousingUnit { get; set; } = string.Empty;

        /// <summary>
        /// Creates a new Animal instance.
        /// </summary>
        public Animal(string id, string name, string species, int age, int recoveryScore, string status, string housingUnit)
        {
            ID = id;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = recoveryScore;
            Status = status;
            HousingUnit = housingUnit;
        }

        /// <summary>
        /// Parameterless constructor required for some binding scenarios.
        /// </summary>
        public Animal() { }

        /// <summary>
        /// Converts the animal into a pipe-delimited line suitable for animals.txt.
        /// </summary>
        public string ToFileLine()
        {
            return $"{ID} | {Name} | {Species} | {Age} | {RecoveryScore} | {Status} | {HousingUnit}";
        }

        /// <summary>
        /// Single classification method that determines Status and Housing Unit from Recovery Score.
        /// Must be used by both Add and Update operations.
        /// </summary>
        /// <param name="score">Recovery score (0-100).</param>
        /// <returns>Tuple of (Status, HousingUnit).</returns>
        public static (string Status, string HousingUnit) Classify(int score)
        {
            // Classification bands as specified in the project brief (no gaps).
            if (score >= 0 && score <= 19)
                return ("Critical", "Intensive Care Unit");
            if (score >= 20 && score <= 39)
                return ("Serious", "High-Dependency Ward");
            if (score >= 40 && score <= 59)
                return ("Stable", "Recovery Ward");
            if (score >= 60 && score <= 79)
                return ("Recovering", "Outdoor Enclosure");
            if (score >= 80 && score <= 100)
                return ("Release-Ready", "Pre-Release Camp");

            // Should never reach here if validation is correct, but keep defensive.
            throw new ArgumentOutOfRangeException(nameof(score), "Recovery Score must be between 0 and 100.");
        }
    }
}
