using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CopyTransform : MonoBehaviour
{
    [SerializeField] Transform Other;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Other.rotation;
        transform.rotation*= Quaternion.Euler(0,180,0);
    }
}
