using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStatsPlayer : MonoBehaviour
{
    public static ManagerStatsPlayer Instance;

    [Header("Movement")]
    public float speedMove;
    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        Instance = this;
    }
}

