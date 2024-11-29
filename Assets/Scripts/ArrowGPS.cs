using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGPS : MonoBehaviour
{
    private GameObject arrow;
    private Vector3 initialOffset;  // Desfase inicial entre el jugador y la flecha

    [SerializeField]
    private Transform player;

    // Objetivo hacia el que la flecha debe apuntar
    private Vector3 targetPosition = new Vector3(95.32f, -0.07f, 670.95f);

    // Velocidad de rotación para un giro suave
    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        arrow = this.gameObject;
        // Calcula el desfase entre la flecha y el jugador
        initialOffset = arrow.transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Actualiza la posición de la flecha para que siga al jugador, manteniendo el desfase
        Vector3 targetPositionWithOffset = new Vector3(player.position.x + initialOffset.x, arrow.transform.position.y, player.position.z + initialOffset.z);
        arrow.transform.position = targetPositionWithOffset;

        // Rota la flecha para que apunte hacia el objetivo, solo sobre el eje Y
        Vector3 directionToTarget = targetPosition - arrow.transform.position;
        directionToTarget.y = 0;  // No queremos que la flecha gire en el eje Y
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Realiza una rotación suave hacia el objetivo
        arrow.transform.rotation = Quaternion.Slerp(arrow.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
