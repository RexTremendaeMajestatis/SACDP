open NUnit.Framework

[<TestFixture>]
type testClass() =

    [<Test>]
    member this.TestMethodPassing() = 
        Assert.IsTrue(true)

