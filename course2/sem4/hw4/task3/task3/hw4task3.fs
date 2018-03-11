namespace task3

module task3 = 
    
    type Term = 
        | Var of char
        | App of Term * Term
        | Abs of char * Term

    let getFV (t: Term) = 
        let rec recGetFV t acc = 
            match t with
            | Var (x) -> x :: acc
            | App (S, T) -> let left = recGetFV S acc
                            let right = recGetFV T acc
                            List.append left right
            | Abs (x, S) -> recGetFV S acc 
                            |> List.filter (fun y -> y <> x)
        recGetFV t []
    
    let rec substitude S x T =
        match S with
        | Var (y) -> if y = x then T
                     else S
        | App (S1, S2) -> App (substitude S1 x T, substitude S2 x T)
        | Abs (y, S) -> let FVS = getFV S
                        let FVT = getFV T
                        match T with
                        | Var (_) when y = x -> S
                        | _ when (not (FVT |> List.contains y)) || (not (FVS |> List.contains x)) -> Abs (y, substitude S x T)
                        | _ -> let alphabet = ['a'..'z']
                               let FVST = List.append FVS FVT
                               let z = alphabet |> List.filter (fun elem -> not (FVST |> List.contains elem)) |> List.head
                               Abs (z, substitude (substitude S y (Var (z))) x T)

    let rec betaReduction (t: Term) =
        match t with
        | Var (x) -> Var (x)
        | App (Abs (x, S), T) -> betaReduction (substitude S x T)
        | App (S1, S2) -> App (betaReduction S1, betaReduction S2)
        | Abs (x, T) -> Abs(x, betaReduction T)
