namespace Network

open CustomRandom
open CustomOS

module Computer = 

    /// <summary>
    /// Computer class
    /// </summary>
    type Computer(os: CustomOS, isInfected: bool, customRandomizer: ICustomRandom) =

        let mutable isInfected = isInfected

        let randomizer = customRandomizer

        let OS = os

        /// <summary>
        /// Is computer infected
        /// </summary>
        member this.IsInfected = isInfected

        /// <summary>
        /// Try to infect the computer
        /// </summary>
        member this.TryToInfect() =
            let probability = randomizer.Random()
            isInfected <- (probability <= OS.CriticalProbability)
        
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        override this.ToString() =
            OS.ToString() + " " + isInfected.ToString()

