using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DisplayHPMPBars : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image fill;

    public enum BarType
    {
        None,
        HP,
        MP
    }

    public BarType bar;

    private void UpdateBar()
    {
        Player player = InventoryManager.Instance.player;
        float currentHealth = player.GetAttributeValue(AttributeType.HP);
        float currentMana = player.GetAttributeValue(AttributeType.MP);

        if (bar == BarType.HP)
        {
            fill.fillAmount = currentHealth / player.maxHP;
            text.text = ($"HP {currentHealth} / {player.maxHP}");
        }
        else if (bar == BarType.MP)
        {
            fill.fillAmount = currentMana / player.maxMP;
            text.text = ($"HP {currentMana} / {player.maxMP}");
        }
    }

    private void Update()
    {
        UpdateBar();
    }
}
