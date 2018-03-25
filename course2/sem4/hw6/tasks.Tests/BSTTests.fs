namespace tasks.Tests.Tests

open NUnit.Framework
open tasks.task1

module Tests = 
    let tree = Tree<int>()
    tree.Add 10
    tree.Add 20
    tree.Add 5
    tree.Add 30
    tree.Add 15

    [<Test>]
    let ``Addition test1``() = 
        let actualSize = tree.Size
        let expectedSize = 5
        Assert.AreEqual(actualSize, expectedSize)

    [<Test>]
    let ``Addition test2``() = 
        let actualSize = tree.Size
        tree.Remove 50
        let expectedSize = 5
        Assert.AreEqual(actualSize, expectedSize)

    [<Test>]
    let ``Removing test1``() = 
        tree.Remove 10
        let actualSize = tree.Size
        let expectedSize = 4
        Assert.AreEqual(actualSize, expectedSize)

    [<Test>]
    let ``Removing test2``() = 
        tree.Remove 10
        let actual = tree.ToString()
        let expected = "[{15} -> (5) | [{20} -> (*) | (30)]]"
        Assert.AreEqual(actual, expected)

