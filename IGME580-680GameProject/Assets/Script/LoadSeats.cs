using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Math;

public class LoadSeats : MonoBehaviour
{
    // Start is called before the first frame update
    public int numOfRows = 1;
    public int xValueInitial = 10; //will change the rows
    public const float seatDist = 0.46f; //the amount of distance between seats to be uniform (z-axis)
    public const int scale = 20; //if scale does not auto save, will use this
    public const float radius = 1.0f;
    public float zValue = 0;
    public float yValue = 0;
    public int numOfSeatsInRow = 2;

    [SerializeField]
    GameObject propPrefab;
    private GameObject parentObject;

    Quaternion frontFacing = Quaternion.Euler(0, -90, 0);
    void Start()
    {
        GameObject managerObject = GameObject.Find("GameManager"); //locate gameManager empty object 
        parentObject = new GameObject("SeatManager"); //create a parent class to store all the seatings
        parentObject.transform.parent = managerObject.transform; //add parentObject to gameManager

        //loop through to create rows
        for (int i = 0; i < numOfRows; i++)
        {
            //float angle = i * Mathf.PI * 2 / numOfSeats;
            //float x = Mathf.Cos(angle) * radius;
            //float z = Mathf.Sin(angle) * radius;
            zValue = 0;
            Vector3 position = new Vector3(xValueInitial, yValue, zValue);
            //GameObject prop = Instantiate(propPrefab, position, Quaternion.identity, transform);
            //prop.transform.LookAt(transform.position);
            Instantiate(propPrefab, position, frontFacing, parentObject.transform);
            Debug.Log("num of rows = " + i); //test

            //Add seat to the left and right of middle placement
            for(int j = 0; j < numOfSeatsInRow; j++)
            {
                if (j % 2 == 0)
                {
                    position = new Vector3(xValueInitial, yValue, zValue = Mathf.Abs(zValue) + seatDist); //add seat dist
                }
                else
                {
                    position = new Vector3(xValueInitial, yValue,  -zValue); //since zValue was already incremented for the right, left just has to become negative
                }
                //Debug.Log(position); //test
                Instantiate(propPrefab, position, frontFacing, parentObject.transform);
            }
            xValueInitial += 1; //increment postion for new row
            yValue += 0.15f;
            numOfSeatsInRow += 2;
        }

        //Create a copy of parentObject for left and right side
        GameObject leftParentObject = Instantiate(parentObject, parentObject.transform.position, parentObject.transform.rotation);
        leftParentObject.transform.Rotate(0,50,0);
        leftParentObject.transform.position = new Vector3(1, 0, 2);

        GameObject rightParentObject = Instantiate(parentObject, parentObject.transform.position, parentObject.transform.rotation);
        rightParentObject.transform.Rotate(0, -50, 0);
        rightParentObject.transform.position = new Vector3(1, 0, -2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
