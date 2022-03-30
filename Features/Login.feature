Feature: Login

As a Swag Labs customer who is not locked out, I need to be able to log in so that I can purchase Sauce Labs merch

@Login
Scenario: Successful Login
	Given I am on the Sauce Demo Login Page
    When I fill out "<Username>" into the Username field and the "<Password>" field
        And I click the Login Button
    Then I am redirected to the Sauce Demo Main Page
        And I verify the App Logo exists

Examples: 
| Username      | Password     |
| standard_user | secret_sauce |