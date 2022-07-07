using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_AmmoShell : MonoBehaviour
{
    [SerializeField] bool IsHeld;
    [SerializeField] Rigidbody RB;
    public Vector3 FollowPoint;

    public bool ToDestroy = false;

    // Update is called once per frame
    void Update()
    {
        if (IsHeld)
        {
            transform.position = Vector3.Lerp(transform.position, FollowPoint, Time.deltaTime * 6);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(90,0,0), Time.deltaTime * 6);
        }

        RB.isKinematic = IsHeld;
    }
}
