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

[<JavaScript>]
let siteInfo = function
    | Starbuzz -> "Starbuzz Cofee", ["Starbuzz"]
    | Lounge -> "Head First Lounge", []
    | Tonys -> "Tony's Journal", []
    | SideDish -> "Side Dishes", []
    | Home -> "Home", []

module Home =
    open IntelliFactory.WebSharper.Html
    open Microsoft.FSharp.Reflection
    
    [<Rpc>]
    let pages() =
        FSharpType.GetUnionCases(typeof<Pages>)
        |> Array.map (fun x -> FSharpValue.MakeUnion(x, [||]) |> unbox, x.Name)
        |> Array.filter (fun (case, _) -> case <> Home)

    [<JavaScript>]
    let body () =
        pages ()
        |> Seq.map (fun (case, target) -> [A [Text (siteInfo case |> fst); HRef target]; Br []] )
        |> Seq.concat
        |> Div

type ClientSite(p) =
    inherit Web.Control()

    [<JavaScript>]
    override this.Body =
        match p with
        | Starbuzz -> Starbuzz.body ()
        | Lounge -> Lounge.body ()
        | Tonys -> TonysJournal.body ()
        | SideDish -> SideDish.body ()
        | Home -> Home.body ()
        :> _

let stylesheets = List.map (fun ref -> Link [Rel "stylesheet"; Attributes.HRef (sprintf "Stylesheets/%s.css" ref)])

let render site =
    let title, head = siteInfo site
    PageContent <| fun ctx ->
    {
        Page.Default with
            Title = Some title
            Head = stylesheets head
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

[<assembly: WebsiteAttribute(typeof<Website>)>]
do ()