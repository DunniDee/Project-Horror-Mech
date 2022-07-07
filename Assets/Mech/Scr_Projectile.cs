using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Projectile : MonoBehaviour
{
    [SerializeField] float Speed;
    Vector3 PreviousPos;

    // Update is called once per frame
    void Update()
    {
        PreviousPos = transform.position;
        transform.position = transform.position + transform.forward * Time.deltaTime * Speed;

        if (Physics.Raycast(PreviousPos, transform.forward, Time.deltaTime * Speed))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
