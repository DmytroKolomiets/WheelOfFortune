using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelSegment : MonoBehaviour
{
    [SerializeField] private Text segmentText;
    public int RewardAmount { get; private set; }
    
    public void SetText(int rewardAmount)
    {
        RewardAmount = rewardAmount;
        segmentText.text = RewardAmount.ToString();
    }
}
