using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField] private GameObject door;
    private bool isOpened;

    public void OpenDoor()
    {
        isOpened = !isOpened;
        door.GetComponent<Animator>().SetBool("isOpen", isOpened);
    }
}
