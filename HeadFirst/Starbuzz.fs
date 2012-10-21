module HeadFirst.Starbuzz

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper
open Server.Starbuzz

[<JS>]
let core = Div []

[<JS>]
let rec starbuzz () =
    let formatDrink { Name = n; Price = p; Description = d } =
        [H2 [n + ", $" + (string p) |> Text]; P [Text d; Attr.Id "houseblend"]]
    [
        yield h1 "Starbuzz Coffee Beverages"
        yield! drinks() |> Seq.collect formatDrink
        yield P [
            Text "Read about "
            a "#Mission" "our Mission" (Some "Read more about Starbuzz Coffee's important mission.") |>! inject core mission :> _
            Br [] :> _
            Text "Read the "
            openLink "http://wickedlysmart.com/buzz#Coffee" "Read all about caffeine on the Buzz" (Some "Caffeine Buzz") :> _
        ]
    ]

and [<JS>] mission () =
    [
        h1 "Starbuzz Coffee's Mission"
        P [Text "To provide all the caffeine that you need to power your life."]
        P [Text "Just drink it."]
    ]

and [<JS>] body () = core -< starbuzz ()