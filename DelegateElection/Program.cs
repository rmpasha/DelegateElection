using System;

namespace DelegateElection
{
    class Program
    {
        public struct candidates {
            public string name;
            public int netCount;
            public string result;
        }
        static void Main(string[] args)
        {
            //Assume, there are 7 candidates and NetCount has already been calculated on descending order
            //Change the NetCount values in descending order for testing with different possible Netcount votes
            candidates[] delegateCandidates = new candidates[7];
            delegateCandidates[0].name = "FirstName1 LastName1";
            delegateCandidates[0].netCount = 50;
            delegateCandidates[1].name = "FirstName2 LastName2";
            delegateCandidates[1].netCount = 18;
            delegateCandidates[2].name = "FirstName3 LastName3";
            delegateCandidates[2].netCount = 2;
            delegateCandidates[3].name = "FirstName4 LastName4";
            delegateCandidates[3].netCount = 2;
            delegateCandidates[4].name = "FirstName5 LastName5";
            delegateCandidates[4].netCount = 2;
            delegateCandidates[5].name = "FirstName6 LastName6";
            delegateCandidates[5].netCount = 1;
            delegateCandidates[6].name = "FirstName7 LastName7";
            delegateCandidates[6].netCount = -17;


            //Number of availabe spots for delegate position
            int numToBeElected = 4; 

            if (delegateCandidates.Length <= numToBeElected)
            {
                for (int i = 0; i < delegateCandidates.Length; i++)
                {
                    SetWinnerOrLose(ref delegateCandidates[i]);
                }
            }
            else        //If number of candidates is greater than number of positions to be elected
            {
                if (Convert.ToInt32(delegateCandidates[numToBeElected - 1].netCount) != Convert.ToInt32(delegateCandidates[numToBeElected].netCount))
                {
                    for (int i = 0; i < delegateCandidates.Length; i++)
                    {
                        if (i < numToBeElected)
                            SetWinnerOrLose(ref delegateCandidates[i]);
                        else
                            delegateCandidates[i].result = "Lose";
                    }
                }
                else
                {
                    int i = numToBeElected - 1;
                    //SET TIE
                    SetTieOrLose(ref delegateCandidates[i]);

                    //Front Track for TIE case
                    while (i < delegateCandidates.Length - 1 && Convert.ToInt32(delegateCandidates[i].netCount) == Convert.ToInt32(delegateCandidates[i + 1].netCount))
                    {
                        SetTieOrLose(ref delegateCandidates[i + 1]);
                        i++;
                    }
                    for (int k = i+1; k < delegateCandidates.Length; k++)
                    {
                        delegateCandidates[k].result = "Lose";
                    }
                    //Back Track for TIE Case
                    int j = numToBeElected - 1;
                    while (j != 0 && delegateCandidates[j].netCount == delegateCandidates[j - 1].netCount)
                    {
                        SetTieOrLose(ref delegateCandidates[j - 1]);
                        j--;
                    }
                    for (int k = 0; k < j; k++)
                    {
                        SetWinnerOrLose(ref delegateCandidates[k]);
                    }
                }
            }

            //Display Results
            foreach (candidates cd in delegateCandidates)
            {
                Console.WriteLine("Name: {0} , NetCount: {1} , Result: {2}", cd.name, cd.netCount, cd.result);
            }
            Console.ReadLine();
        }

        private static void SetWinnerOrLose(ref candidates delegateCandidates)
        {
            if (delegateCandidates.netCount > 0)     //if +ve votes
            {
                delegateCandidates.result = "Winner";
            }
            else
            {
                delegateCandidates.result = "Lose";
            }
        }
        private static void SetTieOrLose(ref candidates delegateCandidates)
        {
            if (delegateCandidates.netCount > 0)     //if +ve votes
            {
                delegateCandidates.result = "TIE";
            }
            else
            {
                delegateCandidates.result = "Lose";
            }
        }
    }
}
