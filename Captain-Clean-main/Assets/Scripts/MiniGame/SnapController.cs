using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    public GameObject youWonPanel;
    //public GameObject youLosePanel;

    private bool shampooMatched = false;
    private bool soapMatched = false;
    private bool toothbrushMatched = false;
    private bool allCorrectlyPlaced = false;


    void Start()
    {
        foreach (Draggable draggable in draggableObjects)
        {
            draggable.dragEnded = OnDragEnded;
        }
    }

    private void OnDragEnded(Draggable draggable)
    {

        float closestDistance = snapRange;
        Transform closestSnapPoint = null;
        //bool incorrectPlacement = false;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (currentDistance <= closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;

            if (draggable.CompareTag("Shampoo") && closestSnapPoint.CompareTag("HeadLice"))
            {
                shampooMatched = true;
            }
            else if (draggable.CompareTag("Soap") && closestSnapPoint.CompareTag("AthleteFoot"))
            {
                soapMatched = true;
            }
            else if (draggable.CompareTag("Soap1") && closestSnapPoint.CompareTag("Impetigo"))
            {
                soapMatched = true;
            }
            else if (draggable.CompareTag("Soap2") && closestSnapPoint.CompareTag("Scabies"))
            {
                soapMatched = true;
            }
            else if (draggable.CompareTag("ToothBrush") && closestSnapPoint.CompareTag("Cavity"))
            {
                toothbrushMatched = true;
            }
        }
        //else
        //{
        //    // If any object is incorrectly placed, set the flag to true
        //    incorrectPlacement = true;
        //}

        //// Check if all items are incorrectly placed
        //if (!shampooMatched && !soapMatched && !toothbrushMatched && incorrectPlacement)
        //{
        //    allCorrectlyPlaced = false;
        //    youLosePanel.SetActive(true);
        //}
        else if (shampooMatched && soapMatched && toothbrushMatched)
        {
            allCorrectlyPlaced = true;
            youWonPanel.SetActive(true);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
