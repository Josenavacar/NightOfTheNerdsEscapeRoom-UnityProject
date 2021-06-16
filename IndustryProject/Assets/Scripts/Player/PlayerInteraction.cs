using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] private Transform rayShootPoint;
    [SerializeField] private Camera cam;

    [SerializeField] private float rangeOfInteraction;

    [SerializeField] private PlayerAnimationsCallManager animator;

    private GameObject selectedItem = null;
    private PhotonView PV;

    public GameObject signalArea;

    private void Start()
    {
        PV = GetComponentInParent<PhotonView>();      
    }

    private void Update()
    {
        if (PV.IsMine)
        {
            if (InputReader.instance.Interact)
            {
                ShootRay();
            }
        }
    }

    private void FixedUpdate()
    {
        if (PV.IsMine)
        {
            HighLight();
        }
    }

    private void ShootRay()
    {
        //Shoot ray to see if we can interact
        Ray ray = cam.ScreenPointToRay(InputReader.instance.MousePos);
        Ray ray1 = new Ray(rayShootPoint.position, Vector3.forward);

        RaycastHit hit;

        animator.SetInteractionTrigger();

        if (Physics.Raycast(ray, out hit, rangeOfInteraction))
        {
            CheckForInteractable(hit);
        }
    }

    private void HighLight()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(InputReader.instance.MousePos);
        Ray ray1 = new Ray(rayShootPoint.position, Vector3.forward);

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Selectable")
        {
            selectedItem = hit.collider.gameObject;

            SetOutlineWidth(selectedItem, 10f);
        }
        else
        {
            if (selectedItem != null)
            {
                SetOutlineWidth(selectedItem, 0f);
            }
        }
    }

    private void SetOutlineWidth(GameObject selectedItem, float width)
    {
        Outline outline = selectedItem.GetComponent<Outline>();

        if (outline != null)
        {
            outline.OutlineWidth = width;
        }
    }

    private void CheckForInteractable(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Selectable"))
        {
            Interactable interactableHit = hit.transform.GetComponent<Interactable>();

            if(hit.transform.gameObject.name == "Signal Booster") {
                GameObject childObject = Instantiate(signalArea);
                childObject.transform.SetParent(transform, false);
            }

            if (interactableHit != null)
            {
                interactableHit.HandleAction(transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeOfInteraction / 2);
    }
}
