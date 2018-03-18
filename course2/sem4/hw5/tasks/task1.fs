namespace tasks

module task1 = 
    (*empty string - correct brackets sequence*)
    (*sequence without brackets - correct brackets sequence*)
    let check (s: string) =
        let list = (s.ToCharArray()) |> List.ofArray

        let rec checkRec list buffer =
            match list with
            | [] -> List.empty = buffer
            | head :: tail -> match head with
                              | _ when (head = '(') || (head = '[') || (head = '{') -> checkRec tail (head :: buffer)
                              | ')' -> if buffer.Head = '(' then checkRec tail buffer.Tail else false
                              | ']' -> if buffer.Head = '[' then checkRec tail buffer.Tail else false
                              | '}' -> if buffer.Head = '{' then checkRec tail buffer.Tail else false
                              | _ -> checkRec tail buffer
        checkRec list []