namespace Network

module CustomOS = 

    /// <summary>
    /// Custom OS class
    /// </summary>
    /// <param name="name">Name of OS</param>
    type CustomOS(osName: string) =

        let name = osName

        /// <summary>
        /// Critical probability of infection
        /// </summary>
        member val CriticalProbability = match name with
                                         | "Windows" -> 15
                                         | "Linux" -> 10
                                         | "MacOS" -> 13
                                         | _ -> 99
                                         with get
             
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        override this.ToString() = 
            name