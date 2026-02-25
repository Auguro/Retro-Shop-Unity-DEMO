using UnityEngine;
public interface IInteractable
{
    void Interact(Transform handPosition, InteractionSystem interactionSystem);
    void Drop();
}