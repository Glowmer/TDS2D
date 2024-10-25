using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Vector2 screenBoundery;
    [SerializeField] Camera cam;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashTime = 20f;
    public bool canDash = false;
    public bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }
    void OnMove(InputValue value)
    {
        if (canMove == true)
        {
            moveInput = value.Get<Vector2>();
        }
    }

    void OnDash(InputValue value)
    {

        if (canDash == true)
        {
            rb.AddForce(transform.up * dashSpeed);


        }
    }
    void Update()
    {

        if (moveInput != Vector2.zero)
        {
            rb.AddForce(transform.up * moveSpeed);
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveInput);
            Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            rb.MoveRotation(rotate);
        }
        else rb.angularVelocity = 0;

        screenBoundery = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log(screenBoundery);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundery.x, screenBoundery.x), Mathf.Clamp(transform.position.y, -screenBoundery.y, screenBoundery.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }


}
