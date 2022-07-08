using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CreatureOnHull : MonoBehaviour
{
    [SerializeField] Scr_MechCollisions Collider;
    [SerializeField] float SpinSpeed;
    [SerializeField] AudioSource HullSounds;
    [SerializeField] AudioSource CreatureSounds;
    [SerializeField] BoxCollider Box;

    [SerializeField] GameObject DeadPrefab;
    [SerializeField] AudioClip DeathSound;

    [SerializeField] Scr_CockpitTilter Tilt;



    public bool IsMounted = true;
    public bool HasDied;

    public bool WasColliding;

    float MoveTime;
    float StayTime;
    float rotation;

    // Update is called once per frame
    void Update()
    {
        if (IsMounted)
        {
            HasDied = false;
            HullSounds.volume = Mathf.Lerp(HullSounds.volume,1, Time.deltaTime);
            Box.enabled = true;

            //TiltLerp();

            if (MoveTime > 0)
            {
                MoveTime-= Time.deltaTime;
                rotation += SpinSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, SpinSpeed * Time.deltaTime);
                CreatureSounds.volume = Mathf.Lerp(CreatureSounds.volume,0, Time.deltaTime);
            }
            else if (StayTime > 0)
            {
                StayTime -= Time.deltaTime;
                CreatureSounds.volume = Mathf.Lerp(CreatureSounds.volume,1, Time.deltaTime);
            }
            else
            {
                MoveTime = Random.Range(1,5);
                StayTime = Random.Range(1,5);
                SpinSpeed = Random.Range(-90,90);
                CreatureSounds.volume = Mathf.Lerp(CreatureSounds.volume,0, Time.deltaTime);
            }   
        }
        else
        {
            HullSounds.volume = Mathf.Lerp(HullSounds.volume,0, Time.deltaTime);
            CreatureSounds.volume = Mathf.Lerp(CreatureSounds.volume,0, Time.deltaTime);
            Box.enabled = false;
        }

        if (Collider.IsColliding && !WasColliding)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position - Vector3.down * 2,transform.forward,out hit,5) && !HasDied)
            {
                GameObject DeadCreature = Instantiate(DeadPrefab,hit.point, transform.rotation);
                DeadCreature.transform.LookAt(transform);
                IsMounted = false;
                HullSounds.PlayOneShot(DeathSound);
                HasDied = true;
            }
        }

        WasColliding = Collider.IsColliding;
    }


    void TiltLerp()
    {
        float x;
        float y;

        float Angle = transform.localRotation.y;

        x = Mathf.Cos(Angle) * 15;
        y = Mathf.Sin(Angle) * 15;

        Tilt.RotateTo += new Vector3(-x,0,y) * Time.deltaTime;
    }
}
