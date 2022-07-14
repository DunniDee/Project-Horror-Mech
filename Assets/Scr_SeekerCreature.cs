
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SeekerCreature : MonoBehaviour
{
    [SerializeField] Transform MechPos;
    [SerializeField] Rigidbody RB;
    [SerializeField] DynamicBone DB;
    [SerializeField] Transform LookTowards;
    [SerializeField] float Speed;
    [SerializeField] float SpeedDampening;
    [SerializeField] Animator Anim;
    [SerializeField] float AnimTime;
    [SerializeField] Collider Col;
    [SerializeField] PhysicMaterial PM;
    float AnimTimer;
    int AnimIndex;
    public bool IsDead = false;
    
    

    // Start  is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (AnimTimer > 0)
            {
                AnimTimer-= Time.deltaTime;
            }
            else
            {
                float temp = Random.Range(0,4);
                AnimIndex = Mathf.RoundToInt(temp);

                switch (AnimIndex)
                {
                    case 0:
                    Anim.SetTrigger("Walk2");
                    //SpeedDampening = 0.25f;
                    break;  

                    case 1:
                    Anim.SetTrigger("Walk3");
                    SpeedDampening = 0;
                    RB.AddForce(transform.up * Random.Range(5,10), ForceMode.VelocityChange);
                    
                    break;

                    case 2:
                    Anim.SetTrigger("Walk4");
                    //SpeedDampening = 0.25f;
                    RB.AddForce(transform.right * 6, ForceMode.VelocityChange);
                    
                    
                    break;

                    case 3:
                    Anim.SetTrigger("Walk5");
                    //SpeedDampening = 0.25f;
                    RB.AddForce(-transform.right * 6, ForceMode.VelocityChange);
                    
                    
                    break;
                    
                    default:
                    break;
                }

                AnimTimer = Random.Range(1,3);
            }

            RB.AddForce(Vector3.down * 6, ForceMode.Acceleration);
            SpeedDampening = Mathf.Lerp(SpeedDampening, 0.85f, Time.deltaTime * 2);
            LookTowards.LookAt(MechPos);
            transform.rotation = Quaternion.Lerp(transform.rotation,LookTowards.rotation, Time.deltaTime * 5);
            RB.AddForce(transform.forward * Speed, ForceMode.Acceleration);
            RB.AddForce(-RB.velocity * SpeedDampening, ForceMode.Acceleration);   
        }
        else
        {
            RB.AddTorque(-RB.angularVelocity * 0.05f);
        }
    }

    public void Die()
    {
        IsDead = true;
        Anim.enabled = false;
        RB.AddForce(Vector3.up * 15, ForceMode.VelocityChange);
        DB.enabled = true;
        RB.AddTorque(new Vector3(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1)) * Random.Range(25,50),ForceMode.VelocityChange);
        Col.material = PM;
    }
}
