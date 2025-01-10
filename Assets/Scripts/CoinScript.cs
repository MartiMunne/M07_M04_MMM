using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour, ICollectables
{
    public void Collect()
    {
        GameManager.gameManager.CoinCollected(1);
        Destroy(gameObject);
    }
}
