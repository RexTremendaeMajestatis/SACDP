let reverse list = 
    match list with
    | [] -> list
    |_ -> List.fold(fun tail head -> head :: tail) [] list

let list = [1..10]

printf "%A" <| reverse list