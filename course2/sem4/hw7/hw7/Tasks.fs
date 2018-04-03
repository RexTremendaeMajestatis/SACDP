namespace hw7

module task1 = 
    
    type RoundingBuilder(accuracy: int) =
        member this.Bind(x: float, f) =
            f (System.Math.Round(x, accuracy))
        member this.Return(x: float) =
            System.Math.Round(x, accuracy)
