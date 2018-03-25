namespace tasks.Tests.Tests

open NUnit.Framework
open tasks.task1

module Tests = 
    
    [<Test>]
    let ``Addition test1``() = 
        let tree = Tree<int>()
        tree.Add 10
        let actualSize = tree.Size
        let expectedSize = 1
        Assert.AreEqual(actualSize, expectedSize)

    [<Test>]
    let ``Addition test2``() = 
        let tree = Tree<int>()
        tree.Add 10
        let actualString = tree.ToString()
        let expectedString = "(10)"
        Assert.AreEqual(actualString, expectedString)

    [<Test>]
    let ``Addition test3``() = 
        let tree = Tree<int>()
        tree.Add 10
        tree.Add 20
        tree.Add 5
        let actualString = tree.ToString()
        let expectedString = "[{10} -> (5) | (20)]"
        Assert.AreEqual(actualString, expectedString)

    [<Test>]
    let ``Removing test1``() = 
        let tree = Tree<int>()
        tree.Add 10
        tree.Remove 10
        let actual = tree.Size
        let expected = 0;
        Assert.AreEqual(actual, expected)
        Assert.IsTrue(tree.IsEmpty)

    [<Test>]
    let ``Removing test2``() = 
        let tree = Tree<int>()
        tree.Add 10
        tree.Add 20
        tree.Add 5
        tree.Add 30
        tree.Add 15
        tree.Remove 20
        let actualStruct = tree.ToString()
        let expected = "[{10} -> (5) | [{30} -> (15) | (*)]]"
        Assert.AreEqual(actualStruct, expected)