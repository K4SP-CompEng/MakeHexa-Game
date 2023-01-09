using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeColor()
    {
        Camera.main.backgroundColor = color;
    }

    private void OnMouseDown()
    {
        changeColor();
    }
}
