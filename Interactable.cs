//Written by Isaac Carter
//11/3/21
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
    public abstract void Interact();
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
            collison.GetComponent<PlayerController>().OpenInteractableIcon();

    }
    private void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
            collison.GetComponent<PlayerController>().CloseInteractableIcon(); 
    }
}
