module HeadFirst.Host

open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets

type Pages =
    | Starbuzz
    | Lounge
    | Tonys

    with static member Default = Tonys

type ClientSite(p) =
    inherit Web.Control()

    [<JavaScript>]
    override this.Body =
        match p with
        | Starbuzz -> Starbuzz.body ()
        | Lounge -> Lounge.body ()
        | Tonys -> TonysJournal.body ()
        :> _

let stylesheets =
    List.map (fun ref -> Link [Rel "stylesheet"; Attributes.HRef (sprintf "Stylesheets/%s.css" ref)])

let render site =
    let title, head =
        match site with
        | Starbuzz -> "Starbuzz Cofee - test", ["Starbuzz"]
        | Lounge -> "Head First Lounge", []
        | Tonys -> "Tony's Journal", []
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
                Router = Router.Table [Pages.Default, "/"] <|> Router.Infer()
                Controller = { Handle = render }
            }

[<assembly: WebsiteAttribute(typeof<Website>)>]
do ()