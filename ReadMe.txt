Auction.Web is an MVC site with a simple homepage of items the user can bid on. I have set up data (products for sale) and saved it to the current session. 

We would most likely use a relational db. The model classes in the service project represents the tables. 

There is a web and service layer but no data later(for sake of time, using service layer to save and get data from repository(in our case web session).

I have not implemented a login or user service class or added user data to the session. Products and Bids have data hardcoded to the session. Ideally we would have a different table to seperate product data and product auction data(start/end time, price, etc) since a seller could relist the same product. 

A full site would have a data layer, login, a homepage with categories, products with images, search bar, menu with user order history, account information, items selling, etc. The current product listing page is also missing the bid history and current high bidder. 

To run project:

-run Auction.Web
-the index page will bring up a list of items to bid on
-the first item auction ends in a couple of minutes, when the auction is over the item will not appear in the list
-user can bid on product as long as bid amount is higher than current price

Todo(ran out of time):

-when user bids on item, user should know he/she is the current high bidder and should not be able to place another bid
-unit tests (created empty prj)

