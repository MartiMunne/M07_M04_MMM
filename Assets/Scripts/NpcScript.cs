using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NpcScript : MonoBehaviour
{
   public CinemachineVirtualCamera VCamDisable;
   public CinemachineVirtualCamera VCamEnable;
   public GameObject UI;
   public GameObject HUD;
   private PlayerMover _playerMover;
   [SerializeField] Animator _animatorSpeaker;
   private bool _canSpeak = true;
   private float time = 1f;

   private  void OnTriggerEnter(Collider other)
   {
        _animatorSpeaker.SetBool("isSpeaking", true);
        VCamDisable.gameObject.SetActive(false);
        VCamEnable.gameObject.SetActive(true);
        Camera.main.GetComponent<CinemachineBrain>().enabled = true;
        Camera.main.cullingMask &= ~(1 << 8);
        _playerMover = other.GetComponent<PlayerMover>();
        _playerMover.canMove = false;
        UI.SetActive(true);
        HUD.SetActive(false);
        _canSpeak = false;
   }
   private void OnTriggerExit(Collider other) 
   {
        StartCoroutine(WaitForABit());
   }
    public void ExitDialog()
    {
        _animatorSpeaker.SetBool("isSpeaking", false);
        _playerMover.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= (1 << 8);
        UI.SetActive(false);
        HUD.SetActive(true);
    }
    private IEnumerator WaitForABit()
    {
        yield return new WaitForSeconds(time);
        _canSpeak = true;
    }
}
