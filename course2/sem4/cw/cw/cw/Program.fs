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

module task2 = 

    
    type Node<'a> =
        | Node of 'a * Node<'a> * Node<'a>
        | Tip of 'a

    let rec minDist (node: Node<'a>) (dist: int) = 
        match node with
        | Tip _ -> dist
        | Node(_, left, right) -> let ldist = minDist left (dist + 1)
                                  let rdist = minDist right (dist + 1)
                                  if ldist < rdist then ldist
                                  else rdist

    let actual = minDist (Node(2, Tip(3), Tip(3))) 0

module task3 = 

    ///Queue class
    type MyQueue<'a>() = 
        let list = new List<'a>()
        
        ///Add a value to queue
        member this.push value = 
         list.Add(value)

        ///Remove a value from queue and return it
        member this.pop() =
            if (this.IsEmpty()) then
                failwith "Queue is empty" 
            let value = list.Item (0)
            list.RemoveAt (0)
            value
       
        ///Check is queue is empty
        member this.IsEmpty() =
            list.Count = 0


