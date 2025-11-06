using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public void ApplyItemEffect(ItemSO itemSO)
    {
        if(itemSO.speed > 0)
        {
            ManagerStatsPlayer.Instance.UpdateSpeed(itemSO.speed);
        }
        if (itemSO.currentHealth > 0)
        {
            ManagerStatsPlayer.Instance.UpdateCurrentHealth(itemSO.currentHealth);
        }
        if(itemSO.maxHealth > 0)
        {
            ManagerStatsPlayer.Instance.UpdateMaxealth(itemSO.maxHealth);
        }
        if (itemSO.duration > 0)
        {
            StartCoroutine(EffectTimer(itemSO, itemSO.duration));
        }
    }

    public IEnumerator EffectTimer(ItemSO itemSO, float duratation)
    {
        yield return new WaitForSeconds(duratation);

        if (itemSO.speed > 0)
        {
            ManagerStatsPlayer.Instance.UpdateSpeed(-itemSO.speed);
        }
        if (itemSO.currentHealth > 0)
        {
            ManagerStatsPlayer.Instance.UpdateCurrentHealth(-itemSO.currentHealth);
        }
        if (itemSO.maxHealth > 0)
        {
            ManagerStatsPlayer.Instance.UpdateMaxealth(-itemSO.maxHealth);
        }
    }
}
