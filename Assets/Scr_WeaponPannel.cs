using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_WeaponPannel : MonoBehaviour
{
    [SerializeField] GameObject AmmoPrefab;
    [SerializeField] Transform AmmoSpawnPos;
    [SerializeField] Transform AmmoLoadPos;
    [SerializeField] Scr_MouseLook Look;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip LoadSound;
    [SerializeField] Scr_MechWeapons Weapons;

    [SerializeField] Scr_HudLight ReloadLight;
    [SerializeField] Scr_HudLight AmmoLight;

    [SerializeField] float FlapTime;
    [SerializeField] Transform FlapTransform;
    float FlapTimer;

    private void Update() 
    {
        if (Weapons.AmmoCount < Weapons.MaxAmmo)
        {
            ReloadLight.IsOn = true;
            AmmoLight.IsOn = true;
        }
        else
        {
            ReloadLight.IsOn = false;
            AmmoLight.IsOn = false;
        }

        if (FlapTimer > 0)
        {
            FlapTimer-= Time.deltaTime;
            FlapTransform.rotation  = Quaternion.Lerp(FlapTransform.rotation, Quaternion.Euler(0,-9.72f, 90), Time.deltaTime * 4);
        }
        else
        {
            FlapTransform.rotation  = Quaternion.Lerp(FlapTransform.rotation, Quaternion.Euler(0,-9.72f, 0), Time.deltaTime * 4);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Shell"))
        {
            if (!other.GetComponent<Scr_AmmoShell>().ToDestroy)
            {
                FlapTimer = FlapTime;
                Scr_AmmoShell temp = other.GetComponent<Scr_AmmoShell>();
                Debug.Log("LoadedShell");
                Look.Shell = null;
                temp.FollowPoint = AmmoLoadPos.position;
                Destroy(other, 4);
                temp.ToDestroy = false;
                AS.PlayOneShot(LoadSound);
                Weapons.AmmoCount++;
            }
        }
    }

    public void SpawnAmmo()
    {
        if (Weapons.AmmoCount < Weapons.MaxAmmo)
        {
            GameObject Shell = Instantiate(AmmoPrefab,AmmoSpawnPos.position,Quaternion.Euler(90,0,0));
            Look.Shell = Shell.GetComponent<Scr_AmmoShell>();   
        }
    }
}
