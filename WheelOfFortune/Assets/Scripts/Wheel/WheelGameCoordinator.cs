using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class WheelGameCoordinator : MonoBehaviour
{
    [SerializeField] private Button rotateButton;
    [SerializeField] private Wheel wheel;
    [SerializeField] private WheelRotator wheelRotator;
    [SerializeField] private Bank bank;
    [SerializeField] private DisplayScore displayScore;

    private void Start()
    {
        displayScore.SetScore(bank.Balans);
        wheelRotator.OnWheelStop += (winingSegment) =>
        {
            bank.AddToBank(wheel.GetReward(winingSegment));
            rotateButton.interactable = true;
            displayScore.SetScore(bank.Balans);
        };

        rotateButton.onClick.AddListener(() =>
        {
            rotateButton.interactable = false;
            wheelRotator.Rotate(wheel.GetSegmentsCount());
        });
    }
}
