module HeadFirst.Lounge

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

[<ReflectedDefinition>]
let core = Div []

[<ReflectedDefinition>]
let directions = []

[<ReflectedDefinition>]
let body =
    let rec elixirs () =
        let drink header img description =
            [
                H2 [Text header]
                P [
                    Img [Src ("images/" + img)] :> IPagelet
                    Text description
                ]
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
            yield A [HRef "#"; Text "Back to the Lounge"] |>! OnClick (fun _ _ -> core =< lounge ())
        ]
    
    and lounge () =
        [
            H1 [Text "Welcome to the New and Improved Head First Lounge"]
            Img [Src "Images/drinks.gif"]
            P [
                Text "Join us any evening for refreshing "
                A [HRef "#Elixirs"; Text "elixirs"] :> _ |>! OnClick (fun _ _ -> core =< elixirs ())
                Text ", conversation and maybe a game or two of Dance Dance Revolution. Wireless access is always provided; BYOWS (Bring Your Own Web Server)."
            ]
            H2 [Text "Directions"]
            P [
                Text "You'll find us right in the center of downtown Webville. If you need help finding us, check out our "
                A [HRef "#Directions"; Text "detailed directions"] :> _ |>! OnClick (fun _ _ -> core =< directions)
                Text ". Come join us!"
            ]
        ]

    and body () =
        core -< lounge ()

    body