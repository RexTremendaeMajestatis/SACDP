module Tests

open NUnit.Framework
open task3.task3

[<Test>]
let ``Simple FV test1.1`` () = 
    let expected = ['x']
    let actual = getFV (Var ('x'))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Simple FV test1.2`` () = 
    let expected = ['x']
    let actual = getFV (Var ('y'))
    Assert.IsFalse(expected.Equals(actual))

[<Test>]
let ``Simple FV test2.1`` () = 
    let expected = ['x'; 'y']
    let actual = getFV (App (Var ('x'), Var ('y')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Simple FV test3.1`` () = 
    let expected = ['x']
    let actual = getFV (Abs ('y', Var ('x')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Simple FV test3.2`` () = 
    let expected = []
    let actual = getFV (Abs ('x', Var ('x')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test1`` () = 
    let expected = ['z'; 'n']
    let actual = getFV (App (Abs ('x', Var ('z')), Abs ('y', Var ('n'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test2`` () = 
    let expected = ['b']
    let actual = getFV (App (Abs ('x', Var ('x')), Abs ('a', Var ('b'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test3`` () = 
    let expected = []
    let actual = getFV (App (Abs ('x', Var ('x')), Abs ('a', Var ('a'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test4`` () = 
    let expected = ['x']
    let actual = getFV (App (Abs ('x', Var ('x')), Var ('x')))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced FV test5`` () = 
    let expected = ['y'; 'x']
    let actual = getFV (App (Abs ('x', Var ('y')), Abs ('y', Var ('x'))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Presentation example test`` () = 
    let expected = ['z']
    let actual = getFV (App (Abs ('x', Abs ('y', Var ('x'))), Abs ('x', App (Var ('z'), Var ('x')))))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Simple substitution test`` () = 
    let expected = (Var ('z'))
    let actual = substitude (Var ('z')) ('y') (Var ('x'))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced substitution test1`` () = 
    let S = Abs ('a', Var ('y'))
    let T = Abs ('a', App (Var ('a'), Var ('a')))
    let actual = substitude S 'a' T
    let expected = Abs ('a', Var ('y'))
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``Advanced substitution test2`` () = 
    let S = Abs ('y', Var ('x'))
    let T = Abs ('s', Var ('y'))
    let actual = substitude S 'x' T
    let expected = Abs ('a', Abs ('s', Var ('y')))
    Assert.That(expected, Is.EqualTo(actual))

(*или как я нашел косяк в первом таске*)
[<Test>]
let ``Homework ((λa.(λb.b b) (λb.b b)) b) ((λc.(c b)) (λa.a))`` () =
    let actual = betaReduction (App (App(App(Abs('a', Abs('b', App(Var('b'), Var('b')))), Abs('b', App(Var('b'), Var('b')))), Var('b')), App(Abs('c', App(Var('c'), Var('b'))), Abs('a', Var('a')))))
    let expected = App (App (Abs (('b'), App (Var ('b'), Var ('b'))), Var ('b')), Var ('b'))
    Assert.That(expected, Is.EqualTo(actual))
