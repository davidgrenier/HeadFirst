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
        | Some title -> a -- Attr.Title title
        | None -> a