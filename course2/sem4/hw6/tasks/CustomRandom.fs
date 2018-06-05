namespace Network

module CustomRandom = 

    /// <summary>
    /// Interface for custom random
    /// </summary>
    type ICustomRandom = 
        abstract member Random: unit -> int
    
    /// <summary>
    /// Custom rando class
    /// </summary>
    type CustomRandom() = 
        interface ICustomRandom with
            member this.Random() = System.Random().Next(100)
