Feature: EMEASearchJobs
this feature is to test search of EMEA Professional job positions

@C001 @smokeTest
Scenario: Check total number of EMEA Proffesionals job positions
	Given I am on "https://www.ubs.com/global/en.html"
	When I click "Careers"
	And I click subitem "Search jobs"
	And I open Professionals for EMEA
	Then there are 276 open positions

