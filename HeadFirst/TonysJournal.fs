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
            | CRLF rest -> (text acc) :: (Br [] :> _) :: (aux [] rest)
            | Normal (c :: rest) -> aux (c :: acc) rest
            | Normal [] -> [text acc]
        aux [c] rest
    | CRLF rest ->
        let (Eval result) = rest
        (Br [] :> _) :: result
    | _ -> []
and [<JavaScript>] (|CRLF|Normal|) = function
    | '\r' :: '\n' :: rest
    | ('\r'|'\n') :: rest -> CRLF rest
    | rest -> Normal rest

[<JavaScript>]
let body () =
    let lis = List.map (fun x -> LI [Text x])
    let entries =
        journalEntries()
        |> List.sortBy fst
        |> List.rev
        |> Seq.map (fun (date, content) ->
            H2 [formatDate date |> Text]
            :: (content |> List.map (function
                    | Description description ->
                        P [Text description]
                    | Quote quote ->
                        let (Eval result) = List.ofSeq quote
                        BlockQuote result
                    | Image image -> Img [Src ("images/" + image + ".jpg")]
                    | Ordered elems -> elems |> lis |> OL
                    | Unordered elems -> elems |> lis |> UL))
            )
        |> Seq.concat
    Div [
        yield H1 [Text "Segay'n USA"]
        yield P [ Text "Documenting my trip around the US on my very own Segway!"]        
    ] -< entries