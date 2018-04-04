namespace tasks

module task1 = 
    (*empty string - correct brackets sequence*)
    (*sequence without brackets - correct brackets sequence*)
    let check (s: string) =
        let list = (s.ToCharArray()) |> List.ofArray

        let checker head (buffer: char list) = 
            match head with
            | ')' -> buffer.Head = '('
            | ']' -> buffer.Head = '['
            | '}' -> buffer.Head = '{'
            | _ -> false

        let rec checkRec list buffer =
            match list with
            | [] -> List.empty = buffer
            | head :: tail -> match head with
                              | _ when (head = '(') || (head = '[') || (head = '{') -> checkRec tail (head :: buffer)
                              | ')' | ']' | '}' -> if checker head buffer then checkRec tail buffer.Tail else false
                              | _ -> checkRec tail buffer
        checkRec list []