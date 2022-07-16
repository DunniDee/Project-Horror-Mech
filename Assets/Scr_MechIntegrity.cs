using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MechIntegrity : MonoBehaviour
{
    [SerializeField] AudioSource AboveSound;
    [SerializeField] AudioSource BelowSound;
    [SerializeField] AudioSource BehindSound;
    [SerializeField] AudioClip AboveClip;
    [SerializeField] AudioClip BelowClip;
    [SerializeField] AudioClip BehindClip;

    [SerializeField] Animator Anim;
    // Update is called once per frame

    private void Start() 
    {
        GetShrilled();
    }

    void AttackAbove()
    {
        Anim.SetTrigger("Above");
        Invoke("PlayUp", 0.025f);
    }

    void AttackBelow()
    {
        Anim.SetTrigger("Below");
        Invoke("PlayDown", 0.25f);
    }

    void AttackBehind()
    {
        Anim.SetTrigger("Behind");
        Invoke("PlayBack", 0.2f);
    }

    void PlayUp()
    {
        AboveSound.PlayOneShot(AboveClip);
    }
    void PlayDown()
    {
        BelowSound.PlayOneShot(BelowClip);
    }
    void PlayBack()
    {
        BehindSound.PlayOneShot(BehindClip);
    }

    void GetShrilled()
    {
       switch (Mathf.RoundToInt(Random.Range(1,4.45f)))
       {
        case 1 :
            AttackAbove();
        break;

        case 2 :
            AttackBelow();
        break;

        case 3 :
            AttackBehind();
        break;
           
        default:
        break;
       }
    }
}
