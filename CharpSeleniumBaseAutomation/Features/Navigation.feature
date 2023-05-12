Feature: Navigation

A short summary of the feature

@Navigation
Scenario: Basic Website Navigation
	Given I navigate to "https://www.google.com" and validate the page title has "Google"
	Then I Search for "Automation" on Google home page and Check I have more than "1" results