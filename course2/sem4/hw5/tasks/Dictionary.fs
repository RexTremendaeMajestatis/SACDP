namespace tasks

module task3 = 

    open System

    type record = {name: string; number: string}
    

    let rec phoneDic (list: list<record>) = 
        printf "Choose an option:
                1. exit\n
                2. add record (name & phone number)\n
                3. find phone number by name\n
                4. find name by telephone number\n
                5. show all database\n
                6. save the data in file\n
                7. load data from file\n"

        let n = Console.ReadLine() |> int
        match n with 
            | 1 -> printf "Exit"
            | 2 -> printf "Enter name:"
                   let tempName = Console.ReadLine()
                   printf "Enter telephine number:"
                   let tempNumber = Console.ReadLine()
                   let record = {name = tempName; number = tempNumber}
                   phoneDic list
            | _ -> printf "error"





