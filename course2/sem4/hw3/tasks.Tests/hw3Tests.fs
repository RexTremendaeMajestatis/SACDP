module Tests

open NUnit.Framework
open tasks

[<Test>]
let ``Empty filter test`` () = 
    let expected = 0
    let actual = task1.countOddByFilter []
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Simple filter test`` () = 
    let expected = 4
    let actual = task1.countOddByFilter [1; 2; 3; 4; 5; 6; 7; 8]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Advanced filter test`` () = 
    let expected = 50
    let actual = task1.countOddByFilter [1..100]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Zero odd numbers filter test`` () =
    let expected = 0
    let actual = task1.countOddByFilter [1; 3; 5; 7]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Empty fold test`` () = 
    let expected = 0
    let actual = task1.countOddByFold []
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Simple fold test`` () = 
    let expected = 4
    let actual = task1.countOddByFold [1; 2; 3; 4; 5; 6; 7; 8]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Advanced fold test`` () = 
    let expected = 50
    let actual = task1.countOddByFold [1..100]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Zero odd numbers fold test`` () =
    let expected = 0
    let actual = task1.countOddByFold [1; 3; 5; 7]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Empty map test`` () = 
    let expected = 0
    let actual = task1.countOddByMap []
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Simple map test`` () = 
    let expected = 4
    let actual = task1.countOddByMap [1; 2; 3; 4; 5; 6; 7; 8]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Advanced map test`` () = 
    let expected = 50
    let actual = task1.countOddByMap [1..100]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Zero odd numbers map test`` () =
    let expected = 0
    let actual = task1.countOddByMap [1; 3; 5; 7]
    Assert.That(actual, Is.EqualTo(expected))