using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    public float bonusIncreaseRate = 1f;
    public float bonusMulitplyRate = 1f;
    public float currentSpeed = 1;
    public float currentDamage = 0;
    public int gateType; // 0: Speed 1: Damage
    private string[] gates = { "Speed", "Damage" };

    HandleBonus handleBonus;
            

    public TextMeshPro textMeshPro;

    private void Start()
    {
        if (gateType == 1)
            textMeshPro.text = $"<color=red>{gates[gateType]}" + $" <color=red>\n{currentSpeed}</color>";
        else
            textMeshPro.text = $"<color=green>{gates[gateType]}" + $"<color=green>\n{currentDamage}</color>";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwordBblade"))
        {
            handleBonus = other.GetComponent<HandleBonus>();
            if (gateType == 0)
            {
                handleBonus.ApplyBonus(bonusMulitplyRate, gateType);
                currentSpeed += currentSpeed*bonusMulitplyRate;
            }
            else
            {
                handleBonus.ApplyBonus(bonusIncreaseRate, gateType);
                currentDamage += bonusIncreaseRate;
            }
            
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
            

    }
}
