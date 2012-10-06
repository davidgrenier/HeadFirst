module HeadFirst.Server

open IntelliFactory.WebSharper

module Starbuzz =
    type Drink = {
            Name : string
            Description : string
            Price : float
        }

    let drink n d p = { Name = n; Description = d; Price = p }

    [<Rpc>]
    let drinks() =
        [
            drink "House Blend" "A smooth, mild blend of coffees from Mexico, Bolivia and Guatemala." 1.49
            drink "Mocha Cafe Latte" "Espresso, steamed milk and chocolate syrup." 2.35
            drink "Cappuccino" "A mixture of espresso, steamed milk and foam." 1.89
            drink "Chai Tea" "A spicy drink made with black tea, spices milk and honey." 1.85
        ]

module Tonys =
    type Date = System.DateTime
    type Image = string
    type Description = string
    type JournalEntry =
        Entry of Date * Image option * Description

    [<Rpc>]
    let journalEntries() =
        [
            Entry (Date(2012, 8, 20), Some "Segway2", "Well I made it 1200 miles already, and I passed through some interesting places on teh way: Walla Walla, WA, Magic City, ID, Bountiful, UT, Last Chance, CO, Why, AZ and Truth or Consequences, NM.")
            Entry (Date(2012, 7, 14), None, """I saw some Burma Shave style signs on the side of the road today: "Passing cars, When you can't see, May get you, A glimpse, Of eternity." I definitely won't be passing any cars.""")
            Entry (Date(2012, 6, 2), Some "Segway1", "My first day of the trip! I can't believe finally got everything packed and ready to go. Because I'm on a Segway, I wasn't able to bring a whole lot with me: cell phone, iPod, digital camera, and a protein bar. Just the essentials. As Lao Tzu would have said, \"A journey of a thousand miles begins with one Segay.\"")
        ]