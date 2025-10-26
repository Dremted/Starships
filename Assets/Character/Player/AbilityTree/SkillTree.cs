using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public SkillCell[] skillCells;
    public int currentOP;
    public TMP_Text textOP;

    private void Start()
    {
        foreach (SkillCell cell in skillCells)
        {
            cell.buttonSkill.onClick.AddListener(() => CheckSkillPoint(cell));
        }
    }

    private void CheckSkillPoint(SkillCell cell)
    {
        if(currentOP > 0)
            cell.TryUpdateCell();
    }


}
