using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Variables

    private Animator playerAnim;
    private int holdLayerIndex;

    private  PlayerMove player;
    private PlayerPickup playerPickup;
    private PlayerDrop playerDrop;
    private PlayerStack playerStack;

    float targetLayerValue = 1;
    #endregion

    #region Private Methods

    
    void Awake()
    {
        player = GetComponentInParent<PlayerMove>();
        playerPickup = GetComponentInParent<PlayerPickup>();
        playerStack = GetComponentInParent<PlayerStack>();
        playerDrop = FindObjectOfType<PlayerDrop>();
        playerAnim = GetComponent<Animator>();
        holdLayerIndex = playerAnim.GetLayerIndex("UpperBody");
    }

    private void Update()
    {
        playerAnim.SetBool("isRunning", player.isRunning);

        playerAnim.SetBool("onBoat", playerDrop.onBoat);

        //holding
        if (playerStack.isStack )
        {
            playerAnim.SetLayerWeight(holdLayerIndex, targetLayerValue);
        }
        else
        {
            playerAnim.SetLayerWeight(holdLayerIndex, 0);
        }
        
       

    }

    #endregion
}
