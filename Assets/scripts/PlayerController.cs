using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isRotating = false;
    bool canMove = true;
    [SerializeField] float torqueAmount = 1.5f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-12, 15, 0);
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondBoost();
        }
        
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRotating = true;
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isRotating = true;
            rb2d.AddTorque(-torqueAmount);
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            isRotating = false; // Stop rotating when the keys are released
        }
        if (!isRotating)
        {
            rb2d.angularVelocity = 0f;
        }
    }
    void RespondBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }
}
