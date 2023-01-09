using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviour : MonoBehaviour
{
    Transform[] triangles;
    Vector3 initialPosition;
    Vector3 mousePositionOffset;
    Vector3[] trianglePositions = new Vector3[6];

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        trianglePositions[0] = transform.position;
        trianglePositions[1] = transform.position + new Vector3(-0.9f, 0, 0);
        trianglePositions[2] = transform.position + new Vector3(-0.9f, 1.2f, 0);
        trianglePositions[3] = transform.position + new Vector3(0, 1.2f, 0);
        trianglePositions[4] = transform.position + new Vector3(0.9f, 1.2f, 0);
        trianglePositions[5] = transform.position + new Vector3(0.9f, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void rotate()
    {
        bool rotated;
        int j;
        for(int i = 0; i < triangles.Length; i++)
        {
            rotated = false;
            j = 0;
            while (!rotated && (j < 6))
            {
                if(triangles[i].position == trianglePositions[j])
                {
                    triangles[i].position = trianglePositions[(j + 1) % 6];
                    rotated = true;
                }
                j++;
            }
            triangles[i].GetComponent<TriangleBehaviour>().flip();
        }
    }
    private bool checkAll()
    {
        bool canPlace = true;
        int i = 0;
        while(canPlace && (i < triangles.Length))
        {
            canPlace = triangles[i].GetComponent<TriangleBehaviour>().canBePlaced();
            i++;
        }
        return canPlace;
    }
    private void place()
    {
        for(int i = 0; i < triangles.Length; i++)
        {
            triangles[0].GetComponent<TriangleBehaviour>().place();
        }
    }

    private void OnMouseEnter()
    {
        triangles = new Transform[transform.childCount];
        for (int i = 0; i < triangles.Length; i++)
        {
            triangles[i] = transform.GetChild(i);
        }
    }
    private void OnMouseDown()
    {
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
    private void OnMouseUp()
    {
        if(transform.position == initialPosition)
        {
            rotate();
        }
        if (checkAll())
        {
            for (int i = 0; i < triangles.Length; i++)
            {
                Debug.Log(triangles[i].GetComponent<TriangleBehaviour>().canBePlaced());
                triangles[i].GetComponent<TriangleBehaviour>().place();
            }
            //Destroy(gameObject);
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}
