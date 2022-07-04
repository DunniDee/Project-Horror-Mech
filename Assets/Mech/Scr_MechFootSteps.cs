using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechFootSteps : MonoBehaviour
{
    [SerializeField] Scr_MechMovement Movment;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip StepSound;
    [SerializeField] Animator CamAnim;
    [SerializeField] Animator ShakeAnim;
    [SerializeField] Animator PilotAnim;

    float VelocityLerp = 0;

    void Start()
    {
       Movment = gameObject.GetComponentInParent<Scr_MechMovement>(); 
    }
    
    public void Step()
    {
        AS.pitch =Random.Range(0.9f,1f);
        AS.PlayOneShot(StepSound);
        ShakeAnim.SetTrigger("Shake");
        PilotAnim.SetTrigger("Shake");
    }

    private void Update()
    {
        if (Movment.GetHorizontalInput() == Vector2.zero)
        {
           VelocityLerp -= Time.deltaTime * 5;
        }
        else
        {
            VelocityLerp += Time.deltaTime * 5;
        }   
        
        VelocityLerp = Mathf.Clamp01(VelocityLerp);
        CamAnim.SetFloat("Velocity", VelocityLerp); 
    }
}
