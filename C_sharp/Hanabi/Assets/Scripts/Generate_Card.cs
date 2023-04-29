using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Card : MonoBehaviour
{
    public TextMesh card_number; 

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 255.0f);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
