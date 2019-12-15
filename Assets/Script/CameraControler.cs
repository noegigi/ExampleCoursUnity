using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField] Vector2 mouseSpeed;
    [SerializeField] float limitAngle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Mouse X"); //Récupère le mouvement horizontal de la souris
        float vAxis = Input.GetAxis("Mouse Y"); //Récupère le mouvement vertical de la souris

        if (hAxis!=0||vAxis!=0) //Si le joueur a bougé la souris
        {
            transform.Rotate(-mouseSpeed.x * vAxis*Time.deltaTime, mouseSpeed.y*hAxis*Time.deltaTime,0);
        }
    }

    private void LateUpdate()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = 0;
        if(rotation.x > limitAngle)
        {
            if(rotation.x < 180)
            {
                rotation.x = limitAngle;
            }
            else if(rotation.x < 360 - limitAngle)
            {
                rotation.x = 360 - limitAngle;
            }
        }
        transform.eulerAngles = rotation;
    }
}
