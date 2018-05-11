namespace tasks.Tests.Tests

open NUnit.Framework
open BST.task1
open Network.Network
open Network.Computer
open Network.CustomRandom
open Network.CustomOS

module TreeTests = 
    open NUnit.Framework.Constraints

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
        let expected = "Node(15, Node(5, Empty, Empty), Node(20, Empty, Node(30, Empty, Empty)))"
        Assert.AreEqual(actual, expected)

    [<Test>]
    let ``Enumerator test`` () = 
        let mutable actual = 0
        let expected = 5
        for i in tree do
            actual <- actual + 1
        Assert.AreEqual(actual, expected)
        
        


module NetworkTests = 

    type CustomTestRandom() = 
        interface ICustomRandom with
            member this.Random() = 0

    let cr = CustomTestRandom()

    let comps = [
                Computer(CustomOS("MacOS"), false, cr)
                Computer(CustomOS("MacOS"), false, cr)
                Computer(CustomOS("Windows"), true, cr)
                Computer(CustomOS("MacOS"), false, cr)
                Computer(CustomOS("MacOS"), false, cr)
                Computer(CustomOS("Linux"), false, cr)
    ]

    let connectionMatrix = [
                            [false; false; true; false; false; true]; 
                            [false; false; true; false; false; false]; 
                            [true; true; false; true; true; false];
                            [false; false; true; false; false; false];
                            [false; false; true; false; false; false];
                            [true; false; false; false; false; false];
                            ]

    let network = Network(comps, connectionMatrix)

    let emptyComps = []
    let emptyConnectionMatrix = [[false]]
    let emptyNetwork = Network(emptyComps, emptyConnectionMatrix)

    [<Test>]
    let ``Network test1`` () = 
        let actual = network.Uninfected
        Assert.IsTrue((actual = 5))

    [<Test>]
    let ``Network Test2``() = 
        network.Step()
        Assert.IsTrue(network.Uninfected = 1)

    [<Test>]
    let ``Network Test3``() = 
        network.Play()
        Assert.IsTrue(network.Uninfected = 0)

    [<Test>]
    let ``Network Test4`` () = 
        let actual = emptyNetwork.Uninfected
        let expected = 0
        Assert.AreEqual(actual, expected)
