using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootLogic : MonoBehaviour
{
    public PlayerMovement playerMovement;
    void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        playerMovement.canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerMovement.canJump = false;

    }
}
