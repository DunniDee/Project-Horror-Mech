using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CreatureOnHull : MonoBehaviour
{
    [SerializeField] Scr_MechCollisions Collider;
    [SerializeField] float SpinSpeed;
    [SerializeField] AudioSource Sounds;
    [SerializeField] BoxCollider Box;
    [SerializeField] AudioClip DeathSound;

    public bool IsMounted = true;
    public bool HasDied;

    float MoveTime;
    float StayTime;
    float rotation;





    // Update is called once per frame
    void Update()
    {
        if (IsMounted)
        {
            HasDied = false;
            Sounds.volume = Mathf.Lerp(Sounds.volume,1, Time.deltaTime);
            Box.enabled = true;
            if (MoveTime > 0)
            {
                MoveTime-= Time.deltaTime;
                rotation += SpinSpeed * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(0,rotation,0);
            }
            else if (StayTime > 0)
            {
                StayTime -= Time.deltaTime;
            }
            else
            {
                MoveTime = Random.Range(1,5);
                StayTime = Random.Range(1,5);
                SpinSpeed = Random.Range(-90,90);
            }   
        }
        else
        {
            Sounds.volume = Mathf.Lerp(Sounds.volume,0, Time.deltaTime);
            Box.enabled = false;
        }

        if (Collider.IsColliding)
        {
            if(Physics.Raycast(transform.position - Vector3.down * 2,transform.forward,5) && !HasDied)
            {
                IsMounted = false;
                Sounds.PlayOneShot(DeathSound);
                HasDied = true;
            }
        }
    }
}
