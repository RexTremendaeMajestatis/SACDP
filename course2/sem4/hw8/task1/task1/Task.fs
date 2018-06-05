open System.Net
open System.IO
open System.Text.RegularExpressions

module Task1 =

    /// <summary>
    /// Fetch the main page
    /// </summary>
    /// <param name="url">URL of the page</param>
    let fetchPageInfo (url: string) =
        async {
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse()
            use stream = response.GetResponseStream()
            use reader = new StreamReader(stream)
            let text = reader.ReadToEnd()
            do printfn "%s --- %d" url text.Length
            return text
    }

    /// <summary>
    /// Get URL from html tag
    /// </summary>
    /// <param name="href">Some reference in html</param>
    let toURL (href: string) = 
        let reference = href.Split('"')
        reference.[1]

    /// <summary>
    /// Find URLs in text
    /// </summary>
    /// <param name="html">URL of the page</param>
    let findURLs (html: string) = 
        let pattern = "<a href=\"http.*\">"
        let regex = new Regex(pattern)
        let references = regex.Matches(html)
        [for x in references -> toURL x.Value]

    /// <summary>
    /// Fetch info about the page asynchronously
    /// </summary>
    /// <param name="url">URL of the page</param>
    let fetchReferencesInfo (url: string) = 
        async
            {
                let! text = fetchPageInfo(url)
                let urls = findURLs(text)
                let! result = urls |> List.map (fun p -> fetchPageInfo p) |> Async.Parallel
                return result
            } 
        |> Async.RunSynchronously
        |> ignore
    
    fetchReferencesInfo "http://hwproj.me/courses/9/terms/4"
