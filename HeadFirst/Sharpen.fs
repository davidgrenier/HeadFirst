module HeadFirst.Sharpen

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper

[<JS>]
let body () =
    [
        [Text "How long a line can you draw with the typical pencil?"]
        [Img [Src "http://www.starbuzzcoffee.com/images/corporate/ceo.jpg"]]
        [Img [Src "http://wickedlysmart.com/hfhtmlcss/trivia/broken.png"; Alt "The typical new pencil can draw a line 35 miles long."]]
        [image "drinks" -- Width "48" -- Height "100"]
    ] |> Seq.map P |> Div