using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISeek_Spawn : MonoBehaviour
{
    public GameObject player1UnitA;
    public GameObject player1UnitB;
    public GameObject player1UnitC;
    public GameObject player2UnitA;
    public GameObject player2UnitB;
    public GameObject player2UnitC;

    public GameObject[] player1;
    public GameObject[] player2;
    public GameObject[] parentUnits;
    public GameObject selectedObject;

    public GameObject Team1;
    public GameObject Team2;

    public GameObject P1;
    public GameObject P2;

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

    public bool mainCamera;
    public bool player1Camera;
    public bool player2Camera;

    public Camera CameraMain;
    public Camera CameraPlayer1;
    public Camera CameraPlayer2;

    public int tempWorldX;
    public int tempWorldZ;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        player1Units = (totalUnits / 2);
        player2Units = (totalUnits / 2);
        player1 = new GameObject[player1Units];
        player2 = new GameObject[player2Units];
        mouseScrollValue = 0;
        selectedObject = player1UnitA;

        parentUnits = new GameObject[6];
        parentUnits[0] = player1UnitA;
        parentUnits[1] = player1UnitB;
        parentUnits[2] = player1UnitC;
        parentUnits[3] = player2UnitA;
        parentUnits[4] = player2UnitB;
        parentUnits[5] = player2UnitC;
        mainCamera = true;
        player1Camera = false;
        player2Camera = false;

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        if (CameraMain)
        {
            //ray = new Ray(CameraMain.transform.position, CameraMain.transform.forward);
            ray = CameraMain.ScreenPointToRay(mousePos);
        }
        if (CameraPlayer1)
        {
            ray = CameraPlayer1.ScreenPointToRay(mousePos);
        }
        if (CameraPlayer2)
        {
            ray = CameraPlayer2.ScreenPointToRay(mousePos);
        }
        //ray = Camera.main.ScreenPointToRay(mousePos);
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

        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.z = Mathf.RoundToInt(worldPos.z);
        worldPos.y = Mathf.RoundToInt(worldPos.y) + 1;


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
                if(hit.collider != null)
                {
                    if (hit.collider.tag == "Ground")
                    {
                        if (worldPos.x < 0)
                        {
                            player1[player1SpawnedUnits] = selectedObject;
                            P1 = Instantiate(player1[player1SpawnedUnits], worldPos, Quaternion.identity);
                            P1.transform.parent = Team1.gameObject.transform;
                            player1[player1SpawnedUnits].SetActive(true);
                            player1SpawnedUnits++;
                        }
                        if (worldPos.x > 0)
                        {

                            player2[player2SpawnedUnits] = selectedObject;
                            P2 = Instantiate(player2[player2SpawnedUnits], worldPos, Quaternion.identity);
                            P2.transform.parent = Team2.gameObject.transform;
                            player2[player2SpawnedUnits].SetActive(true);
                            player2SpawnedUnits++;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        for (int i = 0; i < parentUnits.Length; i++)
        {
            parentUnits[i].SetActive(false);

        }

        if (GameObject.FindGameObjectsWithTag("Parent") == null)
        {
            Application.Quit();
        }
    }
}
