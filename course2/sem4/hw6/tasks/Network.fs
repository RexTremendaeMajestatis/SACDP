namespace Network

open Computer

module Network = 
        
    /// <summary>
    /// Network class
    /// </summary>
    type Network(computers: list<Computer>, matrix: list<list<bool>>) = 

        let mutable infectedList = List.Empty
        let refreshInfected (infectedList: list<int>) (i: int) = 
            if (computers.[i].IsInfected) then i :: infectedList else infectedList
        
        do
            for i in [0..computers.Length - 1] do
                infectedList <- refreshInfected infectedList i

        let step() = 
            for i in [0..infectedList.Length - 1] do
                for j in [0..computers.Length - 1] do
                    if (not computers.[j].IsInfected && matrix.[infectedList.[i]].[j]) 
                    then computers.[j].TryToInfect()
            for k in [0..computers.Length - 1] do
                infectedList <- refreshInfected infectedList k

        let uninfected() = 
            let rec uninfectedRec (computersList: list<Computer>) (i: int) = 
                match computersList with
                | [] -> i
                | head :: tail -> if not head.IsInfected 
                                  then uninfectedRec tail (i + 1)
                                  else uninfectedRec tail i
            uninfectedRec computers 0

        let state() = 
            for i in [0..computers.Length - 1] do
                if computers.[i].IsInfected then printf "%d) Infected\n" (i + 1)
            printf "\n"

        member this.Step() = 
            step()

        /// <summary>
        /// Let the plague to spread
        /// </summary>
        member this.Play() = 
            while (uninfected() <> 0) do
                step()
                state()

        /// <summary>
        /// Amount of uninfected computers in the network
        /// </summary>
        member this.Uninfected = uninfected()
