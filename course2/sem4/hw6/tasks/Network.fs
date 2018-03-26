namespace tasks

open System
open System.Collections
open System.Collections.Generic
open System.Linq.Expressions

module task2 = 
        
    type ICustomRandom =
        abstract member Random: unit -> int

    type CustomRandom() = 
        interface ICustomRandom with
            member this.Random() = System.Random().Next(100)

    type Computer(randomizer: ICustomRandom, os: string) =
        let mutable isInfected = false

        let randomizer = randomizer

        let os = os

        let CriticalProbability = 
            match os with
            | "Windows" -> 70
            | "Ubuntu" -> 30
            | "MacOs" -> 15
            | _ -> failwith "Wrong OS"

        member this.Os
            with get() = os

        member this.IsInfected 
            with get() = isInfected
            and set x = isInfected <- x 
        
        member this.TryToInfect = 
            let probability = randomizer.Random()
            isInfected <- (probability <= CriticalProbability)

        member this.Infect = 
            isInfected <- true
        
        override this.ToString() = 
            os + " | " + isInfected.ToString()
            
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
