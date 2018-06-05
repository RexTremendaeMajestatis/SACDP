namespace Network

open CustomRandom
open CustomOS

module Computer = 

    /// <summary>
    /// Computer class
    /// </summary>
    type Computer(os: CustomOS, isInfected: bool, customRandomizer: ICustomRandom) =

        let mutable isInfected = isInfected

        /// <summary>
        /// Is computer infected
        /// </summary>
        member this.IsInfected = isInfected

        /// <summary>
        /// Try to infect the computer
        /// </summary>
        member this.TryToInfect() =
            let probability = customRandomizer.Random()
            isInfected <- (probability <= os.CriticalProbability)
        
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        override this.ToString() =
            os.ToString() + " " + isInfected.ToString()

