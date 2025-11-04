using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSO itemSO;
    public int quantity;


    public TMP_Text textSlotQuantity;
    public Image iconSlot;

    private ManagerInventory managerInventory;

    private void Start()
    {
        managerInventory = GetComponentInParent<ManagerInventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(quantity > 0)
        {
            if (PointerEventData.InputButton.Left == eventData.button)
            {
                managerInventory.UseItem(this);
            }
        }
    }

    public void UpdateUI()
    {
        if(itemSO != null)
        {
            iconSlot.sprite = itemSO.itemSprite;
            iconSlot.gameObject.SetActive(true);
            textSlotQuantity.text = quantity.ToString();
        }
        else
        {
            iconSlot.gameObject.SetActive(false);
            textSlotQuantity.text = "";
        }
    }
}
