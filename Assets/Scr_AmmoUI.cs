using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scr_AmmoUI : MonoBehaviour
{
    [SerializeField] Scr_MechWeapons Weapons;
    [SerializeField] TextMeshPro Text;
    // Update is called once per frame
    void Update()
    {
        Text.text = Weapons.AmmoCount.ToString();
    }
}
