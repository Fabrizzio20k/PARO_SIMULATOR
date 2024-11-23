using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;  // Asegúrate de tener acceso al espacio de nombres adecuado para Grabbable

public class IndicatorBate : MonoBehaviour
{
    [SerializeField]
    private Transform batePosition;
    
    private Grabbable grabbable;  // Componente Grabbable en BasicBat
    private bool firstTime = true;
    private bool isAlreadyMoved = false;
    void Start()
    {
        // Encuentra el Grabbable en el objeto correspondiente
        BateDamage bateDamage = FindObjectOfType<BateDamage>();
        if (bateDamage != null)
        {
            grabbable = bateDamage.GetComponentInChildren<Grabbable>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable != null)
        {
            bool isBeingGrabbed = grabbable.SelectingPoints.Count > 0;

            transform.position = new Vector3(batePosition.position.x, transform.position.y, batePosition.position.z);

            if (isBeingGrabbed){
                if (firstTime){
                    firstTime = false;
                    transform.position = new Vector3(batePosition.position.x, transform.position.y-12, batePosition.position.z);
                    isAlreadyMoved = true;
                }
                else{
                    if (!isAlreadyMoved){
                        transform.position = new Vector3(batePosition.position.x, transform.position.y-12, batePosition.position.z);
                        isAlreadyMoved = true;
                    }
                }
            }
            else{
                if (isAlreadyMoved){
                    transform.position = new Vector3(batePosition.position.x, transform.position.y+12, batePosition.position.z);
                    isAlreadyMoved = false;
                }
            }
            
        }
    }
}
