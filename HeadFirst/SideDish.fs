module HeadFirst.SideDish

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

[<JS>]
let body () =
    let d term def = [DT [Text term]; DD [Text def]]
    let li text = LI [Text text]
    Div [
        DL [
            yield! d "Burma Shave Signs" "Road signs common in the U.S. in the 1920s and 1930s advertising shaving products."
            yield! d "Route 66" "Most famous road in the U.S. highway system."
        ]
        OL [
            li "Charge Segway"
            LI [
                Text "Pack for trip"
                UL [
                    li "cell phone"
                    li "iPod"
                    li "digital camera"
                    li "a protein bar"
                ] :> _
            ]
            li "Call mom"
        ]
        P [Text "Here's the html element: <html></html>"]
        Code [Text "let x = 3 in x * x"]
    ]