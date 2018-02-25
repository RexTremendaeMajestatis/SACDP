(*2.1*)

let count n = 
    let rec recCount n b = 
        if n % 10 = n then n * b
        else recCount (n / 10) (b * (n % 10))

    recCount n 1

(*2.2*)

let indexOf element list = 
    let rec recIndexOf index list = 
        match list with
        | [] -> None
        | head :: tail -> 
            if head = element then Some(index)
            else recIndexOf (index + 1) tail

    recIndexOf 0 list

(*2.3*)

let palindrom (x:string) = 
    match x with
    | "" -> true
    | _  -> Seq.forall(fun i -> x.[i] = x.[x.Length - i - 1]) {0..x.Length / 2}

(*2.4*)

let rec mergeSort list =

    let split list = 
        let rec recSplit list (left, right) = 
            match list with 
            | [] -> (left, right)
            | [x] -> (left, x :: right)
            | x :: y :: tail -> recSplit tail (x :: left, y :: right)

        recSplit list ([], [])

    let rec merge2 (left, right) = 
        match left, right with
        | ([], list ) | ( list, []) -> list
        | (leftHead :: leftTail, rightHead :: rightTail) -> 
            if leftHead > rightHead then rightHead :: merge2 (rightTail, left)
            else leftHead :: merge2 (leftTail, right)
    
    match list with
    | [] -> []
    | [x] -> list
    | _ -> 
        let left, right = split list
        merge2 ((mergeSort left), (mergeSort right))

printf "%A" <| mergeSort [1; 4; 2]