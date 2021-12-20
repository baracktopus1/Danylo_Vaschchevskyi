Feature: WebAPI_
	Simple calculator for adding two numbers

@mytag
Scenario: 01 User uploads file
	Given File is in the folder
	When Upload method is called
	Then File uploaded to the dropbox

Scenario: 02 User deletes file
	Given File is in the dropbox
	When Delete method is called
	Then File is no longer on the dropbox

Scenario: 03 User recieves metadata
	Given File is in the dropbox
	When Metadata method is called
	Then Metadata.txt is generated