using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CopyTransform : MonoBehaviour
{
    [SerializeField] Transform Other;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Other.rotation;
        transform.localRotation *= Quaternion.Euler(0,180,0);
    }
}
