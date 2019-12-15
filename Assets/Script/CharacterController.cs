using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Camera cam;
    Rigidbody rb;

    bool isGrounded = false;
    bool jump = false;

    [SerializeField] float distance;
    [SerializeField] LayerMask layers;

    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>(); //Récupère la camera
        rb = GetComponent<Rigidbody>(); //Récupère le Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        if (xMovement != 0 || yMovement != 0) //Si le joueur doit bouger
        {

        }

        if (Input.GetButton("Jump")&&isGrounded)
        {
            jump = true; //Dit que le joueur doit sauter
        }
    }

    void FixedUpdate() //Actualisation du modèle physique
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up,distance,layers);

        if (jump && isGrounded) //Si le joueur doit sauter, il saute
        {
            jump = false;
            rb.AddForce(transform.up * jumpForce); //Donne une impulsion vers le haut au joueur
        }
    }
}
