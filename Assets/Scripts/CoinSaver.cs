using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinSaver : MonoBehaviour
{
    public int ID;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("Coin" + ID) && PlayerPrefs.GetInt("Coin" + ID) == 1)
        {
            LoadCoin();
            Debug.Log("Coin Eliminated");
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Coin" + ID, 1);
        Debug.Log("CoinSaved");
    }
    public void LoadCoin() 
    {
        GameManager.gameManager.CoinCollected(1);
        gameObject.SetActive(false);
    }
}
