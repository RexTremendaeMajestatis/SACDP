module Tests

open System
open Xunit
open System.Collections.Generic
open cw.task3
open cw.task2
open cw.task1

[<Fact>]
let ``Queue test1`` () =
    let queue = new MyQueue<int>()
    queue.push 1
    queue.push 2
    queue.push 3
    Assert.True((queue.pop()) = 1)

[<Fact>]
let ``Queue test2`` () = 
    let queue = new MyQueue<int>()
    Assert.True(queue.IsEmpty())

[<Fact>]
let ``Sin test1``() = 
    let actual = count []
    let expected = 0.0
    Assert.Equal(actual, expected)

[<Fact>]
let ``Sin test2``() = 
    let actual = count [0.0; 3.14]
    let expected = 0.0
    let deltha = actual - expected
    Assert.True(deltha < 0.01)

[<Fact>]
let ``Tree test1``() = 
    let expected = 0
    let actual = minDist (Tip(9)) 0
    Assert.Equal(actual, expected)

[<Fact>]
let ``Tree test2``() = 
    let expected = 1
    let actual = minDist (Node(2, Tip(3), Tip(3))) 0
    Assert.Equal(actual, expected)
    
    
