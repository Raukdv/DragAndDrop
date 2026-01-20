using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, 
    IPointerDownHandler, 
    IBeginDragHandler, 
    IDragHandler, 
    IEndDragHandler
{
    // Reference to the Canvas component
    [SerializeField] private Canvas canvas;
    // Reference to the RectTransform component
    private RectTransform rectTransform;
    // Reference to the CanvasGroup component (optional, for controlling interactivity)
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        //Assign the canvas component
        canvas = GetComponentInParent<Canvas>();
        //Assign the RectTransform component
        rectTransform = GetComponent<RectTransform>();
        //Assign the CanvasGroup component
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}
