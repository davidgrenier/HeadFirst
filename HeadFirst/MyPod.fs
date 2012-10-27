module HeadFirst.MyPod

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper

[<JS>]
let core = Div []

[<JS>]
let rec body () =
    let buildImageLink title image alt =
        A [HRef "#"] -- thumbnail image alt |>! inject core (fun () -> openImage title image alt)

    let seattle = buildImageLink "Seattle Ferry"
    let birmingham = buildImageLink "In Birmingham"

    core -< [
        P [image "mypod" "Our MyPod logo"]

        h1 "Welcome to myPod"
        pText "Welcome to the place to show off your iPod, wherever you might be.
            Wanna join the fun? All you need is any iPod from the early classic
            iPod to the latest iPod Nano, the smallest iPod Shuffle to the largest
            iPod Video, and a digital camera. Just take a snapshot of your iPod in
            your favorite location and we'll be glad to post it on myPod. So, what
            are you waiting for?"

        h2 "Seattle, Washington"
        pText "Me and my iPod in Seattle! You can see the Space Needle. You can't see the 628 coffee shops."

        [
            "seattle_half", "iPod in Seattle, WA"
            "seattle_classic", "My video iPod in Seattle, WA"
            "seattle_shuffle", "A classic iPod in Seattle, WA"
        ] |> Seq.map ((<||) seattle)
        |> Seq.append [buildImageLink "Seattle Downtown" "seattle_downtown" "An iPod in downtown Seattle, WA"]
        |> P

        h2 "Birmingham, England"
        pText "Here are some iPod photos around Birmingham. We've obviously got some  
            passionate folks over here who love their iPods. Check out the classic
            red British telephone box!"

        P [
            birmingham "britain" "An iPod in Birmingham at a telephone box"
            birmingham "applestore" "An iPod at the Birmingham Apple store"
        ]
    ]

and [<JS>] openImage title src alt = [h1 title; image src alt]