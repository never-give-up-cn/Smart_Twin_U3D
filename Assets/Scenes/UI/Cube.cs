using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        print(this.transform.lossyScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
