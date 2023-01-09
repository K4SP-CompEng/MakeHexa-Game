using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public GameObject triangle;
    GameObject previousTriangle;
    public bool isFlipped;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = GetComponent<SpriteRenderer>().flipY;
        triangle = null;
        previousTriangle = triangle;
    }

    // Update is called once per frame
    void Update()
    {
        if (triangle != previousTriangle)
        {
            if(triangle == null)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Triangle-shape_0");
                previousTriangle = triangle;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = triangle.GetComponent<SpriteRenderer>().sprite;
                previousTriangle = triangle;
            }
        }
    }

    public void InsertTriangle(GameObject triangle)
    {
        this.triangle = triangle;
    }
    public void DeleteTriangle()
    {
        this.triangle = null;
    }
}
