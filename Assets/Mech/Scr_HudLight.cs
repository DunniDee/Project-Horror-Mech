using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_HudLight : MonoBehaviour
{
    [SerializeField] Material OffMat; 
    [SerializeField] Material OnMat; 

    MeshRenderer Mesh;

    public bool IsOn;

    protected private void Start() 
    {
        Mesh = gameObject.GetComponent<MeshRenderer>();
    }

    protected private void Update()
    {
        CheckLight();
    }

    protected void CheckLight()
    {
                if (IsOn)
        {
            Mesh.material = OnMat;
        }
        else
        {
            Mesh.material = OffMat;   
        }
    }


}
