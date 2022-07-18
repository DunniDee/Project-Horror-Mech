using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CreatureSpawnTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyList;    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.name == "Mech_Agent")
        {
            foreach (var Enemy in EnemyList)
            {
                Enemy.SetActive(true);
            }  
        }    
    }
}
