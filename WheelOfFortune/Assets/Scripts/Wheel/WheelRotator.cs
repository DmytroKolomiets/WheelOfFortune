using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine.Events;

public class WheelRotator : MonoBehaviour
{
    [SerializeField] private Transform wheel;
    [SerializeField] private float speed;
    WheelRewardGenerator generator = new WheelRewardGenerator();
    public UnityAction<int> OnWheelStop;
    private float rotationAmount;
    private int winningSegment;

    public void Rotate(int wheelSegments)
    {
        Debug.Log("Rotating...");
        wheel.transform.eulerAngles = Vector3.zero;
        rotationAmount = GetWheelRotationAmount(wheelSegments);
        wheel.DORotate(new Vector3(0f, 0f, -rotationAmount), speed, RotateMode.FastBeyond360)
            .OnComplete(() => 
            {
                OnWheelStop?.Invoke(winningSegment);
            });
    } 
    private float GetWheelRotationAmount(int wheelSegments)
    {
        // + 360 to make sure that wheel will rotate at least for 360 dergee
        winningSegment = Random.Range(0, wheelSegments + 1);
        return (winningSegment * GetWheelStep(wheelSegments)) + 360;
    }
    private float GetWheelStep(int wheelSegments)
    {
        return 360f / wheelSegments;
    }
}
