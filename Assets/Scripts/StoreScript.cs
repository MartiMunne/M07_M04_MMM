using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreScript : MonoBehaviour
{
    public ItemScriptableObject Item1, Item2;
    public GameObject objectItem1, objectItem2;
    public TextMeshProUGUI textItem1, textItem2;
    public Button Buy1, Buy2;
    private int _coins;
    private void Update() 
    {
        _coins = GameManager.gameManager.Coins;
    }
    void Enable()
    {
        CheckIfCanBuy(Item1, textItem1, Buy1);
        CheckIfCanBuy(Item2, textItem2, Buy2);
    }

    public void BuyItem1()
    {
        if(_coins >= 5)
        {
            Destroy(objectItem1);
            GameManager.gameManager.CoinCollected(-Item1.price);
        }
        CheckIfCanBuy(Item1, textItem1, Buy1);
    }

    public void BuyItem2()
    {
        if(_coins >= 10)
        {
            Destroy(objectItem2);
            GameManager.gameManager.CoinCollected(-Item2.price);
        }
        CheckIfCanBuy(Item2, textItem2, Buy2);
    }


    private void CheckIfCanBuy(ItemScriptableObject item, TextMeshProUGUI insuCoins, Button buyButton)
    {
        if(_coins >= item.price)
        {
           insuCoins.text = "SOLD OUT";
           insuCoins.color = Color.yellow;
           buyButton.interactable = false; 
        }
        else if(_coins <= item.price)
        {
            insuCoins.text = "Insuficient coins: " + item.price + "COINS";
            insuCoins.color = Color.red;
        }
    }
}
