namespace tasks

module task3 = 
    open System.IO

    type record (name: string, phoneNumber: string) = 
        member this.Name = name
        member this.PhoneNumber = phoneNumber
        override this.ToString() = 
            this.Name + " " + this.PhoneNumber
    
    let addRecord (name: string) (phoneNumber: string) (records: list<record>) = 
        let newRecord = record(name, phoneNumber)
        newRecord :: records

    let rec findByName (name: string) (records: list<record>) = 
        match records with
        | head :: tail -> if head.Name = name then head.PhoneNumber
                          else findByName name tail
        | [] -> "No matches found"

    let rec findByNumber (number: string) (records: list<record>) = 
        match records with
        | head :: tail -> if head.PhoneNumber = number then head.Name
                          else findByNumber number tail
        | [] -> "No matches found"

    let rec showAllData (records: list<record>) = 
        match records with
        | head :: tail -> printfn "%O" head
                          showAllData tail
        | [] -> ()
 
    let recordsToString (records: list<record>) = 
        let rec recordsToStringRec (records: list<record>) strList =
            match records with
            | head :: tail -> recordsToStringRec tail (head.ToString() :: strList) 
            | [] -> strList
        recordsToStringRec records []

    let rec writeData (records: list<string>) (sw: StreamWriter) = 
        match records with
        | head :: tail -> sw.WriteLine(head.ToString())
                          writeData tail sw
        | [] -> ()

    let save (path: string) (records: list<record>) =
        let stringRecords = recordsToString records |> List.rev
        use sw = new StreamWriter(File.OpenWrite(path))
        writeData stringRecords sw
        
    let recordsFromString (strList: list<string>) =
        let rec recordsFromStringRec recordsList (strList: List<string>) = 
            match strList with
            | head :: tail -> let split = head.Split(' ')
                              recordsFromStringRec (record(split.[0], split.[1]) :: recordsList) tail
            | [] -> recordsList
        recordsFromStringRec [] strList
    
    let rec readData (records: list<string>) (sr: StreamReader) =
        if (not sr.EndOfStream) then 
            let newData = sr.ReadLine()
            readData (newData :: records) sr
        else
            sr.Close()
            records

    let load (path: string) = 
        if File.Exists path then
            use sr = new StreamReader(File.OpenRead(path))
            let stringRecords = readData [] sr
            recordsFromString stringRecords
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
                 phoneBook (addRecord name phoneNumber records)
        | "3" -> printfn "Find phone number by name...\nEnter name: "
                 let tempName = System.Console.ReadLine()
                 printfn "%s" <| findByName tempName records
                 phoneBook records
        | "4" -> printfn "Find name by phone number...\nEnter phone number: "
                 let tempNumber = System.Console.ReadLine()
                 printfn "%s" <| findByNumber tempNumber records
                 phoneBook records 
        | "5" -> showAllData records
                 phoneBook records
        | "6" -> printfn "Saving the database to file...\nEnter the target path: "
                 let path = System.Console.ReadLine()
                 save path records
                 printfn "Saving complete"
                 phoneBook records
        | "7" -> printfn "Loading database from file...\nEnter the target path: "
                 let path = System.Console.ReadLine()
                 let loadedRecords = load path
                 printfn "Loading complete"
                 phoneBook loadedRecords
        | _ -> printfn "Unknown command"
               phoneBook records

    let user = 
        printfn "Commands:"
        printfn "1 - exit"
        printfn "2 - add new record"
        printfn "3 - find phone number by name"
        printfn "4 - find name by phone number"
        printfn "5 - show all records"
        printfn "6 - save records to file"
        printfn "7 - load records from file"
        phoneBook []