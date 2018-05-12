open System.Net
open System.IO
open System.Text.RegularExpressions

module task1 =

    /// <summary>
    /// Fetch the main page
    /// </summary>
    /// <param name="url">URL of the page</param>
    let fetchMainPage (url: string) = 
            printfn "Creating request for %s" url
            let request = WebRequest.Create(url)
            use response = request.GetResponse()
            printfn "Getting response stream for %s..." url
            use stream = response.GetResponseStream()
            printfn "Reading response for %s..." url
            use reader = new StreamReader(stream)
            reader.ReadToEnd()

    /// <summary>
    /// Fetch info about the page asynchronously
    /// </summary>
    /// <param name="url">URL of the page</param>
    let fetchPagesInfoAsync (url: string) = 
        async
            {
                try
                    let request = WebRequest.Create(url)
                    use! response = request.AsyncGetResponse()
                    use stream = response.GetResponseStream()
                    use reader = new StreamReader(stream)
                    let text = reader.ReadToEnd()
                    do printfn "%s --- %d" url text.Length
                with
                | :? WebException as e ->
                    printfn "404: Page not found" 
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
    /// Show info about pages
    /// </summary>
    /// <param name="url">URL of the main page</param>
    let fetchInfo (url: string) = 
        url
        |> fetchMainPage
        |> findURLs
        |> List.map (fun p -> fetchPagesInfoAsync p)
        |> Async.Parallel
        |> Async.RunSynchronously
        |> ignore
