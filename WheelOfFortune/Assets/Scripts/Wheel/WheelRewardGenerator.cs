using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRewardGenerator
{
    public List<int> GetRewardsList(int minReward, int maxReward, int wheelSegments, int multiplicity)
    {
        if (IsBadInput(minReward, maxReward, wheelSegments, multiplicity)) return null;

        // first part of making list multiple of multiplicity 
        minReward /= multiplicity;
        maxReward /= multiplicity;

        List<int> RandomizedUniqeNumbers = GetUniqeNumbers(minReward, maxReward, wheelSegments);

        // second part of making list multiple of multiplicity 
        for (int i = 0; i < RandomizedUniqeNumbers.Count; i++)
        {
            RandomizedUniqeNumbers[i] *= multiplicity;
        }
        return RandomizedUniqeNumbers;
    }
    private List<int> GetUniqeNumbers(int min, int max, int count)
    {      
        int ranomNumber = 0;
        List<int> RandomizedUniqeNumbers = new List<int>();
        for (int i = 0; i < count; i++)
        {
            while (true)
            {
                ranomNumber = Random.Range(min, max + 1);
                if (!RandomizedUniqeNumbers.Contains(ranomNumber))
                {
                    RandomizedUniqeNumbers.Add(ranomNumber);
                    break;
                }
            }
        }
        return RandomizedUniqeNumbers;
    }
    private bool IsBadInput(int minReward, int maxReward, int wheelSegments, int multiplicity)
    {
        if (maxReward - minReward < wheelSegments)
        {
            Debug.LogError("wheelSegments must be less or equal then possible range of rewards");
            return true;
        }
        else if ((maxReward - minReward) / multiplicity < wheelSegments)
        {
            Debug.LogError("multiplicity must be small enough to get wheelSegments less or equal then possible range of rewards");
            return true;
        }
        return false;
    }  
}
