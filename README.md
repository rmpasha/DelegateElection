# Delegate Election

A general election where many candidates are running for only one position or one spot, it is very easy to decide a winner since the candidate who gets the highest number of votes becomes the winner. If we use a computer program to decide a winner for this scenario, it will be a very simple method to calculate the result.

But here, I am going to talk about an election where it is not that simple like I mentioned above.

It is a Delegate election. An organization might need many delegates, maybe 5,000 to 10,000. It will be a very hard job or takes longer if we elect only one winner in one election to have 5000 or more delegates. So, let’s think that an election might have many candidates and multiple candidates can be the winners from one election if the number of available spots for delegate positions are more than one. Let’s assume the following possible criteria.

### Delegate Election Criteria's
- An election can have multiple candidates and can be multiple winners for the same position, the number of winners cannot be exceeded more than the available spots of delegate position.
- An election where voters can vote with a Yes vote or No vote for each candidate.
- An election where the number of votes is calculated using formula Yes Vote minus No Vote and this will be the Net Vote count.
- An election where a candidate loses an election if he/she gets negative (-ve) Net count vote. To become a winner, the candidate must have to get at least one positive (+ve) Net count vote and fulfil another requirement as well. Another requirement means, there should be enough available spots and the positive (+ve) Net count vote should be higher than others.

Since an election can have multiple winners, voting can be YES, or NO votes as mentioned above criteria, the method to decide the winners is very complex and you need to know all those available options to become a winner and to be a loser. Since this is all about the election, the program should always correctly announce the winner or loser.
Let’s try to dig into this scenario and try to simplify the possible cases.

### Case Study
1. Assume that the number of candidates running are the same or less than the available spots for delegate positions.
- In this case, all the candidates who get the positive (+ve) Net count votes will become a winner and whoever gets negative (-ve) Net count votes will be a loser. In this case, we don’t care about the TIE option.
2. Assume that the available spots for delegate positions are N but more than N candidates are running the elections.
- In this case, find if there is a TIE case (having save +ve Net count votes) between Nth candidate and (N+1) the candidate, if it is not TIE, all candidates from 0 to Nth candidates become the winners and all others losers. Here, we are assuming that the candidates are already sorted by Net count votes from highest to lowest.
- If it is TIE between the Nth candidate and (N+1) the candidate, look for (N+2)th candidate for the TIE case as well. If (N+1)th is not the TIE case, stop looking further, otherwise continue.
- If a TIE case occurred at Nth, look backward as well, whether Nth and (N-1)th candidates are TIE or not. If not, stop right there, otherwise continue.

The program implementation for these scenarios can be done in different ways but I found the checking for TIE case at Nth candidate with (N+1)th candidate is the most effective way and free from the issues.

Here are some pseudo codes

### Pseudo Codes/Algorithm
```
Sort all Candidates by Net count votes by highest to lowest
If Num_Of_Candidates <= Num_Of_Available_Spots
	LOOP for Num_Of_Candidates
	If Candidate has the +ve Net count vote
		Winner
	Else
		Loser
LOOP End
Else
	If Nth Candidate Net count vote != (N+1)th Candidate Net count vote
		LOOP until Num_Of_Available_Spots
		If Candidate has the +ve Net count vote
			Winner
		Else
			Loser
		LOOP End
	Else
		If Nth Candidate has +ve Net count vote
			Nth Candidate result = TIE
			(N+1)th Candidate result = TIE
		Look for (N-1) candidate for TIE case and Loop until TIE
Look (N+2)th candidate for TIE case and Loop until TIE

```


#### Author
##### Rajendra Maharjan
