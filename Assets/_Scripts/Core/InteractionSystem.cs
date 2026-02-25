using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private Transform handPosition;
    [SerializeField] private LayerMask ignoreLayers;

    private PlayerInputActions inputActions;
    private GameObject heldItem;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
    }

    void Update()
    {
        if (!inputActions.Player.Interact.WasPressedThisFrame()) return;

        if (heldItem != null)
        {
            DropItem();
            return;
        }

        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxDistance, Color.red);
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out RaycastHit hit, maxDistance, ~ignoreLayers))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact(handPosition, this);
            }
        }
    }

    public void SetHeldItem(GameObject item)
    {
        heldItem = item;
    }

    private void DropItem()
    {
        if (heldItem.TryGetComponent<IInteractable>(out IInteractable interactable))
            interactable.Drop();

        heldItem = null;
    }
}