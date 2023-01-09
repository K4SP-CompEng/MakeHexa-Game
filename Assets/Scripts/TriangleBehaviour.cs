using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBehaviour : MonoBehaviour
{
    public bool isFlipped;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = GetComponent<SpriteRenderer>().flipY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool canBePlaced()
    {
        Collider[] tileCollider = Physics.OverlapSphere(transform.position, 0.1f);
        if (tileCollider.Length > 0)
        {
            if ((tileCollider[0].transform.tag == "Tile") && (isFlipped == tileCollider[0].GetComponent<TileBehaviour>().isFlipped) && (tileCollider[0].GetComponent<TileBehaviour>().triangle == null)) return true;
            else return false;
        }
        else return false;
    }
    public void place()
    {
        Collider[] tileCollider = Physics.OverlapSphere(transform.position, 0.1f);
        tileCollider[0].GetComponent<TileBehaviour>().InsertTriangle(gameObject);
    }
    public void flip()
    {
        isFlipped = !isFlipped;
        GetComponent<SpriteRenderer>().flipY = isFlipped;
    }
}
