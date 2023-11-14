using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject); 
    public DragEndedDelegate dragEnded;
    public bool isDrag = false;
    private Vector3 mouseDragPosition;
    private Vector3 spriteDragPosition;  
    private void OnMouseDown()
    {
        isDrag = true;
        mouseDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragPosition = transform.localPosition;
    }
    private void OnMouseUp() 
    {
        isDrag = false;
        dragEnded(this);
    }
    private void OnMouseDrag()
    {
        if (isDrag)
        {
            transform.localPosition = spriteDragPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragPosition);
        }
    }
}
