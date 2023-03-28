using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform resetPos;
    public float maxScrollPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= maxScrollPoint)
        {
            transform.position = resetPos.position;//new Vector3(resetPos.position.x,0,0);
        }
    }
}
