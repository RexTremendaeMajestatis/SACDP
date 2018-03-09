namespace task3

module task3 = 
    
    type Term = 
        | Var of char
        | App of Term * Term
        | Abs of char * Term

    // Get list of free variables in term
    let getFV (t: Term) = 
        let rec recGetFV t acc = 
            match t with
            | Var(x) -> x :: acc
            | App(S, T) -> let left = recGetFV S acc
                           let right = recGetFV T acc
                           List.append left right
            | Abs(x, S) -> recGetFV S acc 
                           |> List.filter (fun y -> y <> x)
        recGetFV t []
    
    // S[x := T]
    let rec substitude S x T =
        match S with
        | Var(y) -> if y = x then T
                    else S
        | App(S1, S2) -> App(substitude S1 x T, substitude S2 x T)
        | Abs(y, S) -> match T with
                       | Var(_) when y = x -> S
                       | _ when (not (getFV T |> List.contains y)) || (not (getFV S |> List.contains x)) -> Abs(y, substitude S x T)
                       | _ -> (*OOSTAL POMIRAU*)