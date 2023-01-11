using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehaviour : MonoBehaviour
{
    GameObject[,] tiles;
    GameObject[,] hexagons;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[6,9];
        for(int j = 0; j < 5; j++)
        {
            tiles[0,j] = GameObject.Find("Tile[0][" + j + "]");
            tiles[5,j] = GameObject.Find("Tile[5][" + j + "]");
        }
        for (int j = 0; j < 7; j++)
        {
            tiles[1,j] = GameObject.Find("Tile[1][" + j + "]");
            tiles[4,j] = GameObject.Find("Tile[4][" + j + "]");
        }
        for (int j = 0; j < 9; j++)
        {
            tiles[2,j] = GameObject.Find("Tile[2][" + j + "]");
            tiles[3,j] = GameObject.Find("Tile[3][" + j + "]");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    GameObject checkTile()
    {
        
    }
    bool checkHexagon()
    {
        
    }
    void emptyHexagon()
    {

    }
    */
}
