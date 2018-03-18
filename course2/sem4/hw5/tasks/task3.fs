namespace tasks

module task3 = 

    type record = {name: string; phoneNumber: string}

    let rec findByName (name: string) (list: list<record>) = 
        match list with
        | head :: tail -> if head.name = name then printfn "%s" head.phoneNumber
                          else findByName name tail
        | [] -> printfn "Database is empty"

    let rec findByNumber (number: string) (list: list<record>) = 
        match list with
        | head :: tail -> if head.phoneNumber = number then printfn "%s" head.name
                          else findByNumber number tail
        | [] -> printfn "Database is empty"

    let rec dic (list: list<record>) = 
        printfn "Enter command"
        let command = System.Console.ReadLine()
        match command with
        | "2" -> printfn "Add new record\nEnter name: "
                 let tempName = System.Console.ReadLine()
                 printfn "Enter phone number: "
                 let tempPhoneNumber = System.Console.ReadLine()
                 let tempRecord = {name = tempName; phoneNumber = tempPhoneNumber}
                 dic (tempRecord :: list)
        | "3" -> printfn "Find phone number by name"
                 printfn "Enter name: "
                 let tempName = System.Console.ReadLine()
                 findByName tempName list
                 dic list
        | "4" -> printfn "Find name by phone number"
                 printfn "Enter phone number: "
                 let tempNumber = System.Console.ReadLine()
                 findByNumber tempNumber list
                 dic list 
        | _ -> printfn "fff"