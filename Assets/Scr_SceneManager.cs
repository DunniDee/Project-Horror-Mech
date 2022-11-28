using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_SceneManager : MonoBehaviour
{

    public static Scr_SceneManager Instance = null;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }


    public void LoadScene(string _Scene)
    {
        Debug.Log("Loading Scene : " + _Scene);
        SceneManager.LoadScene(_Scene);
    }
}
