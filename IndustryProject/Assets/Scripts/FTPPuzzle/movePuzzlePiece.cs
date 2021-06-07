using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movePuzzlePiece : MonoBehaviour, IDragHandler, IPointerDownHandler, IDropHandler
{

    //private float startingPosX;
    //private float startingPosY;
    ////public Camera puzzle;
    ///
    public bool isBeingHeld = false;
    public bool isNearAnchor = false;
    public RectTransform anchor;

    private RectTransform thisTransform;
    [SerializeField] Canvas parentCanvas;
    void Start()
    {
        thisTransform = GetComponent<RectTransform>();
        parentCanvas = GetComponentInParent<Canvas>();
    }
    void Update()
    {
        #region old code
        //if (isBeingHeld)
        //{
        //    Vector3 mousePos;
        //    mousePos = Input.mousePosition;
        //    mousePos = puzzle.ScreenToWorldPoint(mousePos);
        //    this.gameObject.transform.localPosition = new Vector3(mousePos.x-startingPosX, mousePos.y-startingPosY, -70);
        //}

        
        #endregion
    }
    #region old code that i don't want to delete for sentimental reasons lolxdsike
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 mousePos;
            //mousePos = Input.mousePosition;
            //mousePos = puzzle.ScreenToWorldPoint(mousePos);

            //startingPosX = mousePos.x - this.transform.position.x;
            //startingPosY = mousePos.y - this.transform.position.y;
            //isBeingHeld = true;
        }
    }
    private void OnMouseUp()
    {
        //isBeingHeld = false;
    }
    #endregion
    public void AnchorPiece(RectTransform anchor)
    {
        isNearAnchor = true;
        this.anchor = anchor;
    }
    public void unAnchor()
    {
        isNearAnchor = false;
        this.anchor = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        thisTransform.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
        unAnchor();
        isBeingHeld = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        thisTransform.SetAsLastSibling();
    }

    public void OnDrop(PointerEventData eventData)
    {
        isBeingHeld = false;
        if (isNearAnchor)
        {
            thisTransform.position = anchor.position;
        }
    }
}
