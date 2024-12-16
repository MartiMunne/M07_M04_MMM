using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour, ICollectables
{
    public int ID;
    public Sprite Sprite;

    public void Collect()
    {
        GameManager.gameManager.ItemCollected(Sprite, ID);
        Destroy(gameObject);
    }
}
