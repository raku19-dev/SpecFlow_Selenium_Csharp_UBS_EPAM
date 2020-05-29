Feature: EMEASearchJobs
this feature is to check different search options on EMEA Professional job search page

@C001 @smokeTest
Scenario: Check total number of EMEA Proffesionals job positions
	Given I am on "https://www.ubs.com/global/en.html"
	When I click "Careers/Search jobs"
	And I open Professionals for EMEA
	And new tab is open
	Then there are 274 open positions

@C002 @smokeTest
Scenario: Check number of EMEA Proffesionals job positions in Wroclaw
	Given I am on "https://www.ubs.com/global/en.html"
	When I click "Careers/Search jobs"
	And I open Professionals for EMEA
	And new tab is open
	And I check City "Wroclaw"
	Then there are 44 open positions
	
@C003 @smokeTest
Scenario: Check number of Full-Time EMEA Proffesionals job positions in Wroclaw
	Given I am on "https://www.ubs.com/global/en.html"
	When I click "Careers/Search jobs"
	And I open Professionals for EMEA
	And new tab is open
	And I check Job Type "Full Time"
	And I check Function Category "Business development"
	Then there are 3 open positions

@C004 @smokeTest
Scenario: Apply for specific EMEA Proffessional job positions
	Given I am on "https://www.ubs.com/global/en.html"
	When I click "Careers/Search jobs"
	And I open Professionals for EMEA
	And new tab is open
	And I select EMEA Proffessional job position "Quant Analyst" 
	And I click Apply now
	And user sign in with login and password
	Then user can see "Start your application"