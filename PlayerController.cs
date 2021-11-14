//Written By IsaacCarter
//11/1/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour

{
    //Variables used by the Script
    public Transform playerTransform;
    public GameObject interactIcon;
    

    private Animator anim;
    private Vector2 boxSize = new Vector2(0.1f, 0.1f);

    private bool movingUp;
    private bool movingDown;
    private bool movingRight;
    private bool movingLeft;

    private int movespeed = 1;

    public void OpenInteractableIcon()
    {
        interactIcon.SetActive(true);
    }
    public void CloseInteractableIcon()
    {
        interactIcon.SetActive(false);
    }
    private void CheckInteractable()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(playerTransform.position, boxSize, 0, Vector3.zero);
        if (hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }

   
    void Start()
    {
        interactIcon.SetActive(false);
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Variables To Store Movement
        movingUp = Input.GetKey(KeyCode.W);
        movingDown = Input.GetKey(KeyCode.S);
        movingLeft = Input.GetKey(KeyCode.A);
        movingRight = Input.GetKey(KeyCode.D);

        //Run Any Object Interactions when e is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteractable();
        }
        
    }
    void FixedUpdate()
    {
        //Causes Movement
        if (movingUp)
        {
            playerTransform.Translate(Vector3.up * Time.deltaTime * movespeed);
        }
        if (movingDown)
        {
            playerTransform.Translate(Vector3.down * Time.deltaTime * movespeed);
        }       
        if (movingLeft)
        {
            playerTransform.Translate(Vector3.left * Time.deltaTime * movespeed);
        }
        if (movingRight)
        {
            playerTransform.Translate(Vector3.right * Time.deltaTime * movespeed);
        }
    }
}
