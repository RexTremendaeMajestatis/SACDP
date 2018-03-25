namespace tasks

open System
open System.Collections
open System.Collections.Generic
open System.Linq.Expressions

module task1 = 
    
    type Node<'a> =
        | Node of 'a * Node<'a> * Node<'a>
        | Tip of 'a
        | Empty
        with
            member this.Size = 
                match this with
                | Node(_, l, r) -> 1 + l.Size + r.Size
                | Tip(_) -> 1
                | Empty -> 0

            override this.ToString() = 
                match this with
                | Node(x, l, r) -> "[{" + x.ToString() + "} -> " + l.ToString() + " | " + r.ToString() + "]"
                | Tip(x) -> "(" + x.ToString() + ")"
                | Empty -> "(*)"

    type Tree<'a when 'a : comparison>() = 
        let mutable (root: Node<'a>) = Empty

        member this.Size = 
            root.Size

        member this.IsEmpty = 
            root = Empty

        override this.ToString() = 
            root.ToString()

        member this.Show() = 
            let rec recShow node =
                match node with
                | Empty -> printfn ""
                | Tip(x) -> printfn "x"
                | Node(x, l, r) -> printfn "x"
                                   recShow l
                                   recShow r
            recShow root
        
        member this.Add data = 
            let rec recAdd data node = 
                match node with
                | Empty -> Tip(data)
                | Tip(x) -> match data with
                            | data when data < x -> Node(x, Tip(data), Empty)
                            | data when data > x -> Node(x, Empty, Tip(data))
                            | _ -> Node(x, Empty, Empty)
                | Node(x, l, r) -> match data with  
                                   | data when data < x -> Node(x, recAdd data l, r)
                                   | data when data > x -> Node(x, l, recAdd data r)
                                   | _ -> Node(x, l, r)
            root <- recAdd data root
        
        member this.Find data =
            let rec recFind data node = 
                match node with
                | Empty -> false
                | Tip(x) -> data = x
                | Node(x, l, r) -> match data with
                                   | data when data < x -> recFind data l
                                   | data when data > x -> recFind data r
                                   | _ -> true
            recFind data root

        member this.Remove data = 
            let rec recGetMin (node: Node<'a>) = 
                match node with
                | Tip(x) -> Tip (x)
                | Node(_, l, _) -> recGetMin l
                | Empty -> Empty


            let rec mostRightNode tree =
                 match tree with
                 | Empty -> Empty
                 | Tip a -> Tip a
                 | Node(x, l, r) -> match r with
                                    | Empty -> Tip x
                                    | _ -> mostRightNode r

            let rec recRemove data node = 
                match node with 
                | Empty -> Empty
                | Tip(x) -> match data with
                            | data when data = x -> Empty
                            | _ -> node
                | Node(x, l, r) -> match data with
                                   | data when data < x -> Node(x, recRemove data l, r)
                                   | data when data > x -> Node(x, l, recRemove data r)
                                   | _ -> match r with
                                          | Empty -> l
                                          | Node(y, Empty, rr) -> Node(y, l, rr)
                                          | Node(y, ll, rr) -> let min = recGetMin ll
                                                               match min with
                                                               | Tip a -> Node(a, l, recRemove a r)
                                                               | _ -> Empty
                                          | Tip(y) -> Node(y, l, Empty)
            root <- recRemove data root

        member t.Remove2 value =
            let rec findLeft tree =
                match tree with
                | Tip(element) -> element
                | Node(element, l, r) -> findLeft l

            let rec recRemove value tree =
                match tree with
                | Empty -> Empty
                | Tip element -> 
                    if (element = value) then Empty else tree
                | Node (current, left, right) ->
                    if value > current then Node(current, left, recRemove value right)
                    elif value < current then Node(current, recRemove value left, right)
                    else match right with
                         | Empty -> left
                         | Node(element, Empty, r) -> Node(element, left, r)
                         | Node(element, l, r) -> let minLeft = findLeft l
                                                  Node(minLeft, recRemove minLeft l, r)
                         | Tip(element) -> Node(element, left, Empty)
            root <- recRemove value root
