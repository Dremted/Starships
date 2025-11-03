using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Items/Buff")]
public class ItemSO : ScriptableObject
{
    [Header("Information")]
    public string buffName;
    public Sprite itemSprite;
    [TextArea] public string description;


    [Header("Stats")]
    public int maxHealth;
    public int currentHealth;
    public int speed;
    public int amount;

    [Header("TimeToActive")]
    public float duration;
}
