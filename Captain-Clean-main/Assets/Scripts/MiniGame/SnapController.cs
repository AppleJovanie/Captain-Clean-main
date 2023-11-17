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
    public GameObject youLosePanel;

    private bool shampooMatched = false;
    private bool soapMatched = false;
    private bool soapMatchedAthleteFoot = false;
    private bool soapMatchedImpetigo = false;
    private bool toothbrushMatched = false;
    private bool allCorrectlyPlaced = false;

    private int counter;
    private string lastMovedTag;

    private bool isLocked = false;

    void Start()
    {
        foreach (Draggable draggable in draggableObjects)
        {
            draggable.dragEnded = OnDragEnded;     
        }
    }


    private void OnDragEnded(Draggable draggable)
    {
        Debug.Log(counter);
       
        float closestDistance = snapRange;
        Transform closestSnapPoint = null;
          bool incorrectPlacement = false;

        if (counter < 0) {
            counter = 0;
        }

        foreach (Transform snapPoint in snapPoints) 
        {
           
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (currentDistance <= closestDistance)
            {

                counter++;
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;

            Collider2D collider = draggable.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            if (draggable.CompareTag("Shampoo") && closestSnapPoint.CompareTag("HeadLice"))
            {
                    shampooMatched = true;
                
              

            }
            else if (draggable.CompareTag("Soap") && closestSnapPoint.CompareTag("AthleteFoot"))
            {
                
                    soapMatchedAthleteFoot = true;
               
            }
            else if (draggable.CompareTag("Soap1") && closestSnapPoint.CompareTag("Impetigo"))
            {
              
                    soapMatchedImpetigo = true;
               
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
        else
        {
            // If any object is incorrectly placed, set the flag to true
            incorrectPlacement = true;
        }

        // Check if all items are incorrectly placed
        if (counter == 5)
        {
            if (shampooMatched && soapMatched && toothbrushMatched && soapMatchedAthleteFoot && soapMatchedImpetigo)
            {
                allCorrectlyPlaced = true;
                youWonPanel.SetActive(true);
             
            }
            else
            {
                youLosePanel.SetActive(true);
            }

        }
        if (isLocked)
        {
            
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(12);
    }
    public void Menu()
        {
            SceneManager.LoadScene(13);
        }
    }
