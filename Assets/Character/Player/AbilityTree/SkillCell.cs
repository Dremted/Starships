using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCell : MonoBehaviour
{
    public List<SkillCell> cellsOpenSkill;
    public SkillOS skillOS;

    public Image iconSkill;
    public TMP_Text textSkill;
    public Button buttonSkill;
    public int currentLevelCell;
    public bool isUnlocked;

    public static event Action<SkillCell> getSkillOP;
    public static event Action<SkillCell> MaxSkill;

    public void TryUpdateCell()
    {
        if(currentLevelCell <= skillOS.maxLevelSkill)
        {
            currentLevelCell++;
            getSkillOP?.Invoke(this);
            UpgradeUI();
        }
    }

    private void UpgradeUI()
    {
        iconSkill.sprite = skillOS.iconSkill;
        if(isUnlocked)
        {
            buttonSkill.interactable = true;
            textSkill.text = currentLevelCell.ToString();
            iconSkill.color = Color.white;
        }
        else
        {
            buttonSkill.interactable= false;
            textSkill.text = "Locked";
            iconSkill.color = Color.gray;
        }
    }

}
