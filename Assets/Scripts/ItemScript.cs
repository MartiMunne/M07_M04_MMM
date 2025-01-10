using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class ItemScript : MonoBehaviour, ICollectables
{
    public int ID;
    public Sprite Sprite;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Item" + ID) && PlayerPrefs.GetInt("Item" + ID) == 1)
        {
            LoadItem();
            Debug.Log("Item Eliminated");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Item" + ID, 1);
        Debug.Log("Item Saved");
    }
    public void Collect()
    {
        GameManager.gameManager.ItemCollected(Sprite, ID);
        Destroy(gameObject);
    }
    public void LoadItem()
    {
        GameManager.gameManager.ItemCollected(Sprite, ID);
        gameObject.SetActive(false);
    }
}
