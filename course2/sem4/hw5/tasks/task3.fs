namespace tasks

module task3 = 

    type record (name: string, phoneNumber: string) = 
        member this.name = name
        member this.phoneNumber = phoneNumber
        override this.ToString() = 
            this.name + " " + this.phoneNumber

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

    let rec showAllData (list: list<record>) = 
        match list with
        | head :: tail -> printfn "%s" (head.name + " | " + head.phoneNumber)
                          showAllData tail
        | [] -> printfn "End of database"

    let save (records: list<record>) (path: string) = 
        let recordsToString (records: list<record>) = 
            let rec recordsToStringRec (records: list<record>) strList =
                match records with
                | head :: tail -> recordsToStringRec tail (head.ToString() :: strList)
                | [] -> strList
            recordsToStringRec records []
        let recordsList = recordsToString records
        System.IO.File.WriteAllLines(path, recordsList)
    
    let load (path: string) = 
        if  System.IO.File.Exists path then
            let records = List.ofArray (System.IO.File.ReadAllLines(path))
            let recordsFromString (strList: List<string>) =
                let rec recordsFromStringRec recordsList (strList: List<string>) = 
                    match strList with
                    | head :: tail -> let split = head.Split(' ')
                                      recordsFromStringRec (record(split.[0], split.[1]) :: recordsList) tail
                    | [] -> recordsList
                recordsFromStringRec [] strList
            recordsFromString records
        else []

    let rec phoneBook (records: list<record>) = 
        printfn "Enter command"
        let command = System.Console.ReadLine()
        match command with
        | "1" -> printfn "Shut down *sad music*"
        | "2" -> printfn "Add a new record...\nEnter name: "
                 let name = System.Console.ReadLine()
                 printfn "Enter phone number: "
                 let phoneNumber = System.Console.ReadLine()
                 let tempRecord = record(name, phoneNumber)
                 phoneBook (tempRecord :: records)
        | "3" -> printfn "Find phone number by name...\nEnter name: "
                 let tempName = System.Console.ReadLine()
                 findByName tempName records
                 phoneBook records
        | "4" -> printfn "Find name by phone number...\nEnter phone number: "
                 let tempNumber = System.Console.ReadLine()
                 findByNumber tempNumber records
                 phoneBook records 
        | "5" -> showAllData records
                 phoneBook records
        | "6" -> printfn "Saving the database to file...\nEnter the target path: "
                 let path = System.Console.ReadLine()
                 save records path
                 printfn "Saving complete"
                 phoneBook records
        | "7" -> printfn "Loading database from file...\nEnter the target path: "
                 let path = System.Console.ReadLine()
                 let loadedRecords = load path
                 printfn "Loading complete"
                 phoneBook loadedRecords
        | _ -> printfn "Unknown command"
               phoneBook records