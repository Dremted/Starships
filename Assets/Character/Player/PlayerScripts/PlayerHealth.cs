using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private TMP_Text textHealth;

    private void Start()
    {
        UpdateHealthUI();
    }

    private void OnEnable()
    {
        DamageStarShip.addDamage += ChangeHearth;
    }

    private void OnDisable()
    {
        DamageStarShip.addDamage -= ChangeHearth;
    }

    public void ChangeHearth(int amount)
    {
        ManagerStatsPlayer.Instance.currentHealth += amount;
        ManagerStatsPlayer.Instance.currentHealth = Mathf.Max(0 , ManagerStatsPlayer.Instance.currentHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        textHealth.text = ManagerStatsPlayer.Instance.maxHealth.ToString() + " / " + ManagerStatsPlayer.Instance.currentHealth.ToString();
    }
}
