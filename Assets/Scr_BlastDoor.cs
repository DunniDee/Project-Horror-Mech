using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BlastDoor : MonoBehaviour
{
    [SerializeField] Transform LeftDoor;
    [SerializeField] Transform RightDoor;
    [SerializeField] float DoorSpeed;
    [SerializeField] AudioSource AS;
    [SerializeField] 
    


    public bool IsOpening;

    float DoorLerp = 0;
    // Update is called once per frame
    void Update()
    {
        if (DoorLerp == 1 || DoorLerp == 0 )
        {
            AS.volume = Mathf.Lerp(AS.volume,0,Time.deltaTime);
        }
        else
        {
            AS.volume = Mathf.Lerp(AS.volume,1,Time.deltaTime);
        }

        if (IsOpening)
        {
            DoorLerp += Time.deltaTime * DoorSpeed;

            DoorLerp = Mathf.Clamp01(DoorLerp);

            LeftDoor.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(-15,0,0),DoorLerp);
            RightDoor.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(15,0,0),DoorLerp);
        }
        else
        {
            DoorLerp -= Time.deltaTime * DoorSpeed;

            DoorLerp = Mathf.Clamp01(DoorLerp);

            LeftDoor.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(-15,0,0),DoorLerp);
            RightDoor.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(15,0,0),DoorLerp);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.name == "Mech_Agent")
        {
            IsOpening = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        Debug.Log(other.transform.name);
        if (other.transform.name == "Mech_Agent")
        {
            IsOpening = false;
        }        
    }
}
