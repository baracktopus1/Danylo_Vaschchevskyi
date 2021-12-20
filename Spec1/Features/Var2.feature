Feature: Var2
	Simple calculator for adding two numbers

@mytag
Scenario: Login and change job
	
	Given User logs in HRM
	Then User is navigated to the homepagee

	Given User goes to Jobs page
	When User adds a new job
	Then User notices new data on the page

	When User clicks on <job_title>
	And User edits Job
	Then User notices edited data on the page

	When User deletes <job_title>
	Then User notices his field deleted on Job title page
