using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OrbSaver : MonoBehaviour
{
    public int ID_Orb;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("Orb" + ID_Orb) && PlayerPrefs.GetInt("Orb" + ID_Orb) == 1)
        {
            LoadOrb();
            Debug.Log("Orb Eliminated");
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Orb" + ID_Orb, 1);
        Debug.Log("Orb Saved");
    }
    public void LoadOrb() 
    {
        GameManager.gameManager.OrbCollected();
        gameObject.SetActive(false);
    }
}
