using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //Keep track if st is build on that node 
    //Highlight node
    //Check if node is presed

    public Color hoverColor;

    private Color defaultColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        Debug.Log("Enter ");
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
        Debug.Log("exit ");
    }

}
