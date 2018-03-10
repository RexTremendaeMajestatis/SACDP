namespace tasks

module task1 =

    let countOddByFold list = 
         List.fold (fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0 list

    let countOddByFilter list = 
        list
        |> List.filter (fun x -> x % 2 = 0)
        |> List.length

    let countOddByMap list = 
        list
        |> List.map (fun x -> (x + 1) % 2)
        |> List.sum

module task2 = 

    type Tree<'a> = 
        | Tree of 'a * Tree<'a> * Tree<'a>
        | Tip of 'a

    let rec map (tree: Tree<'a>) func = 
        match tree with 
        | Tree (root, left, right) -> Tree(func root, map left func, map right func)
        | Tip(root) -> Tip(func root)

module task3 = 
    
    type Proposition = 
        | Val of float
        | Add of Proposition * Proposition
        | Sub of Proposition * Proposition
        | Mul of Proposition * Proposition
        | Div of Proposition * Proposition

    let rec eval (p: Proposition) = 
        match p with
        | Val(m) -> m
        | Add(m, n) -> eval(m) + eval(n)
        | Sub(m, n) -> eval(m) - eval(n)
        | Mul(m, n) -> eval(m) * eval(n)
        | Div(m, n) -> if abs(eval n) > 0.000000001 then eval(m) / eval(n) else failwith "Deniminator is zero"                      

module task4 = 
    
    let primeSequence =
        let isPrime (n: int) = 
            not (Seq.exists(fun x -> n % x = 0) {2..(n - 1)})
        Seq.initInfinite(fun x -> x + 2)
        |> Seq.filter isPrime