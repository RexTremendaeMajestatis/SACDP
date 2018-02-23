(*2.1*)

let count2 n = 
    let rec recCount2 n b = 
        if n < 10 then n * b
        else recCount2 (n / 10) (b * (n % 10))
    recCount2 n 1

(*2.2*)

let indexOf element list = 
    let rec recIndexOf index list = 
        match list with
        | [] -> -1
        | head :: tail -> if head = element then index
                          else recIndexOf (index + 1) tail
    if recIndexOf 0 list = -1 then None
    else Some(recIndexOf 0 list)

(*2.3*)

let palindrom (x:string) = 
    match x with
    | "" -> true
    | _ -> Seq.forall(fun i -> x.[i] = x.[x.Length - i - 1]) {0..x.Length / 2}

(*2.4*)

