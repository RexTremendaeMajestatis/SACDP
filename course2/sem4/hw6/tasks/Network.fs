namespace Network

module Network = 
    open Network.Computer

    type Network(computers: list<Computer>, matrix: list<list<bool>>) = 
        let matrix = matrix
        let mutable computers = computers
        let mutable infected = List.Empty
        let updateInfected (list : list<int>) (i : int) =
            if (computers.[i].IsInfected)
            then (i :: list)
            else list
        do
            for i in [0..computers.Length - 1] do
                infected <- updateInfected infected i
        new() = 
            let computer = [Computer(CustomRandom(), "Windows")]
            let matrix = [[true]]
            Network(computer, matrix)

        member this.Step = 
            for i in [0..infected.Length - 1] do
                for j in [0..computers.Length - 1] do
                    if (not computers.[j].IsInfected && matrix.[infected.[i]].[j]) then computers.[j].TryToInfect
            for k in [0..computers.Length - 1] do
            infected <- updateInfected infected k

        member this.Play = 
            while (this.Uninfected <> 0) do 
                this.Step
                this.State

        member this.Uninfected = 
            let rec uninfectedRec (counter: int) (computers: list<Computer>) = 
                match computers with
                | [] -> counter
                | head :: tail -> if head.IsInfected then uninfectedRec counter tail
                                  else uninfectedRec (counter + 1) tail
            uninfectedRec 0 computers

        member n.State =
            for i in [0..computers.Length - 1] do
                if (computers.[i].IsInfected) then
                    printfn "Infected  %d" (i + 1)
            printf "\n"
    
        override this.ToString() = 
            computers.ToString()
