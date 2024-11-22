using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorBate : MonoBehaviour
{
    [SerializeField]
    private Transform batePosition;

    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(batePosition.position.x, transform.position.y, batePosition.position.z);
        //if (isMoving)
        //{
            // alpha = 0, desaparece
            //transform.position = new Vector3(transform.position.x, transform.position.y - 12, transform.position.z);
        //}
        //else
        //{
            // alpha = 1, aparece
            //transform.position = new Vector3(transform.position.x, transform.position.y + 12, transform.position.z);
        //}
    }
}
