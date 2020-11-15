using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bank : MonoBehaviour
{
    private const string BANK_KEY = "SCORE";
    public int Balans { get; private set; }
    [SerializeField] private int balans;

    private void Awake()
    {
        AddToBank(PlayerPrefs.GetInt(BANK_KEY));
    }
    public void AddToBank(int amount)
    {
        balans += amount;
        Balans += amount;
        PlayerPrefs.SetInt(BANK_KEY, Balans);
    }
    [Button]
    private void ClearPreff()
    {
        PlayerPrefs.DeleteAll();
    }
}
