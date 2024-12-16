using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour, ICollectables
{
    public void Collect()
    {
        GameManager.gameManager.OrbCollected();
        Destroy(gameObject);
    }
}
