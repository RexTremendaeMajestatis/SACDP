namespace cw

open System
open System.Collections.Generic

module task1 = 

    let count list = 
        let rec countRec list acc n = 
            match list with
            | [] -> if n = 0.0 then 0.0
                    else acc / n
            | h :: t -> countRec t (acc + Math.Sin(h)) (n + 1.0)

        countRec list 0.0 0.0


module task3 = 

    type MyQueue<'a>() = 
        let list = new List<'a>()
   
        member this.push value = 
         list.Add(value)

        member this.pop() =
            if (this.IsEmpty()) then
                failwith "Queue is empty" 
            let value = list.Item (0)
            list.RemoveAt (0)
            value

        member this.IsEmpty() =
            list.Count = 0


