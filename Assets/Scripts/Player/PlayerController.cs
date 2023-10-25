using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IKitchenElementParent

{
    public static PlayerController Instance { get; private set; }
    public event EventHandler<OnSelectedElementChangedEventArgs> OnSelectedElementChanged;
    public class OnSelectedElementChangedEventArgs : EventArgs {
        public InteractableObject selectedInteractableObject;
    }
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private LayerMask interactablesLayerMask;
    [SerializeField] GameInput gameInput;
    [SerializeField] public Transform playerPickPoint;
    private KitchenObject kitchenObject;
    
    private float playerRadius;
    private float playerHeight;

    private Vector3 lastInteractableDirection;
    
    public InteractableObject selectedInteractableObject;


    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("There is more than one Player instance");
        }
        Instance = this;
        playerRadius = GetComponent<CapsuleCollider>().radius;
        playerHeight = GetComponent<CapsuleCollider>().height;
    }
    
    private void Start()
    {
        // assign the interaction event
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnMixAction += GameInput_OnMixAction;
    }
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }
    
    
    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (selectedInteractableObject != null)
        {
            selectedInteractableObject.Interact(this);
        }

    }
    private void GameInput_OnMixAction(object sender, EventArgs e)
    {
        if (selectedInteractableObject != null)
        {
            selectedInteractableObject.MixIngredients(this);
        }

    }
    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 moveDirection = new(inputVector.x, 0.0f, inputVector.y);
        float interactDistance = 2f;

        if (moveDirection != Vector3.zero)
        {
            lastInteractableDirection = moveDirection;
        }
        if (Physics.Raycast(transform.position, lastInteractableDirection, out RaycastHit raycastHit, interactDistance, interactablesLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out InteractableObject interactableObject))
            {
                if (interactableObject != selectedInteractableObject)
                {
                    SetSelectedElement(interactableObject);
                }
            }
            else
            {
                SetSelectedElement(null);
            }
        }
        else
        {
            SetSelectedElement(null);

        }

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

    public void SetSelectedElement(InteractableObject newSelectedInteractableObject)
    {
        if (selectedInteractableObject != newSelectedInteractableObject)
        {
            selectedInteractableObject = newSelectedInteractableObject;
            OnSelectedElementChanged?.Invoke(this, new OnSelectedElementChangedEventArgs());
        }
    }
    public Transform GetKitchenElementNewTransform()
    {
        return playerPickPoint;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void SetKitchenObject(KitchenObject kitchenElement)
    {
        this.kitchenObject = kitchenElement;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}