﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject player1UnitA;
    public GameObject player1UnitB;
    public GameObject player1UnitC;
    public GameObject player2UnitA;
    public GameObject player2UnitB;
    public GameObject player2UnitC;
    public GameObject[] player1;
    public GameObject[] player2;
    public GameObject selectedObject;
    public int mouseScrollValue;

    public int totalUnits;
    public int player1Units;
    public int player2Units;
    public int player1SpawnedUnits;
    public int player2SpawnedUnits;
    public int debugUnitCount;
    public Vector3 mousePos;

    public Vector3 worldPos;
    public Ray ray;
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        player1Units = (totalUnits / 2);
        player2Units = (totalUnits / 2);
        player1 = new GameObject[player1Units];
        player2 = new GameObject[player2Units];
        mouseScrollValue = 0;
        selectedObject = player1UnitA;
        

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        ray = Camera.main.ScreenPointToRay(mousePos);
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            mouseScrollValue++;
            if (mouseScrollValue > 2)
            {
                mouseScrollValue = 0;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            mouseScrollValue--;
            if (mouseScrollValue < 0)
            {
                mouseScrollValue = 2;
            }
        }

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            worldPos = hit.point;
        }
        else
        {
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        }
        if (worldPos.x < 0)
        {
            if (mouseScrollValue == 0)
            {
                selectedObject = player1UnitA;
            }
            else if (mouseScrollValue == 1)
            {
                selectedObject = player1UnitB;
            }
            else if (mouseScrollValue == 2)
            {
                selectedObject = player1UnitC;
            }
        }
        else if (worldPos.x > 0)
        {
            if (mouseScrollValue == 0)
            {
                selectedObject = player2UnitA;
            }
            else if (mouseScrollValue == 1)
            {
                selectedObject = player2UnitB;
            }
            else if (mouseScrollValue == 2)
            {
                selectedObject = player2UnitC;
            }
        }
        
        selectedObject.SetActive(true);
        selectedObject.transform.position = mousePos;


        if (Input.GetMouseButton(0))
        {
            if (player1SpawnedUnits < player1Units || player2SpawnedUnits < player2Units)
            {
                if (hit.collider.tag == "Ground")
                {


                    if (worldPos.x < 0)
                    {
                        player1[player1SpawnedUnits] = selectedObject;
                        Instantiate(player1[player1SpawnedUnits], worldPos, Quaternion.identity);
                        player1[player1SpawnedUnits].SetActive(true);
                        player1SpawnedUnits++;
                    }
                    if (worldPos.x > 0)
                    {
                        player2[player2SpawnedUnits] = selectedObject;
                        Instantiate(player2[player2SpawnedUnits], worldPos, Quaternion.identity);
                        player2[player2SpawnedUnits].SetActive(true);
                        player2SpawnedUnits++;
                    }
                    //for (int i = 0; i < (totalUnits/2); i++)
                    //{
                    //    player1[i] = player1Model;
                    //    player2[i] = player2Model;
                    //    Instantiate(player1[i], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
                    //    player1[i].SetActive(true);
                    //    player1SpawnedUnits++;
                    //    debugUnitCount++;
                    //    Instantiate(player2[i], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
                    //    player2[i].SetActive(true);
                    //    debugUnitCount++;
                    //    player2SpawnedUnits++;
                    //}
                }

            }
        }

    }
}