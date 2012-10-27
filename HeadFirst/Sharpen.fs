module HeadFirst.Sharpen

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper

[<JS>]
let body () =
    [
        [Text "How long a line can you draw with the typical pencil?"]
        [img "http://www.starbuzzcoffee.com/images/corporate/ceo.jpg" "Some guy's face"]
        [img "http://wickedlysmart.com/hfhtmlcss/trivia/broken.png" "The typical new pencil can draw a line 35 miles long."]
        [image "drinks" "With html affected size" -- Width "48" -- Height "100"]
    ] |> Seq.map P |> Div