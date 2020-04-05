using Assets.Scripts;
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
    public Vector3 positionffset;
    private GameObject turret;
    private GameObject parent;
    
    bool mouseDown = false;
    Vector3 mousePosition;

    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
        parent = GameObject.FindGameObjectWithTag("TerrainGroup");
    }

    private void OnMouseDown()
    {
        if(turret != null )
        {
            Debug.Log("Can't build turret");
            return;
        }

        //GUI.Box(new Rect(transform.position.x, transform.position.y, 200f, 100f), "this is a test");
        mouseDown = true;
        mousePosition = Input.mousePosition;

        var turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionffset, turretToBuild.transform.rotation);

        if(parent != null)
        {
            turret.transform.parent = parent.transform;
        }
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

    private void OnGUI()
    {
        Debug.Log("UIIIIIIIII");
    }

}
