namespace HeadFirst

[<AutoOpen>]
module Inline =
    open IntelliFactory.WebSharper.Pervasives

    [<Inline "new Date($date).toDateString()">]
    let formatDate date = X

[<ReflectedDefinition>]
[<AutoOpen>]
module JSUtils =
    open IntelliFactory.WebSharper.Html

    let (=<) (elem : Element) content = elem.Clear(); elem -< content |> ignore