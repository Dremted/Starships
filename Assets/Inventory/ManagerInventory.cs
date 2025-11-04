using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class ManagerInventory : MonoBehaviour
{
    public TMP_Text textStar;

    public int starsCounter;
    public InventorySlot[] slots;


    private void Start()
    {
        foreach (InventorySlot slot in slots)
        {
            slot.UpdateUI();
        }
    }

    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }

    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }

    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (itemSO.isStar)
        {
            starsCounter += quantity;
            textStar.text = starsCounter.ToString();
            return;
        }
        else 
        {
            foreach(var slot in slots)
            {
                if(slot.itemSO == null)
                {
                    slot.itemSO = itemSO;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;
                }
            }
        }
    }

    public void UseItem(InventorySlot slot)
    {
        if(slot.quantity > 0 && slot.itemSO != null)
        {
            Debug.Log("Use item: " + slot.itemSO.name);
        }
    }
}
