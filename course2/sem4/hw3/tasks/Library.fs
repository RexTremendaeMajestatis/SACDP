namespace tasks

module task1 =
    (*3.1.1*)

    let countOddByFold list = 
         List.fold (fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0 list

    (*3.1.2*)

    let countOddByFilter list = 
        list
        |> List.filter (fun x -> x % 2 = 0)
        |> List.length

    (*3.1.3*)

    let countOddByMap list = 
        list
        |> List.map (fun x -> (x + 1) % 2)
        |> List.fold (fun acc x -> x + acc) 0
        