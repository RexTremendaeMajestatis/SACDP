module Tests

open NUnit.Framework
open task3.task3

[<Test>]
let ``Simple FV test1.1`` () = 
    let expected = ['x']
    let actual = getFV (Var('x'))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Simple FV test1.2`` () = 
    let expected = ['x']
    let actual = getFV (Var('y'))
    Assert.IsFalse(expected.Equals(actual))

[<Test>]
let ``Simple FV test2.1`` () = 
    let expected = ['x'; 'y']
    let actual = getFV (App(Var('x'), Var('y')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Simple FV test3.1`` () = 
    let expected = ['x']
    let actual = getFV (Abs('y', Var('x')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Simple FV test3.2`` () = 
    let expected = []
    let actual = getFV (Abs('x', Var('x')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test1`` () = 
    let expected = ['z'; 'n']
    let actual = getFV (App(Abs('x', Var('z')), Abs('y', Var('n'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test2`` () = 
    let expected = ['b']
    let actual = getFV (App(Abs('x', Var('x')), Abs('a', Var('b'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test3`` () = 
    let expected = []
    let actual = getFV (App(Abs('x', Var('x')), Abs('a', Var('a'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test4`` () = 
    let expected = ['x']
    let actual = getFV (App(Abs('x', Var('x')), Var('x')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test5`` () = 
    let expected = ['y'; 'x']
    let actual = getFV (App(Abs('x', Var('y')), Abs('y', Var('x'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Presentation example test`` () = 
    let expected = ['z']
    let actual = getFV (App(Abs('x', Abs('y', Var('x'))), Abs('x', App(Var('z'), Var('x')))))
    Assert.That(expected, Is.EqualTo(actual))
