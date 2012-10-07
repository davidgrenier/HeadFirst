module HeadFirst.Starbuzz

open IntelliFactory.WebSharper.Html
open Server.Starbuzz

[<ReflectedDefinition>]
let body () =
    let formatDrink { Name = n; Price = p; Description = d } =
        [
            H2 [n + ", $" + (string p) |> Text]
            P [Text d; Attr.Id "houseblend"]
        ]
    Div [
        yield H1 [Text "Starbuzz Coffee Beverages"]
        for drink in drinks() do
            yield! formatDrink drink
    ]

[<ReflectedDefinition>]
let mission =
    [
        H1 [Text "Starbuzz Coffee's Mission"]
        P [Text "To provide all the caffeine that you need to power your life."]
        P [Text "Just drink it."]
    ]