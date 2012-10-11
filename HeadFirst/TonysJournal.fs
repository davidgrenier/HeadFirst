module HeadFirst.TonysJournal

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open Server.Tonys

[<JavaScript>]
let text chars =
    Text <| System.String (chars |> List.rev |> List.toArray)

[<JavaScript>]
let rec (|Eval|) = function
    | Normal (c :: rest) ->
        let rec aux acc = function
            | CRLF rest -> (text acc) :: (aux [] rest)
            | Normal (c :: rest) -> aux (c :: acc) rest
            | Quote rest | rest ->
                let (Eval result) = rest
                (text acc) :: result
        aux [c] rest
    | Quote (_ :: rest) ->
        let rec aux elems acc = function
            | CRLF rest -> (aux (Br [] :> IPagelet :: (text acc) :: elems) [] rest)
            | Normal (c :: rest) -> aux elems (c :: acc) rest
            | Quote (_ :: rest) | rest ->
                let (Eval result) = rest
                BlockQuote ((text acc) :: elems |> List.rev) :> IPagelet :: result
        aux [] [] rest
    | CRLF rest ->
        let (Eval result) = rest
        (Br [] :> _) :: result
    | _ -> []
and [<JavaScript>] (|Normal|Quote|CRLF|) = function
    | ('\r'|'\n') :: rest
    | '\r' :: '\n' :: rest -> CRLF rest
    | '"' :: _ as rest -> Quote rest
    | rest -> Normal rest

[<JavaScript>]
let body () =
    let entries =
        journalEntries()
        |> List.sortBy (fun (Entry(d, _, _)) -> d)
        |> List.rev
        |> Seq.map (fun (Entry(date, image, description)) ->
            let (Eval result) = List.ofSeq description
            [
                yield H2 [formatDate date |> Text]
                if image.IsSome then
                    yield Img [Src ("images/" + image.Value + ".jpg")]
                yield P result
            ])
        |> Seq.concat
    Div [
        yield H1 [Text "Segay'n USA"]
        yield P [ Text "Documenting my trip around the US on my very own Segway!"]        
    ] -< entries