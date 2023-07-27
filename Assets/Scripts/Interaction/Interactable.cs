using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public ItemData itemdata;

    public void BaseInteract()
    {
        Interact();
    }

    public virtual void Interact() { }
}
