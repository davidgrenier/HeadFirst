namespace HeadFirst

type JS = IntelliFactory.WebSharper.Core.Attributes.JavaScriptAttribute

[<AutoOpen>]
module Inline =
    open IntelliFactory.WebSharper.Pervasives

    [<Inline "new Date($date).toDateString()">]
    let formatDate date = X


[<AutoOpen>]
module JSUtils =
    open IntelliFactory.WebSharper.Html
    
    [<JS>]
    let (=<) (elem : Element) content = elem.Clear(); elem -< content |> ignore

    [<JS>]
    let inject destination contentF elem = OnClick (fun _ _ -> destination =< contentF ()) elem

    [<JS>]
    let a ref text =
        let a = A [HRef ref; Text text]
        function
        | None -> a
        | Some title -> a -- Attr.Title title

    [<JS>]
    let openLink ref text title = a ref text title -- Attr.Target "_blank"

    [<JS>]
    let h1 title = H1 [Text title]

    [<JS>]
    let h2 title = H2 [Text title]

    [<JS>]
    let img src alt = Img [Src src; Alt alt]

    [<JS>]
    let image src = img ("Images/" + src + ".png")

    [<JS>]
    let thumbnail src = img ("Thumbnails/" + src + ".png")

    [<JS>]
    let p text = P [Text text]