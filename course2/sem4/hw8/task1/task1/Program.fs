// Learn more about F# at http://fsharp.org

open System.Net
open System.IO
open System.Text.RegularExpressions

let sites = ["https://www.site-do.ru/db/db.php";"http://spisok.math.spbu.ru"]
let fetchAsync (url: string) = 
    async
        {
            do printfn "Creating request for %s" url
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse()
            do printfn "Getting response stream for %s..." url
            use stream = response.GetResponseStream()
            do printfn "Reading response for %s..." url
            use reader = new StreamReader(stream)
            let html = reader.ReadToEnd()
            do printfn "%s --- %d" url html.Length
            return html
        }

let getInfo (url: string) = 
    let regexExpression = new Regex("<a.*href=\"http.*\">")
    let html = Async.RunSynchronously <| fetchAsync url
    let webPages = regexExpression.Matches(html)
    let proc = [for url in webPages -> 
                     let value = url.Value
                     fetchAsync(value.Substring(value.IndexOf("f=") + 3 , value.IndexOf("\">") - value.IndexOf("=\"") - 2))
                     ]    
    Async.Parallel proc |> Async.RunSynchronously |> ignore

getInfo "http://hwproj.me/courses/9/terms/4"
