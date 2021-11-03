Feature: LoginFeature
	In order to purchase anything on sample site 
	user must need to be logged in

 Scenario Outline: Login With Valid Credintials
Given User must need to login before purchasing
When User provide Valid "<Email>" and "<Password>"
And Select the Login Button
Then User must be Logged in to Sample Site Successfully

Examples: 
| Email                      | Password |
| salmanarshad1830@gmail.com | MTIzNDU2 |


Scenario Outline: Login With InValid Credintials
Given User Try to login with invalid credentials
When User provide InValid "<Email>" and "<Password>"
And Select the Login Button
Then User must be not allowed to logged in to the sample site 

Examples: 
| Email                      | Password |
| salmanarshad1830@gmail.com | MTIzNDU3 |


