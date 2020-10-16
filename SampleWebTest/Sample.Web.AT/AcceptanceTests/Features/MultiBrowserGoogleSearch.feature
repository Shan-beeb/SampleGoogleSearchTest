Feature: Multi browser google search feature


	Scenario Outline: Searching clover.com on Google
	Given a user is using <browser> browser
	And a user searches for 'Clover' on Google Search
	Then 'Clover' official page should be displayed on Google results
	When a user clicks on 'Clover' official page on Google results
	Then a user should be able to navigate to Clovers.com
	Examples: 
	| browser          |
	| Chrome           |
	| HeadLessChrome   |
	| Firefox          |
	| InternetExplorer |
	| Android          |
	| Ios              |


	Scenario Outline: Searching Amazon.com on Google
	Given a user is using <browser> browser
	And a user searches for 'amazon' on Google Search
	Then 'amazon' official page should be displayed on Google results
	When a user clicks on 'amazon' official page on Google results
	Then a user should be able to navigate to amazon.com
	Examples: 
	| browser          |
	| Chrome           |
	| HeadLessChrome   |
	| Firefox          |
	| InternetExplorer |
	| Android          |
	| Ios              |

	