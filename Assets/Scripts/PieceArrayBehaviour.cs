using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PieceArrayBehaviour : MonoBehaviour
{
    GameObject[] pieces;
    GameObject[] pieceArray = new GameObject[3];
    Vector3[] piecePositions = new Vector3[3];
    // Start is called before the first frame update
    void Start()
    {
        pieces = Resources.LoadAll("Prefabs/Pieces", typeof(GameObject)).Cast<GameObject>().ToArray();
        piecePositions[0] = new Vector3(-4, 0, 0);
        piecePositions[1] = new Vector3(0, 0, 0);
        piecePositions[2] = new Vector3(4, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void push(int index)
    {
        pieceArray[index] = Instantiate(getRandomPiece());
        pieceArray[index].transform.parent = gameObject.transform;
        pieceArray[index].transform.position = piecePositions[0];
    }
    void delete(int index)
    {

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
        return pieces[Mathf.FloorToInt(Random.Range(0, pieces.Length))];
    }
}
