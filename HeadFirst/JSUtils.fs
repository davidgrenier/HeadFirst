namespace HeadFirst

[<AutoOpen>]
module Inline =
    open IntelliFactory.WebSharper.Pervasives

    [<Inline "new Date($date).toDateString()">]
    let formatDate date = X

    type JS = IntelliFactory.WebSharper.Core.Attributes.JavaScriptAttribute

[<AutoOpen>]
module JSUtils =
    open IntelliFactory.WebSharper.Html
    
    [<JS>]
    let (=<) (elem : Element) content = elem.Clear(); elem -< content |> ignore

    [<JS>]
    let inject destination contentF (elem : Element) = OnClick (fun _ _ -> destination =< contentF ()) elem