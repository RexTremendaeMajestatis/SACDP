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
            | App (s, t) -> let left = recGetFV s acc
                            let right = recGetFV t acc
                            List.append left right
            | Abs (x, s) -> recGetFV s acc 
                            |> List.filter (fun y -> y <> x)
        recGetFV t []
    
    let rec substitute s x t =
        match s with
        | Var (y) -> if y = x then t
                     else s
        | App (s1, s2) -> App (substitute s1 x t, substitute s2 x t)
        | Abs (y, s) -> let fvs = getFV s
                        let fvt = getFV t
                        match t with
                        | Var (_) when y = x -> s
                        | _ when (not (fvt |> List.contains y)) || (not (fvs |> List.contains x)) -> Abs (y, substitute s x t)
                        | _ -> let alphabet = ['a'..'z']
                               let fvst = List.append fvs fvt
                               let z = alphabet |> List.filter (fun elem -> not (fvst |> List.contains elem)) |> List.head
                               Abs (z, substitute (substitute s y (Var (z))) x t)

    let rec betaReduction (t: Term) =
        match t with
        | Var (x) -> Var (x)
        | App (Abs (x, S), t) -> betaReduction (substitute S x t)
        | App (s1, s2) -> App (betaReduction s1, betaReduction s2)
        | Abs (x, t) -> Abs(x, betaReduction t)
