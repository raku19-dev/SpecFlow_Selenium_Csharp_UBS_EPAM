Feature: EMEASearchJobs
this feature is to test search of EMEA Professional job positions

@C001 @smokeTest
Scenario: Check total number of EMEA Proffesionals job positions
	Given I am on "https://www.ubs.com/global/en.html"
	When I click "Careers/Search jobs"
	And I open Professionals for EMEA
	And new tab is open
	Then there are 272 open positions

@C002 @smokeTest
Scenario: Check number of EMEA Proffesionals job positions in Wroclaw
	Given I am on "https://www.ubs.com/global/en.html"
	When I click "Careers/Search jobs"
	And I open Professionals for EMEA
	And new tab is open
	And I check City "Wroclaw"
	Then there are 40 open positions
