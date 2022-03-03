Feature: Order Discount
	First time users have discount
	As a first time user
	I want to get 10% discount on my order
	

	Scenario: First time users should get 10% discount
		Given I am a first time user
		And an empty basket  
		When a 100 € t-shirt is added to basket
		Then the basket value is 90 €


	Scenario: Regular users should pay full price
		Given I am not a first time user
		And an empty basket
		When a 40 € dress is added to basket
		Then the basket value is 40 €
