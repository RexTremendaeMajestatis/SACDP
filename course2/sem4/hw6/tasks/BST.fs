namespace BST

module task1 = 
    open System.Collections
    open System.Collections.Generic
        
    /// <summary>
    /// Node of binary search tree
    /// </summary>
    type Node<'a> =
        | Node of 'a * Node<'a> * Node<'a>
        | Empty
        with

            /// <summary>
            /// Amount of children
            /// </summary>
            member this.Size = 
                match this with
                | Node(_, l, r) -> 1 + l.Size + r.Size
                | Empty -> 0

            /// <summary>
            /// Converts the value of this instance to its equivalent string representation
            /// </summary>
            override this.ToString() = 
                match this with
                | Node(x, l, r) -> "Node(" + x.ToString() + ", " + l.ToString() + ", " + r.ToString() + ")"
                | Empty -> "Empty"

    /// <summary>
    /// Enumerator for binary search tree
    /// </summary>
    type TreeEnumerator<'a when 'a : comparison> (root: Node<'a>) = 
        let mutable index = -1

        let toList (node: Node<'a>) = 
            let rec toListRec (node: Node<'a>) list = 
                match node with
                | Empty -> list
                | Node(x, l, r) -> x :: ((toListRec l list) @ (toListRec r list))
            toListRec node []

        let mutable nodesList = toList root

        let refresh() = 
            nodesList <- toList root

        interface IEnumerator<'a> with
            member this.Reset() = index <- -1

            member this.MoveNext() = 
                refresh()
                index <- index + 1
                nodesList.Length > index

            member this.Current = nodesList.[index]

            member this.Dispose() = 
                nodesList <- List.Empty
                index <- -1

            member this.get_Current() = (this :> IEnumerator<'a>).Current :> obj



    /// <summary>
    /// Binary search tree class
    /// </summary>
    type Tree<'a when 'a : comparison>(root: Node<'a>) = 
        let mutable (root: Node<'a>) = root
        new() = 
            Tree(Empty)

        /// <summary>
        /// Size of binary search tree
        /// </summary>
        member this.Size = 
            root.Size

        /// <summary>
        /// Check if binary search tree is empty
        /// </summary>
        member this.IsEmpty = 
            root = Empty

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        override this.ToString() = 
            root.ToString()
        
        /// <summary>
        /// Add a new node to the binary search tree
        /// </summary>
        member this.Add (data: 'a) = 
            let rec addRec (data: 'a) (node: Node<'a>) = 
                match node with
                | Empty -> Node(data, Empty, Empty)
                | Node(x, l, r) -> match data with  
                                   | data when data < x -> Node(x, addRec data l, r)
                                   | data when data > x -> Node(x, l, addRec data r)
                                   | _ -> Node(x, l, r)
            root <- addRec data root

        /// <summary>
        /// Check if the binary search tree contains a node with the data
        /// </summary>
        member this.Find (data: 'a) =
            let rec findRec (data: 'a) (node: Node<'a>) = 
                match node with
                | Empty -> false
                | Node(x, l, r) -> match data with
                                   | data when data < x -> findRec data l
                                   | data when data > x -> findRec data r
                                   | _ -> true
            findRec data root

        /// <summary>
        /// Remove a node with the data
        /// </summary>
        member this.Remove (data: 'a) = 
            let rec getMin (node: Node<'a>) = 
                match node with
                | Node(_, Empty, _) -> node
                | Node(_, l, _) -> getMin l
                | Empty -> Empty

            let rec removeRec (data: 'a) (node: Node<'a>) = 
                match node with 
                | Empty -> Empty
                | Node(x, Empty, Empty) -> match data with
                                           | data when data = x -> Empty
                                           | _ -> node
                | Node(x, l, r) -> match data with
                                   | data when data < x -> Node(x, removeRec data l, r)
                                   | data when data > x -> Node(x, l, removeRec data r)
                                   | _ -> match r with
                                          | Empty -> l
                                          | Node(y, Empty, Empty) -> Node(y, l, Empty)
                                          | Node(y, Empty, newR) -> Node(y, l, newR)
                                          | Node(y, newL, Empty) -> Node(y, l, newL)
                                          | Node(y, newL, newR) -> let min = getMin newL
                                                                   match min with
                                                                   | Node(z, Empty, Empty) -> Node(z, l, removeRec z r)
                                                                   | _ -> Empty
                                          
            root <- removeRec data root

        interface IEnumerable with
            member this.GetEnumerator() = new TreeEnumerator<'a>(root) :> IEnumerator
