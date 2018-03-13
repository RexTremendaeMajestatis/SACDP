namespace tasks

module task1 = 
    (*пустая строка - правильная скобочная последовательность*)
    (*последовательность без скобок - правильная скобочная последовательность*)
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