using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_FinalShrill : MonoBehaviour
{
    [SerializeField] Animator Anim;
    [SerializeField] Animator Anim2;
    [SerializeField] AudioSource AS;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.name == "Mech_Agent")
        {
            Anim.SetTrigger("Shrill");
            Anim2.SetTrigger("Shrill");
            AS.PlayDelayed(1);      
        }    
    }
}
