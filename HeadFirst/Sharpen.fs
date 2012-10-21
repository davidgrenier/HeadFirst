module HeadFirst.Sharpen

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper

[<JS>]
let body () =
    Div [
        P [Text "How long a line can you draw with the typical pencil?"]
        P [Img [Src "http://www.starbuzzcoffee.com/images/corporate/ceo.jpg"]]
    ]