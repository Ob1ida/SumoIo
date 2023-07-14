using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector2 move;
    public bool isMoving;
    public float RunSpeed = 10f;


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        movePlayer();
    }


    public void movePlayer()
    {

        speed = 5f;
        Vector3 movment = new Vector3(move.x, 0f, move.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movment), 0.15f);
        transform.Translate(movment * speed * Time.deltaTime, Space.World);
    }
}
