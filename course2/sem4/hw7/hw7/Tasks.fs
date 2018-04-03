namespace hw7

module task1 = 
    
    type RoundingBuilder(accuracy: int) =
        member this.Bind(x: float, f) =
            f (System.Math.Round(x, accuracy))
        member this.Return(x: float) =
            System.Math.Round(x, accuracy)

module task2 = 
    open System

    let toInt str =
        match System.Int32.TryParse(str) with
        | (true,int) -> Some(int)
        | _ -> None

    type CalculatingBuilder() = 
        member this.Bind(x, f) = 
            match toInt x with
            | None -> None
            | Some(x) -> f x
        member this.Return(x) = 
            Some(x)
