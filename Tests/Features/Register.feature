Feature: Register
	As ungeristred user i'll be able to register and
	after registration add item to wish list

Background: Open browser and navigate to main page
	Given User opens web application on AutomationpracticeMain page
	Then User sees loaded AutomationpracticeMain page
	When User clicks on SignIn button
	Then User sees loaded SignIn page

@register @wishList
Scenario: Register And add wish elements
	When User gets random email and provides in EmailAddress field
	And User clicks on CreateAnAccount button
	Then User sees loaded Registration page
	When User provides values on fields
		| Field                                  | Value                          |
		| FirstName                              | Www                            |
		| LastName                               | Xxx                            |
		| Password                               | 12345                          |
		| Company                                | Wssss                          |
		| Address                                | dfsdfsdfsdf, dsdfsdf, dfdsfsdf |
		| City                                   | Beee                           |
		| ZipCode                                | 12345                          |
		| HomePhone                              | 99999999                       |
		| MobilePhone                            | 333444222                      |
		| AssignAnAddressAliasForFutureReference | sdhfklshdf;asdf                |
	And User chooses Mr. value on Title radio buttons
	When user selects dropdowns with vaues
		| Field   | Value         |
		| Dd      | 23            |
		| Mm      | June          |
		| Yy      | 1982          |
		| Country | United States |
		| State   | Alabama       |
	And User clicks on Register button
	Then User sees loaded MyAccount page
	And User sees on lable Account value Www
	And User sees on lable Account value Xxx
	When User clicks on MyWishList button
	Then User sees loaded MyWishList page
	Given User remembers 1 element from list TopSellers as a result
	When User clicks on 1 element on TopSellers list
	Then User sees loaded ProductCard page
	When User clicks on AddToWishList button
	Then Message AddedToYourWishlist appears on page
	When User closes AddedToYourWishlist message
	Then User sees loaded ProductCard page
	When User clicks on Account button
	Then User sees loaded MyAccount page
	When User clicks on MyWishList button
	Then User sees loaded MyWishList page
	When User clicks on WishTable table 1 row 1 cell
	Then User compares field Result with result