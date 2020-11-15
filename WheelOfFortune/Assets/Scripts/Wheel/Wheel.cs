using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private WheelSegment wheelSegment;
    private List<int> rewardList = new List<int>();
    private List<WheelSegment> wheelSegments = new List<WheelSegment>();
    [SerializeField] private int segmentsCount;
    [SerializeField] private int minReward;
    [SerializeField] private int maxReward;
    [SerializeField] private int multiplicity;
    private WheelRewardGenerator rewardGenerator = new WheelRewardGenerator();
    private WheelSegment temperaryWheelSegment;
    private Vector3 segmentRotation = new Vector3();
    
    private void Awake()
    {
        CreatWheel();
    }
    public int GetSegmentsCount()
    {
        return segmentsCount;
    }
    public int GetReward(int segment)
    {
        return rewardList[segment];
    }
    private void CreatWheel()
    {
        rewardList = rewardGenerator.GetRewardsList(minReward, maxReward, segmentsCount, multiplicity);
        for (int i = 0; i < segmentsCount; i++)
        {
            wheelSegments.Add(CreatSegment());
            wheelSegments[i].SetText(rewardList[i]);
        }
    }
    private WheelSegment CreatSegment()
    {
        temperaryWheelSegment = Instantiate(wheelSegment, transform);      
        temperaryWheelSegment.transform.eulerAngles = segmentRotation;
        segmentRotation.z += 360f / segmentsCount;

        return temperaryWheelSegment;
    }
}
