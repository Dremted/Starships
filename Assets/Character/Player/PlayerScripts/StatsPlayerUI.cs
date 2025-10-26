using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class StatsPlayerUI : MonoBehaviour
{
    public CanvasGroup containStats;
    public GameObject[] slots;

    private bool OpenMenuStats = false;

    private void Start()
    {
        UpdateAllStats();
    }

    public void MenuStats(InputAction.CallbackContext context)
    {
        if(!OpenMenuStats)
        {
            containStats.alpha = 1;
            OpenMenuStats = true;
            UpdateAllStats();
            Time.timeScale = 0;
        }
        else
        {
            containStats.alpha = 0;
            OpenMenuStats = false;
            UpdateAllStats();
            Time.timeScale = 1;
        }

    }

    public void UpdateSpeed()
    {
        slots[0].GetComponentInChildren<TMP_Text>().text = "Speed: " + ManagerStatsPlayer.Instance.speedMove.ToString();
    }

    private void UpdateAllStats()
    {
        UpdateSpeed();
    }
}
