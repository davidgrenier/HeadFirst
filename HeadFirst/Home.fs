module HeadFirst.Home

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

[<JavaScript>]
let body () =
    let a text target = [A [Text text; HRef target]; Br []]
    Div [
        yield! a "Starbuzz" "Starbuzz"
        yield! a "Lounge" "Lounge"
        yield! a "Tonys Journal" "Tonys"
        yield! a "Side Dishes" "SideDish"
    ]