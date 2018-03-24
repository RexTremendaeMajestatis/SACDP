namespace tasks.Tests.Tests

open NUnit.Framework
open tasks.task1

module Tests = 
    
    [<Test>]
    let ``Bst add``() = 
        let tree = Tree<int>()
        tree.Add 10
        let actual = tree.Size
        let expected = 1
        Assert.AreEqual(actual, expected)