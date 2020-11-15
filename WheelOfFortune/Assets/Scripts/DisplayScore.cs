using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int m = 1000000;
    private int k = 1000;

    private int remaainder;
    public void SetScore(int score)
    {
        if (score >= m)
        {
            remaainder = score % m;
            scoreText.text = (score / m).ToString() + "m";
            if (remaainder >= k)
            {
                scoreText.text += (remaainder / k).ToString() + "k";
            }
            return;
        }
        if (score >= k)
        {
            scoreText.text = (score / k).ToString() + "k";
        }
    }
}
