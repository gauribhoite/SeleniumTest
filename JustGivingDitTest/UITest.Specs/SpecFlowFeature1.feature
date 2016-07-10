Feature: Donate money to one project

@mytag
Scenario: Donate
	Given I am Justgiving homepage
	And I look for first card
	When I choose to donate "20" pounds
	Then amount displayed should be "20" on following page
	When I enter my email address and password "JGtest01"
	Then I enter card type "Visa Credit Card" card number "4111111111111111" expiry month "03" expiry year "2018" name on card "Gauri Bhoite"
	Then I close


