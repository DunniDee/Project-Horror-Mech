using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Projectile : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip ImpactSound;
    [SerializeField] bool HasHit = false;

    [SerializeField] GameObject ExplosionPrefab;

    Vector3 PreviousPos;

    // Update is called once per frame
    void Update()
    {
        PreviousPos = transform.position;
        transform.position = transform.position + transform.forward * Time.deltaTime * Speed;

        RaycastHit Hit;
        if (Physics.Raycast(PreviousPos, transform.forward,out Hit, Time.deltaTime * Speed) && !HasHit)
        {
            Debug.Log("Hit");
            Destroy(gameObject,1);
            AS.PlayOneShot(ImpactSound);
            HasHit = true;
            // GameObject expl = Instantiate(ExplosionPrefab,Hit.point, Quaternion.identity);
            // expl.transform.LookAt(Hit.normal);
        }
    }
}
