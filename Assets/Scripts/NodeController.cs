using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NodeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static NodeController instance;
    public List<GameObject> circles = new List<GameObject>();
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
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            foreach (GameObject circle in circles)
            {
                circle.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
