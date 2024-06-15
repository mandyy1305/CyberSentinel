using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject correspondingGamobject;

    public GameObject defensePanel;
    public GameObject attackPanel;

    private bool isClicked = false;
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    public LayerMask draggableLayer;
    public LayerMask gridLayer;
    public float snapThreshold = 0.5f; // Adjust as needed for the snapping distance

    [TextArea(3,5)]
    public string description;
    //public static event Action OnDefenseDeployed;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(GetMouseWorldPosition(), Vector2.zero, 0f, draggableLayer);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                offset = transform.position - GetMouseWorldPosition();
                isDragging = true;
                isClicked = true;
                Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            //Start the shooting or whatever mechanism

            if(isClicked) {
                Instantiate(correspondingGamobject, transform.position, Quaternion.Euler(0f, 180f, 0f));
                Destroy(gameObject);
            }

        }

        if (isDragging)
        {
            Vector3 targetPosition = GetMouseWorldPosition() + offset;
            transform.position = SnapToGrid(targetPosition);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f; // Distance from the camera to the object
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private Vector3 SnapToGrid(Vector3 currentPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, Vector2.zero, Mathf.Infinity, gridLayer);

        if (hit.collider != null)
        {
            float distance = Vector3.Distance(currentPosition, hit.collider.transform.position);
            if (distance <= snapThreshold)
            {
                return hit.collider.transform.position;
            }
        }
        return currentPosition;
    }

    private void OnMouseEnter()
    {
        defensePanel.SetActive(true);
        attackPanel.SetActive(false);

        defensePanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = description;
    }

    private void OnMouseExit()
    {
        defensePanel.SetActive(false);
    }

}
