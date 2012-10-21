module HeadFirst.TonysJournal

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open Server.Tonys

[<JS>]
let text chars =
    Text <| System.String (chars |> List.rev |> List.toArray)

[<JS>]
let multiLine content =
    let rec (|Eval|) = function
        | Normal (c :: rest) ->
            let rec aux acc = function
                | CRLF rest -> (text acc) :: (Br [] :> _) :: (aux [] rest)
                | Normal (c :: rest) -> aux (c :: acc) rest
                | Normal [] -> [text acc]
            aux [c] rest
        | CRLF rest ->
            let (Eval result) = rest
            (Br [] :> _) :: result
        | _ -> []
    and (|CRLF|Normal|) = function
        | '\r' :: '\n' :: rest
        | ('\r'|'\n') :: rest -> CRLF rest
        | rest -> Normal rest
    let (Eval result) = List.ofSeq content
    result

[<JS>]
let body () =
    let lis = List.map (fun x -> LI [Text x])
    let entries =
        journalEntries()
        |> List.sortBy fst
        |> List.rev
        |> Seq.collect (fun (date, content) ->
            H2 [formatDate date |> Text]
            :: (content |> List.map (function
                    | Description elems ->
                        elems
                        |> Seq.map (function
                            | SmallQuote q -> Q [Text q] :> IPagelet
                            | Textual t -> Text t)
                        |> P
                    | Quote quote -> BlockQuote (multiLine quote)
                    | Image image -> Img [Src ("images/" + image + ".jpg")]
                    | Ordered elems -> lis elems |> OL
                    | Unordered elems -> lis elems |> UL))
            )
    Div [
        yield h1 "Segay'n USA"
        yield P [Text "Documenting my trip around the US on my very own Segway!"]        
    ] -< entries