Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@TestClient

Scenario Outline: Recuperation d'un client
Given un repository client fake
And un client existant
When je recupere le client par selon l Id <ID>
Then j'obtient le client

Examples:  
| ID |
|  1 |
|  2 |