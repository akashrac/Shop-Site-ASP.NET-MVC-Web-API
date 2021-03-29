# Shop-Site-ASP.NET-MVC-Web-API
1.I used the database first development approach to design the database first and using entity framework I prepared models for each table of database.
2.I created Web API controllers for each table where each action method(GET, POST, PUT, DELETE) will interact with the database and perform the action using the http Web API trigger.
3.I have completed the part where user can select on login page the user type i.e. Admin or Customer and can login accordingly.
4.Login Controller will check for the user identity according to User type selection of user on the login page in Admin or Customer list.
5.If the user is admin then the app will redirect him to Admin home where he will be to get Customer and Item page links.
6.Admin will have access to both the links and can add, edit, delete the customer/items.
7.In the Customer registration page we will check if the customer already exists then we will redirect the customer to the login page or registration will be done. 
8.On other part the customer will be redirected to an items page where he will be able to place orders by adding items into cart.
9.Create orders functionality is yet to complete.
