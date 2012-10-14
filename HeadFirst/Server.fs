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
    type Entry =
        | Image of string
        | Description of string
        | Ordered of string list
        | Unordered of string list
        | Quote of string
    type JournalEntry = System.DateTime * Entry list
        
    let date m j = System.DateTime(2012, m, j)

    [<Rpc>]
    let journalEntries() =
        [
            date 8 20, [
                Image "Segway2"; Description "Well I made it 1200 miles already, and I passed through some interesting places on the way:"
                Ordered [
                    "Walla Walla, WA"
                    "Magic City, ID"
                    "Bountiful, UT"
                    "Last Chance, CO"
                    "Why, AZ"
                    "Truth or Consequences, NM"
                ]
            ]
            date 7 14, [
                Description "I saw some Burma Shave style signs on the side of the road today:"
                Quote "Passing cars,
When you can't see,
May get you,
A glimpse,
Of eternity."
                Description "I definitely won't be passing any cars."
            ]
            date 6 2, [
                Image "Segway1"
                Description "My first day of the trip! I can't believe finally got everything packed and ready to go. Because I'm on a Segway, I wasn't able to bring a whole lot with me:"
                Unordered [
                    "cell phone"
                    "iPod"
                    "digital camera"
                    "and a protein bar"
                ]
                Description "Just the essentials. As Lao Tzu would have said"
                Quote "A journey of a thousand miles begins with one Segay."
            ]
        ]