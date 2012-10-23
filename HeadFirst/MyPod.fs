module HeadFirst.MyPod

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper

[<JS>]
let core = Div []

[<JS>]
let rec body () =
    core -< [
        h1 "Welcome to myPod"
        pText "Welcome to the place to show off your iPod, wherever you might be.
            Wanna join the fun? All you need is any iPod from the early classic
            iPod to the latest iPod Nano, the smallest iPod Shuffle to the largest
            iPod Video, and a digital camera. Just take a snapshot of your iPod in
            your favorite location and we'll be glad to post it on myPod. So, what
            are you waiting for?"

        h2 "Seattle, Washington"
        pText "Me and my iPod in Seattle! You can see the Space Needle. You can't see the 628 coffee shops."

        P [
            thumbnail "seattle_half"
            thumbnail "seattle_classic" -- Alt "My video iPod in Seattle, WA"
            thumbnail "seattle_shuffle" -- Alt "A classic iPod in Seattle, WA"
            thumbnail "seattle_downtown" -- Alt "An iPod in downtown Seattle, WA"
        ]

        h2 "Birmingham, England"
        pText "Here are some iPod photos around Birmingham. We've obviously got some  
            passionate folks over here who love their iPods. Check out the classic
            red British telephone box!"

        P [
            thumbnail "britain" -- Alt "An iPod in Birmingham at a telephone box"
            thumbnail "applestore" -- Alt "An iPod at the Birmingham Apple store"
        ]
    ]

and openImage title src =
    [
        h1 title
        image src
    ]