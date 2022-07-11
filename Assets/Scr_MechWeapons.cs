using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechWeapons : MonoBehaviour
{
    [SerializeField] Animator Anim;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform ShootPos;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] Scr_CockpitTilter Tilt;
    [SerializeField] Animator ShakeAnim;
    [SerializeField] Transform CheckPos;
    
    [SerializeField] Transform GunTransform;
    [SerializeField] Scr_HudLightBlinker Blinker;
    [SerializeField] Scr_HudLight AmmoLight;
    [SerializeField] Scr_Power Power;

    public int MaxAmmo;
    public int AmmoCount;

    bool IsObtructed;

    [SerializeField] float FireRate;
    float ShotTimer = 0;


    void Update()
    {
        if (Physics.Raycast(CheckPos.position, CheckPos.forward, 5))
        {
            GunTransform.localRotation = Quaternion.Lerp(GunTransform.localRotation, Quaternion.Euler(45,0,0), Time.deltaTime * 2);
            GunTransform.localPosition = Vector3.Lerp(GunTransform.localPosition,new Vector3(0,-1,-5), Time.deltaTime * 2);
            Blinker.IsBlinking = true;
            IsObtructed = true;
        }
        else
        {
            GunTransform.localRotation = Quaternion.Lerp(GunTransform.localRotation, Quaternion.Euler(0,0,0), Time.deltaTime * 2);
            GunTransform.localPosition = Vector3.Lerp(GunTransform.localPosition,new Vector3(0,-1,0), Time.deltaTime * 2);
            Blinker.IsBlinking = false;
            IsObtructed = false;
        }

        if (ShotTimer > 0)
        {
            ShotTimer-=Time.deltaTime;
            AmmoLight.IsOn = false;
        }
        else
        {
           AmmoLight.IsOn = true; 
        }
    }

    public void Shoot()
    {
        if (!IsObtructed && ShotTimer <= 0 && AmmoCount > 0)
        {
            Anim.SetTrigger("Shoot");
            AS.PlayOneShot(ShootSound);
            Tilt.RotateTo += new Vector3(-2,10,0);
            ShakeAnim.SetTrigger("Shake");
            ShotTimer = FireRate;
            AmmoCount--;
            Instantiate(BulletPrefab,ShootPos.position,ShootPos.rotation);
            Power.Power -= 15;
        }
    }
}
