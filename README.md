# May I take your order (MITYO)

It's a bit late, so I'm kinda tired, shouldn't write any code so I'm gonna write a readme instead, less damage to the code base that way:

**BRAND>** Hello welcome to [insert brand name here], may I take your order?

**Matt>** Yea I'd like a cheese burger.

**BRAND>** (Array item zero: [Material item](https://github.com/davidroberts63/may-i-take-your-order/blob/2de2b08ac6397e247a2588595f2c311253730ff7/Mityo/OrderItem.cs#L36)) Okay, the combo?

**Matt>** Yes please with Sweet tea.

**BRAND>** Tots or fries?

**Matt>** Tots

**BRAND>** (Array item one: [Material item](https://github.com/davidroberts63/may-i-take-your-order/blob/2de2b08ac6397e247a2588595f2c311253730ff7/Mityo/OrderItem.cs#L36)) And what to drink?

**Matt>** (Thinking to self, 'I already told you that but eh') Sweet tea please.

**BRAND>** (Array item two: [Material item](https://github.com/davidroberts63/may-i-take-your-order/blob/2de2b08ac6397e247a2588595f2c311253730ff7/Mityo/OrderItem.cs#L36)) And would you like a compliment with that sir?

**Matt>** Uh a compliment? Sure I guess.

**BRAND>** (Array item three: [Service item](https://github.com/davidroberts63/may-i-take-your-order/blob/2de2b08ac6397e247a2588595f2c311253730ff7/Mityo/OrderItem.cs#L17)) Anything else?

**Matt>** Nope that's all.

**BRAND>** Great, your total is {[calculate total](https://github.com/davidroberts63/may-i-take-your-order/blob/2de2b08ac6397e247a2588595f2c311253730ff7/Mityo/Order.cs#L56)} we will be out with your order in a moment.

**Matt>** Hey, can I add a milk shake to that order?

**BRAND>** Sorry sir, we [can't change](https://github.com/davidroberts63/may-i-take-your-order/blob/2de2b08ac6397e247a2588595f2c311253730ff7/Mityo/Order.cs#L48) the order once it's been made. Corporate [tests for that](https://github.com/davidroberts63/may-i-take-your-order/blob/2de2b08ac6397e247a2588595f2c311253730ff7/Tests/OrderTests.cs#L27). But I'd be happy to make a new order for you.

**Matt>** Wait, you test these?

**BRAND>** Yes, everytime we complete work, [we test](https://ci.appveyor.com/project/davidroberts63/may-i-take-your-order/build/tests).
