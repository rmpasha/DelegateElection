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
            candidates[] delegateCandidates = new candidates[7];

            int numToBeElected = 4; //Spots for delegate position

            if (delegateCandidates.Length <= numToBeElected)
            {
                for (int i = 0; i < delegateCandidates.Length; i++)
                {
                    SetResult(delegateCandidates[i]);
                    //if (Convert.ToInt32(delegateCandidates[i].netCount) > 0)     //if +ve votes
                    //{
                    //    delegateCandidates[i].result = "Winner";
                    //}
                    //else
                    //{
                    //    delegateCandidates[i].result = "Lose";
                    //}
                }
            }
            else        //If number of candidates is greater than number of positions to be elected
            {
                if (Convert.ToInt32(delegateCandidates[numToBeElected - 1].netCount) != Convert.ToInt32(delegateCandidates[numToBeElected].netCount))
                {
                    for (int i = 0; i < numToBeElected; i++)
                    {
                        if (i < numToBeElected && delegateCandidates[i].netCount > 0)
                        {
                            delegateCandidates[i].result = "Winner";
                        }
                        else
                        {
                            delegateCandidates[i].result = "Lose";
                        }
                    }
                }
                else
                {
                    int i = numToBeElected - 1;
                    if (delegateCandidates[i].netCount > 0)
                        delegateCandidates[i].result = "TIE";
                    else
                        delegateCandidates[i].result = "Lose";
                    //Front Track
                    while (i < delegateCandidates.Length - 1 && Convert.ToInt32(delegateCandidates[i].netCount) == Convert.ToInt32(delegateCandidates[i + 1].netCount))
                    {
                        if (delegateCandidates[i].netCount > 0)
                            delegateCandidates[i].result = "TIE";
                        else
                            delegateCandidates[i].result = "Lose";
                        i++;
                    }
                    //Back Track
                    int j = numToBeElected - 1;
                    while (j != 0 && delegateCandidates[j].netCount == delegateCandidates[j - 1].netCount)
                    {
                        if (delegateCandidates[i].netCount > 0)
                            delegateCandidates[i].result = "TIE";
                        else
                            delegateCandidates[i].result = "Lose";
                        j--;
                    }
                    for (int k = 0; k < j; k++)
                    {
                        if (delegateCandidates[i].netCount > 0)     //if +ve votes
                        {
                            delegateCandidates[i].result = "Winner";
                        }
                        else
                        {
                            delegateCandidates[i].result = "Lose";
                        }
                    }
                }
            }
        }

        private static void SetResult(candidates delegateCandidates)
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
    }
}
