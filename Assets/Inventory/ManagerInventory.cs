using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class ManagerInventory : MonoBehaviour
{
    public TMP_Text textStar;
    public UseItem useItem;

    public int starsCounter;
    public InventorySlot[] slots;

    public GameObject prefabItem;
    public Transform playerTransform;

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

        foreach (var slot in slots)
        {
            if(slot.itemSO == itemSO && slot.quantity < slot.stackSize)
            {
                int availabelSpace = slot.stackSize - slot.quantity;
                int ammountToAdd = Mathf.Min(availabelSpace, quantity);

                slot.quantity += ammountToAdd;
                quantity -= ammountToAdd;

                slot.UpdateUI();

                if(quantity <= 0)
                    return;
            }
        }

            foreach(var slot in slots)
            {
                if(slot.itemSO == null)
                {
                    int ammountToAdd = Mathf.Min(itemSO.stackSize, quantity);
                    slot.itemSO = itemSO;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;
                }
            }

        if (quantity > 0)
            DropLoot(itemSO, quantity);
    }

    public void DropLoot(ItemSO itemSO, int quantity)
    {
        Loot loot = Instantiate(prefabItem, playerTransform.position, Quaternion.identity).GetComponent<Loot>();
        loot.Initialize(itemSO, quantity);
    }

    public void UseItem(InventorySlot slot)
    {
        if(slot != null && slot.quantity > 0)
        {
            useItem.ApplyItemEffect(slot.itemSO);
            slot.quantity--;
            if(slot.quantity <= 0)
            {
                slot.itemSO = null;
            }
            slot.UpdateUI();
        }
    }
}
