module Tests

open System.IO
open Xunit

open Task1
open task1

let href = """<a href="http://hwproj.me/courses/9/terms/mailto:yurii.litvinov@gmail.com">"""
let path = "html.txt"

[<Fact>]
let ``toURL test`` () =
    let actual = toURL href
    let expected = "http://hwproj.me/courses/9/terms/mailto:yurii.litvinov@gmail.com"
    Assert.Equal(actual, expected)

[<Fact>]
let ``find URLs test`` () = 
    use sr = new StreamReader(File.OpenRead(path))
    let html = sr.ReadToEnd()
    let actual = findURLs html
    let expected = ["https://www.w3schools.com/html/"]
    Assert.Equal<string list>(actual, expected)