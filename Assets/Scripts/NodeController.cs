using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class NodeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static NodeController instance;
    public List<GameObject> circles = new List<GameObject>();
    private GameObject lastHovered;
    private Color originalColor;


    void Start()
    {
        GameObject[] foundCircles = GameObject.FindGameObjectsWithTag("Node");
        circles.AddRange(foundCircles);

        foreach (GameObject circle in circles)
        {
            circle.GetComponent<SpriteRenderer>().color = Color.red;
        }
    
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

        if (hit != null && hit.CompareTag("Node"))
        {
            GameObject current = hit.gameObject;

            if (current != lastHovered)
            {
                // Reset color of previous hovered object
                ResetLastHovered();

                // Highlight new one
                SpriteRenderer sr = current.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    originalColor = sr.color;
                    sr.color = Color.yellow;
                    lastHovered = current;
                }
            }


        }
    }
        void ResetLastHovered()
        {
            if (lastHovered != null)
            {
                SpriteRenderer sr = lastHovered.GetComponent<SpriteRenderer>();
                if (sr != null)
                    sr.color = Color.red;

                lastHovered = null;
            }
        }
    }


