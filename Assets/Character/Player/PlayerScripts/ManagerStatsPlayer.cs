using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerStatsPlayer : MonoBehaviour
{
    public static ManagerStatsPlayer Instance;
    public TMP_Text textHealth;
    public StatsPlayerUI statsPlayerUI;

    [Header("Movement")]
    public float speedMove;
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateCurrentHealth(int amount)
    {
        currentHealth += amount;
        UpdateUI();
    }

    public void UpdateMaxealth(int amount)
    {
        maxHealth += amount;
        UpdateUI();
    }

    public void UpdateSpeed(int amount)
    {
        speedMove += amount;
    }

    public void UpdateUI()
    {
        textHealth.text = currentHealth.ToString() + "" + maxHealth.ToString();
        statsPlayerUI.UpdateAllStats();
    }
}

