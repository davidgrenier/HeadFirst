module HeadFirst.Lounge

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

[<JS>]
let core = Div []

[<JS>]
let directions () =
    [
        "Take the 305 S exit to Webville - go 0.4 mi"
        "Continue on 305 - go 12 mi"
        "Turn right at Structure Ave N - go 0.6 mi"
        "Turn right and head toward Structure Ave N - go 0.0 mi"
        "Turn right at Structure Ave N - go 0.7 mi"
        "Continue on Structure Ave S - go 0.2 mi"
        "Turn right at SW Presentation Way - go 0.0 mi"
    ] |> List.map (fun x -> P [Text x])
    |> (fun x -> H1 [Text "Directions"] :: x)

[<JS>]
let rec elixirs () =
    let drink (header, img, description) =
        [
            h2 header
            P [image img img] -- Text description
        ]            
    [
        yield h1 "Our Elixirs"
        yield! [
                "Green Tea Cooler", "green", "Chock full of vitamins and minerals, this elixir combines the healthful benefits of green tea with a twist of chamomile blossoms and ginger root."
                "Rapsberry Ice Concentration", "lightblue", "Combining raspberry juice with lemon grass, citrus peel adn rosehips, this icy drink will make your mind feel clear and crips."
                "Blueberry Bliss Elixir", "blue", "Blueberries and cherry essence mixed into a base of elderflower herb tea will put you in a relaxed state of bliss in no time."
                "Cranberry Antioxidant Blast", "red", "Wake up to the flavors of cranberry and hibiscus in this vitamin C rich elixir."
            ] |> Seq.collect drink
        yield a "#" "Back to the Lounge" None |>! inject core lounge
    ]
    
and [<JS>] lounge () =
    [
        h1 "Welcome to the New and Improved Head First Lounge"
        image "drinks" "Our drinks"
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