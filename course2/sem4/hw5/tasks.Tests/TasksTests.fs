module Tests

open NUnit.Framework
open tasks.task1
open tasks.task3

let records = [record("Pavel", "89213636398"); record("Sergey", "89213457665")]

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

[<Test>]
let ``Add record test`` () = 
    let actual = addRecord ("Victor") ("89214332287") records
    let expected = "Victor | 89214332287"
    Assert.AreEqual(actual.[0].ToString(), expected)

[<Test>]
let ``Find phone number by name`` () = 
    let actual = findByName "Pavel" records
    let expected = "89213636398"
    Assert.AreEqual(actual, expected)

[<Test>]
let ``Find name by phone number`` () = 
    let actual = findByNumber "89213457665" records
    let expected = "Sergey"
    Assert.AreEqual(actual, expected)