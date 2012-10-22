module HeadFirst.Lounge

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

[<JS>]
let core = Div []

[<JS>]
let directions () = []

[<JS>]
let rec elixirs () =
    let drink (header, img, description) =
        [
            h2 header
            P [image img] -- Text description
        ]            
    [
        yield h1 "Our Elixirs"
        yield!
            [
                "Green Tea Cooler", "green.jpg", "Chock full of vitamins and minerals, this elixir combines the healthful benefits of green tea with a twist of chamomile blossoms and ginger root."
                "Rapsberry Ice Concentration", "lightblue.jpg", "Combining raspberry juice with lemon grass, citrus peel adn rosehips, this icy drink will make your mind feel clear and crips."
                "Blueberry Bliss Elixir", "blue.jpg", "Blueberries and cherry essence mixed into a base of elderflower herb tea will put you in a relaxed state of bliss in no time."
                "Cranberry Antioxidant Blast", "red.jpg", "Wake up to the flavors of cranberry and hibiscus in this vitamin C rich elixir."
            ] |> Seq.collect drink
        yield a "#" "Back to the Lounge" None |>! inject core lounge
    ]
    
and [<JS>] lounge () =
    [
        h1 "Welcome to the New and Improved Head First Lounge"
        image "drinks.gif"
        P [
            Text "Join us any evening for refreshing "
            a "#Elixirs" "elixirs" None |>! inject core elixirs :> _
            Text ", conversation and maybe a game or two of Dance Dance Revolution. Wireless access is always provided; BYOWS (Bring Your Own Web Server)."
        ]
        h2 "Directions"
        P [
            Text "You'll find us right in the center of downtown Webville. If you need help finding us, check out our "
            a "#Directions" "detailed directions" None |>! inject core directions :> _
            Text ". Come join us!"
        ]
    ]

and [<JS>] body () = core -< lounge ()