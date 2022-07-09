using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SeekerCreature : MonoBehaviour
{
    [SerializeField] Transform MechPos;
    [SerializeField] Rigidbody RB;

    [SerializeField] Transform LookTowards;

    // Start  is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookTowards.LookAt(MechPos);
        transform.rotation = Quaternion.Lerp(transform.rotation,LookTowards.rotation, Time.deltaTime * 5);
        RB.AddForce(transform.forward * 5, ForceMode.Acceleration);
        RB.AddForce(-RB.velocity * 0.8f, ForceMode.Acceleration);
    }
}
