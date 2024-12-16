using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour, ICollectables
{
    public void Collect()
    {
        GameManager.gameManager.CoinCollected(10);
        Destroy(gameObject);
    }
}
