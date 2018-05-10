module Tests

open System
open Xunit
open task3.task3

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Simple FV test1.1`` () = 
    let expected = ['x']
    let actual = getFV (Var ('x'))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Simple FV test1.2`` () = 
    let expected = ['x']
    let actual = getFV (Var ('y'))
    Assert.False(actual.Equals(expected))

[<Fact>]
let ``Simple FV test2.1`` () = 
    let expected = ['x'; 'y']
    let actual = getFV (App (Var ('x'), Var ('y')))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Simple FV test3.1`` () = 
    let expected = ['x']
    let actual = getFV (Abs ('y', Var ('x')))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Simple FV test3.2`` () = 
    let actual = getFV (Abs ('x', Var ('x')))
    Assert.True(actual.IsEmpty)

[<Fact>]
let ``Advanced FV test1`` () = 
    let expected = ['z'; 'n']
    let actual = getFV (App (Abs ('x', Var ('z')), Abs ('y', Var ('n'))))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Advanced FV test2`` () = 
    let expected = ['b']
    let actual = getFV (App (Abs ('x', Var ('x')), Abs ('a', Var ('b'))))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Advanced FV test3`` () = 
    let expected = []
    let actual = getFV (App (Abs ('x', Var ('x')), Abs ('a', Var ('a'))))
    Assert.True(actual.IsEmpty)

[<Fact>]
let ``Advanced FV test4`` () = 
    let expected = ['x']
    let actual = getFV (App (Abs ('x', Var ('x')), Var ('x')))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Advanced FV test5`` () = 
    let expected = ['y'; 'x']
    let actual = getFV (App (Abs ('x', Var ('y')), Abs ('y', Var ('x'))))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Presentation example test`` () = 
    let expected = ['z']
    let actual = getFV (App (Abs ('x', Abs ('y', Var ('x'))), Abs ('x', App (Var ('z'), Var ('x')))))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Simple substitution test`` () = 
    let expected = (Var ('z'))
    let actual = substitute (Var ('z')) ('y') (Var ('x'))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Advanced substitution test1`` () = 
    let S = Abs ('a', Var ('y'))
    let T = Abs ('a', App (Var ('a'), Var ('a')))
    let actual = substitute S 'a' T
    let expected = Abs ('a', Var ('y'))
    Assert.True(actual.Equals(expected))

[<Fact>]
let ``Advanced substitution test2`` () = 
    let S = Abs ('y', Var ('x'))
    let T = Abs ('s', Var ('y'))
    let actual = substitute S 'x' T
    let expected = Abs ('a', Abs ('s', Var ('y')))
    Assert.True(actual.Equals(expected))

(*или как я нашел косяк в первом таске*)
[<Fact>]
let ``Homework ((λa.(λb.b b) (λb.b b)) b) ((λc.(c b)) (λa.a))`` () =
    let actual = betaReduction (App (App(App(Abs('a', Abs('b', App(Var('b'), Var('b')))), Abs('b', App(Var('b'), Var('b')))), Var('b')), App(Abs('c', App(Var('c'), Var('b'))), Abs('a', Var('a')))))
    let expected = App (App (Abs (('b'), App (Var ('b'), Var ('b'))), Var ('b')), Var ('b'))
    Assert.True(actual.Equals(expected))
