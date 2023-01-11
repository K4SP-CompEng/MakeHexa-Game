using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PieceArrayBehaviour : MonoBehaviour
{
    List<GameObject> pieces;
    [SerializeField] GameObject[] pieceArray = new GameObject[3];
    Vector3[] piecePositions = new Vector3[3];
    // Start is called before the first frame update
    void Start()
    {
        pieces = Resources.LoadAll<GameObject>("Prefabs/Pieces").ToList();
        Debug.Log("Pieces Count: " + pieces.Count);
        piecePositions[0] = new Vector3(-4, 0, 0);
        piecePositions[1] = new Vector3(0, 0, 0);
        piecePositions[2] = new Vector3(4, 0, 0);
        pieceArray[0] = transform.GetChild(0).gameObject;
        pieceArray[1] = transform.GetChild(1).gameObject;
        pieceArray[2] = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 3)
        {
            
        }
        /*
        for(int i = 0; i < 3; i++)
        {
            if(!(pieceArray[i] is GameObject))
            {
                push(i);
                Debug.Log("Pushed");
            }
        }
        */
    }

    public void push(int index)
    {
        pieceArray[index] = Instantiate(getRandomPiece(), piecePositions[index], transform.rotation, transform);
    }
    void delete(int index)
    {
        pieceArray[index] = null;
    }
    void clear()
    {
        pieceArray[0] = null;
        pieceArray[1] = null;
        pieceArray[2] = null;
    }
    void fill()
    {
        for(int i = 0; i < 3; i++)
        {
            push(i);
        }
    }
    public GameObject getRandomPiece()
    {
        return pieces[Mathf.FloorToInt(Random.Range(0, pieces.Count))];
    }
}
