namespace tasks.Tests.Tests

open NUnit.Framework
open BST.task1
open Network.Network
open Network.Computer

module TreeTests = 
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


module NetworkTests = 

    type CustomTestRandom() = 
        interface ICustomRandom with
            member this.Random() = 0

    let cr = CustomTestRandom()

    let Computers = [
                    new Computer(cr, "MacOs"); 
                    new Computer(cr, "MacOs");
                    new Computer(cr, "Windows"); 
                    new Computer(cr, "MacOs");
                    new Computer(cr, "MacOs");
                    new Computer(cr, "Ubuntu");
                    ]
    Computers.[2].Infect

    let connectionMatrix = [
                            [false; false; true; false; false; true]; 
                            [false; false; true; false; false; false]; 
                            [true; true; false; true; true; false];
                            [false; false; true; false; false; false];
                            [false; false; true; false; false; false];
                            [true; false; false; false; false; false];
                            ]

    let network = new Network(Computers, connectionMatrix)

    [<Test>]
    let ``Network Test1``() = 
        Assert.IsTrue(network.Uninfected = 5)

    [<Test>]
    let ``Network Test2``() = 
        network.Step
        Assert.IsTrue(network.Uninfected = 1)
      
    [<Test>]
    let ``Network Test3``() = 
        network.Play
        Assert.IsTrue(network.Uninfected = 0)

