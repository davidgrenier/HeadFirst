module HeadFirst.Starbuzz

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper
open Server.Starbuzz

[<JS>]
let core = Div []

[<JS>]
let rec starbuzz () =
    let formatDrink { Name = n; Price = p; Description = d } =
        [
            H2 [n + ", $" + (string p) |> Text]
            P [Text d; Attr.Id "houseblend"]
        ]
    [
        yield H1 [Text "Starbuzz Coffee Beverages"]
        yield! drinks() |> Seq.map formatDrink |> Seq.concat
        yield P [
            A [HRef "#Mission"; Text "Read about our Mission"] |>! inject core mission
            Br []
        ] -- Text "Read the "
        -- A [
            Attr.Title "Read all about caffeine on the Buzz"
            HRef "http://wickedlysmart.com/buzz"
            Text "Caffeine Buzz"
        ]
    ]

and [<JS>] mission () =
    [
        H1 [Text "Starbuzz Coffee's Mission"]
        P [Text "To provide all the caffeine that you need to power your life."]
        P [Text "Just drink it."]
    ]

and [<JS>] body () = core -< starbuzz ()