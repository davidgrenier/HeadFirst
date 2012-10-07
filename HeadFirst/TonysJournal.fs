module HeadFirst.TonysJournal

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open Server.Tonys

[<ReflectedDefinition>]
let body () =
    let entries =
        journalEntries()
        |> List.sortBy (fun (Entry(d, _, _)) -> d)
        |> List.rev
        |> Seq.map (fun (Entry(date, image, description)) ->
            [
                yield H2 [formatDate date |> Text]
                if image.IsSome then
                    yield Img [Src ("images/" + image.Value + ".jpg")]
                yield P [Text description]                
            ])
        |> Seq.concat
    Div [
        yield H1 [Text "Segay'n USA"]
        yield P [ Text "Documenting my trip around the US on my very own Segway!"]
        yield! entries
    ]