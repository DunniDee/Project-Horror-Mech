using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CopyYTransform : MonoBehaviour
{
    [SerializeField] Transform Copy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Copy.rotation;
    }
}
