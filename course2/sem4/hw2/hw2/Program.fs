(*2.1*)

let count n = 
    let rec recCount n acc = 
        if n = 0 then acc
        else acc * recCount (n / 10) (n % 10)
    recCount n 1

(*2.2*)

let indexOf element list = 
    let rec recIndexOf index list = 
        match list with
        | [] -> -1
        | head :: tail -> if head = element then index
                          else recIndexOf (index + 1) tail
    recIndexOf 0 list

(*2.3*)

let palindrom (x:string) = 
    match x with
    | "" -> true
    | _ -> Seq.forall(fun i -> x.[i] = x.[x.Length - i - 1]) {0..x.Length/2}