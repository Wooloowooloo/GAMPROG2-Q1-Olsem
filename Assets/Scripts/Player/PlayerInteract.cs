using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    private PlayerUI playerUI;
    private InputManager inputManager;

    [SerializeField] private LayerMask mask;
    [SerializeField] private float rayMaxDistance = 1.5f;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpdatePopUpText(string.Empty);

        Ray ray = new(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * rayMaxDistance);

        if(Physics.Raycast(ray, out hitInfo, rayMaxDistance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                playerUI.UpdatePopUpText(interactable.itemdata.id + "\n[LMB]");

                if (inputManager.playerActions.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
