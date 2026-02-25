using UnityEngine;

public class PickableItem : MonoBehaviour, IInteractable
{
    private Rigidbody rb;
    private Collider col;
    private bool isHeld = false;
    private Transform handPosition;
    private InteractionSystem interactionSystem;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    public void Interact(Transform handPosition, InteractionSystem interactionSystem)
    {
        this.handPosition = handPosition;
        this.interactionSystem = interactionSystem;
        isHeld = true;

        col.enabled = false;
        rb.isKinematic = true;
        interactionSystem.SetHeldItem(gameObject);
    }

    public void Drop()
    {
        handPosition = null;
        isHeld = false;

        col.enabled = true;
        rb.isKinematic = false;
    }

    void FixedUpdate()
    {
        if (isHeld && handPosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, handPosition.position, Time.fixedDeltaTime * 15f);
            transform.rotation = Quaternion.Lerp(transform.rotation, handPosition.rotation, Time.fixedDeltaTime * 15f);
        }
    }
}