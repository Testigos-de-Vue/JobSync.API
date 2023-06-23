Feature: ProcessServiceTests
	As a Developer
	I want to add a new Process through API
	In order to make it available for the application.
	
	Background:
		Given the Endpoint http://localhost:5059/api/v1/recruitment/processes is Available

@process-adding
Scenario: Add Recruitment Process
	When a Post Request is sent
		| Name      | Description   | Starting Date | Ending Date | Status |
		| Process 1 | Description 1 | 2019-01-01    | 2019-01-31  | 1      |
	Then A Response is received with Status Code 201
	And a Process Resource is included in Response Body
	| Id | Name      | Description   | Starting Date | Ending Date | Status |
	| 1  | Process 1 | Description 1 | 2019-01-01    | 2019-01-31  | 1      |
 
@process-deleting
Scenario: Delete Recruitment Process
	When a Delete Request is sent
		| Id |
		| 1  |
	Then A Response is received with Status Code 201
	And the Process with Id 1 is deleted
	
@process-deleting
Scenario: Delete Recruitment Process that does not exist
	When a Delete Request is sent
	  | Id |
	  | 1  |
   	And Process with Id 1 does not exist
	Then A Response is received with Status Code 400
	And An Error Message is returned with Value "Process does not exist"