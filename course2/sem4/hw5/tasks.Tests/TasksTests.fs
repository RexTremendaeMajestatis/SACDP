module Tests

open NUnit.Framework
open tasks.task1

[<Test>]
let ``Brackets test1`` () = 
    let s =  "((((((((()()()()())))((((((((()))"
    let expected = false
    let actual = check s
    Assert.AreEqual(expected, actual)

[<Test>]
let ``Brackets test2`` () = 
    let s = "(Кижнеров)[Павел]{Александрович}"
    let expected = true
    let actual = check s
    Assert.AreEqual(expected, actual)

[<Test>]
let ``Brackets test3`` () = 
    let s = "Кижнеров Павел Александрович"
    let expected = true
    let actual = check s
    Assert.AreEqual(expected, actual)

[<Test>]
let ``Brackets test4`` () = 
    let s = ""
    let expected = true
    let actual = check s
    Assert.AreEqual(expected, actual)