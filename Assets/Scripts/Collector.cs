using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Collector : MonoBehaviour
{
    private Animator _animator;
    private PlayerMover pm;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        pm = FindAnyObjectByType<PlayerMover>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ICollectables>(out ICollectables icoll))
        {
            icoll.Collect();
            if(icoll is OrbScript)
            {
                _animator.SetTrigger("OrbCollected");
                _animator.SetLayerWeight(1, 1);
                Camera.main.GetComponent<CinemachineBrain>().enabled = true;
                pm.canMove = false;
            }
        }
    }
}
