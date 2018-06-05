namespace Network

module CustomOS = 

    /// <summary>
    /// OS name clss
    /// </summary>
    type OsName = 
        | Windows
        | Linux
        | MacOS
        with

            /// <summary>
            /// Converts the value of this instance to its equivalent string representation
            /// </summary>
            override this.ToString() = 
                match this with
                | Windows -> "Windows"
                | Linux -> "Linux"
                | MacOS -> "MacOS"

    /// <summary>
    /// Custom OS class
    /// </summary>
    type CustomOS(osName: OsName) =

        /// <summary>
        /// Critical probability of infection
        /// </summary>
        member val CriticalProbability = match osName with
                                         | Windows -> 15
                                         | Linux -> 10
                                         | MacOS -> 13
                                         with get
             
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        override this.ToString() = 
            osName.ToString()
