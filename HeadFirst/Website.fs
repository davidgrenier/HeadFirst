module HeadFirst.Host

open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets

type Pages =
    | Starbuzz
    | Lounge
    | Tonys
    | SideDish
    | Home
    | Sharpen
    | MyPod

[<JS>]
let siteInfo = function
    | Starbuzz -> "Starbuzz Cofee", ["Starbuzz"]
    | Lounge -> "Head First Lounge", ["Lounge"]
    | Tonys -> "Tony's Journal", []
    | SideDish -> "Side Dishes", ["SideDish"]
    | Home -> "Home", []
    | Sharpen -> "Sharpen your pencil trivia", []
    | MyPod -> "myPod", ["myPod"]

module Home =
    open IntelliFactory.WebSharper.Html
    open Microsoft.FSharp.Reflection
    
    [<Rpc>]
    let pages() =
        FSharpType.GetUnionCases(typeof<Pages>)
        |> Array.map (fun x -> FSharpValue.MakeUnion(x, [||]) |> unbox, x.Name)
        |> Array.filter (fst >> ((<>) Home))

    [<JS>]
    let body () =
        pages ()
        |> Seq.collect (fun (case, target) -> [a target (siteInfo case |> fst) None; Br []] )
        |> Div

type ClientSite(p) =
    inherit Web.Control()

    [<JS>]
    override this.Body =
        match p with
        | Starbuzz -> Starbuzz.body ()
        | Lounge -> Lounge.body ()
        | Tonys -> TonysJournal.body ()
        | SideDish -> SideDish.body ()
        | Home -> Home.body ()
        | Sharpen -> Sharpen.body ()
        | MyPod -> MyPod.body ()
        :> _

let stylesheets = List.map (fun ref -> Link [Rel "stylesheet"; Attributes.HRef (sprintf "Stylesheets/%s.css" ref)])

let render site =
    let title, head = siteInfo site
    PageContent <| fun ctx ->
    {
        Page.Default with
            Title = Some title
            Head = Tags.Meta [CharSet "utf-8"] :: stylesheets head
            Body = [ Div [new ClientSite (site)] ]
    }

type Website() =
    interface IWebsite<Pages> with
        member this.Actions = []
        member this.Sitelet =
            {
                Router = Router.Table [Pages.Home, "/"] <|> Router.Infer()
                Controller = { Handle = render }
            }

[<assembly: Website(typeof<Website>)>]
do ()