using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private LayerMask tablesLayerMask;
    [SerializeField] GameInput gameInput;
    [SerializeField] private Transform playerPickPoint;
   
    private float playerRadius;
    private float playerHeight;

    private Vector3 lastInteractableDirection;
    private void Awake()
    {
        playerRadius = GetComponent<CapsuleCollider>().radius;
        playerHeight = GetComponent<CapsuleCollider>().height;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }
    void FixedUpdate()
    {
        HandleMovement();
    }


    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        Debug.Log("Interacting");
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 moveDirection = new(inputVector.x, 0.0f, inputVector.y);
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = CollisionDetection(moveDirection, moveDistance);

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

    }

    private bool CollisionDetection(Vector3 moveDirection, float moveDistance)
    {
        // checks if the object is colliding, if false is not colliding so we get the opposite
        bool canMove = !Physics.CapsuleCast(
            transform.position,
            transform.position + Vector3.up * playerHeight,
            playerRadius,
            moveDirection,
            moveDistance
            );
        return canMove;
    }

}