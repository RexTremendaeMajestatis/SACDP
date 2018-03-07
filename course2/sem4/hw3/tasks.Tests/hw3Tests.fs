module Tests

open NUnit.Framework
open tasks.task1
open tasks.task2
open tasks.task3
open tasks.task4
open System.Security.Cryptography.X509Certificates
open tasks

(*3.1 Tests*)
[<Test>]
let ``Empty filter test`` () = 
    let expected = 0
    let actual = countOddByFilter []
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Simple filter test`` () = 
    let expected = 4
    let actual = countOddByFilter [1; 2; 3; 4; 5; 6; 7; 8]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Advanced filter test`` () = 
    let expected = 50
    let actual = countOddByFilter [1..100]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Zero odd numbers filter test`` () =
    let expected = 0
    let actual = countOddByFilter [1; 3; 5; 7]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Empty fold test`` () = 
    let expected = 0
    let actual = countOddByFold []
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Simple fold test`` () = 
    let expected = 4
    let actual = countOddByFold [1; 2; 3; 4; 5; 6; 7; 8]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Advanced fold test`` () = 
    let expected = 50
    let actual = countOddByFold [1..100]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Zero odd numbers fold test`` () =
    let expected = 0
    let actual = countOddByFold [1; 3; 5; 7]
    Assert.That(actual, Is.EqualTo(expected))

(*3.2 Tests*)
[<Test>]
let ``Empty map test`` () = 
    let expected = 0
    let actual = countOddByMap []
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Simple map test`` () = 
    let expected = 4
    let actual = countOddByMap [1; 2; 3; 4; 5; 6; 7; 8]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Advanced map test`` () = 
    let expected = 50
    let actual = countOddByMap [1..100]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Zero odd numbers map test`` () =
    let expected = 0
    let actual = countOddByMap [1; 3; 5; 7]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Map a tree of one element test`` () = 
    let expected = (Tip(16))
    let actual = map (Tip(4)) (fun x -> x * x) 
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Map a simple tree test`` () = 
    let expected = (Tree(4, Tree(9, Tip(16), Tip(25)), Tip(1)))
    let actual = map (Tree(2, Tree(3, Tip(4), Tip(5)), Tip(1))) (fun x -> x * x)
    Assert.That(actual, Is.EqualTo(expected))

(*3.3 Tests*)
[<Test>]
let ``Add test`` () =
    let expected = 5
    let actual = eval (Add(Val(2.0), Val(3.0)))
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Sub test`` () =
    let expected = -1.0
    let actual = eval (Sub(Val(2.0), Val(3.0)))
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Mul test`` () =
    let expected = 6
    let actual = eval (Mul(Val(2.0), Val(3.0)))
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Div test`` () =
    let expected = 2.0 / 3.0
    let actual = eval (Div(Val(2.0), Val(3.0)))
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Random proposition test`` () = 
    let expected = -7.875
    let actual = eval (Sub(Val(6.0), Div(Mul(Val(9.0), Val(37.0)), Val(24.0)))) // (6 - ((9 * 37) / 24))
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``First prime number test`` () = 
    let expected = 0
    let actual = primeSequence
                 |> Seq.findIndex (fun x -> x = 2)
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``10th prime number test`` () = 
    let expected = 29
    let actual = primeSequence
                 |> Seq.item 9
    Assert.That(actual, Is.EqualTo(expected))