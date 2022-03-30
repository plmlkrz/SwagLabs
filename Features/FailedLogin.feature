Feature: LoginFailed

As a Swag Labs customer who is not locked out, I need to be able to log in so that I can purchase Sauce Labs merch

@Login
Scenario: Failed Login
	Given I am on the Sauce Demo Login Page
    When I fill out "<Username>" into the Username field and the "<Password>" field
        And I click the Login Button
    Then I verify the Error Message contains the text "<ErrorMessage>"


Examples: 
| Username        | Password     | ErrorMessage                      |
| locked_out_user | secret_sauce | Sorry, this user has been banned. |
