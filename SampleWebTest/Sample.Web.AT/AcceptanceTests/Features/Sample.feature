Feature: Sample
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Scenario Outline: Add two number
	Given a user is using <browser> browser
	And a user searches for 'Clover' on Google Search
	Then Clover's official page should be displayed on Google results
	When a user clicks on Clover's official page on Google results
	Then a user should be able to navigate to Clovers.com
	Examples: 
	| browser          |
	| Chrome           |
	| HeadLessChrome   |
	| Firefox          |
	| InternetExplorer |
	| Android          |
	| Ios              |

	