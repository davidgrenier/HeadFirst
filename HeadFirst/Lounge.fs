﻿module HeadFirst.Lounge

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

[<JS>]
let core = Div []

[<JS>]
let directions () = []

[<JS>]
let rec elixirs () =
    let drink header img description =
        [
            H2 [Text header]
            P [Text description] -- Img [Src ("images/" + img)]
        ]            
    [
        yield H1 [Text "Our Elixirs"]
        yield! drink "Green Tea Cooler" "green.jpg"
            "Chock full of vitamins and minerals, this elixir combines the healthful benefits of green tea with a twist of chamomile blossoms and ginger root."
        yield! drink "Rapsberry Ice Concentration" "lightblue.jpg"
            "Combining raspberry juice with lemon grass, citrus peel adn rosehips, this icy drink will make your mind feel clear and crips."
        yield! drink "Blueberry Bliss Elixir" "blue.jpg"
            "Blueberries and cherry essence mixed into a base of elderflower herb tea will put you in a relaxed state of bliss in no time."
        yield! drink "Cranberry Antioxidant Blast" "red.jpg"
            "Wake up to the flavors of cranberry and hibiscus in this vitamin C rich elixir."
        yield A [HRef "#"; Text "Back to the Lounge"] |>! inject core lounge
    ]
    
and [<JS>] lounge () =
    [
        H1 [Text "Welcome to the New and Improved Head First Lounge"]
        Img [Src "Images/drinks.gif"]
        P [
            Text "Join us any evening for refreshing "
            A [HRef "#Elixirs"; Text "elixirs"] |>! inject core elixirs :> _
            Text ", conversation and maybe a game or two of Dance Dance Revolution. Wireless access is always provided; BYOWS (Bring Your Own Web Server)."
        ]
        H2 [Text "Directions"]
        P [
            Text "You'll find us right in the center of downtown Webville. If you need help finding us, check out our "
            A [HRef "#Directions"; Text "detailed directions"] |>! inject core directions :> _
            Text ". Come join us!"
        ]
    ]

and [<JS>] body () = core -< lounge ()