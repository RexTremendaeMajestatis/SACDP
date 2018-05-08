namespace Network

module Computer = 

    type ICustomRandom =
        abstract member Random: unit -> int

    type CustomRandom() = 
        interface ICustomRandom with
            member this.Random() = System.Random().Next(100)

    type Computer(randomizer: ICustomRandom, os: string) =
        let mutable isInfected = false

        let os = os

        let criticalProbability = 
            match os with
            | "Windows" -> 70
            | "Ubuntu" -> 30
            | "MacOs" -> 15
            | _ -> failwith "Wrong OS"

        member this.Os
            with get() = os

        member val IsInfected = isInfected with get, set
        
        member this.TryToInfect = 
            let probability = randomizer.Random()
            isInfected <- (probability <= criticalProbability)

        member this.Infect = 
            isInfected <- true
        
        override this.ToString() = 
            os + " | " + isInfected.ToString()