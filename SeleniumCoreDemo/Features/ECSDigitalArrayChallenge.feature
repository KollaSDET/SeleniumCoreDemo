Feature: ECSDigitalArrayChallenge
	As an applicant for a Given JobRole
	I want to read rows from an ArrayChallenge
	So that the correct results were been submittted over the ECS Digital application. 

@ECSDigital
Scenario: Verify Digital Challenge Balanced Array row index
	Given I have launched ECS digital home page
	And I have clicked on Render the Challenge button
	When I have read the Array Challenge table for row "0"
	Then I should see array index for "4"
	And I have entered the Array indices as results along my name "Srihari Kolla" 
	Then I should see below successful message
	| Message                                                          |
	| Congratulations you have succeeded. Please submit your challenge |

@ECSDigital
Scenario: Validate Error message for submission of invalid data 
	Given I have launched ECS digital home page
	And I have clicked on Render the Challenge button
	Then I have clicked on Submit Answers button
	Then I should see below unsuccessful message
	| Message |
	| It looks like your answer wasn't quite right |

	