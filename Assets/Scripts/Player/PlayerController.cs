using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour, IKitchenElementParent

{
    public static PlayerController Instance { get; private set; }
    public event EventHandler<OnSelectedElementChangedEventArgs> OnSelectedElementChanged;
    public class OnSelectedElementChangedEventArgs : EventArgs
    {
        public InteractableObject selectedInteractableObject;

        public OnSelectedElementChangedEventArgs(InteractableObject selectedObject)
        {
            selectedInteractableObject = selectedObject;
        }    }

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private LayerMask interactablesLayerMask;
    [SerializeField] GameInput gameInput;
    [SerializeField] public Transform pickPoint;

    public Transform PickPoint
    {
        get => pickPoint;
    }

    [SerializeField] private KitchenObject kitchenObject;

    private float playerRadius;
    private float playerHeight;

    //private Vector3 lastInteractableDirection;

    public InteractableObject selectedInteractableObject;

    private Animator _animator;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Player instance");
        }
        Instance = this;
        playerRadius = GetComponent<CapsuleCollider>().radius;
        playerHeight = GetComponent<CapsuleCollider>().height;
    }

    private void Start()
    {
        // assign the interaction event
        _animator = gameObject.GetComponent<Animator>();
        gameInput.OnInteractAction += GameInput_OnInteractAction;
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

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(0, playerHeight / 2, 0),playerRadius);
    }
    */

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        //Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y).normalized;

        /*
        if (inputVector != Vector2.zero)
        {
            lastInteractableDirection = moveDirection;
        }
        */

        if (Physics.SphereCast(transform.position + new Vector3(0, playerHeight / 2, 0), 0, transform.forward, out RaycastHit hitInfo, playerRadius, interactablesLayerMask))
        {
            if (hitInfo.transform.TryGetComponent(out InteractableObject interactableObject))
            {
                if (interactableObject != selectedInteractableObject)
                {
                    SetSelectedElement(interactableObject);
                }
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

        if (inputVector != Vector2.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
            _animator.SetBool("walk", true);
        }
        else
        {
            _animator.SetBool("walk", false);
        }

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }
    }

    private bool CollisionDetection(Vector3 moveDirection, float moveDistance)
    {
        // checks if the object is colliding, if false is not colliding so we get the opposite
        bool canMove = !Physics.CapsuleCast(
            transform.position,
            transform.position + Vector3.up * playerHeight,
            playerRadius / 2,
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
            OnSelectedElementChanged?.Invoke(this, new OnSelectedElementChangedEventArgs(selectedInteractableObject));
        }
    }

    public Transform GetKitchenElementNewTransform()
    {
        return pickPoint;
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