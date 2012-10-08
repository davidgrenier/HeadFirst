module HeadFirst.TonysJournal

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open Server.Tonys

[<JavaScript>]
let string chars = System.String (chars |> List.rev |> List.toArray)

[<JavaScript>]
let rec (|Eval|) = function
    | Normal (c :: rest) ->
        let rec aux acc = function
            | Normal (c :: rest) -> aux (c :: acc) rest
            | Quote rest | rest ->
                let (Eval result) = rest
                P [string acc |> Text] :: result
        aux [c] rest
    | Quote (_ :: rest) ->
        let rec aux acc = function
            | Normal (c :: rest) -> aux (c :: acc) rest
            | Quote (_ :: rest) | rest ->
                let (Eval result) = rest
                BlockQuote [string acc |> Text] :: result
        aux [] rest
    | _ -> []
and [<JavaScript>] (|Normal|Quote|) = function
    | '"' :: _ as rest -> Quote rest
    | rest -> Normal rest

[<JavaScript>]
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
                let (Eval result) = List.ofSeq description
                yield! result
            ])
        |> Seq.concat
    Div [
        yield H1 [Text "Segay'n USA"]
        yield P [ Text "Documenting my trip around the US on my very own Segway!"]
        yield! entries
    ]