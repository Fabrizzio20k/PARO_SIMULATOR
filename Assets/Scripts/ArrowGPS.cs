using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGPS : MonoBehaviour
{
    private GameObject arrow;
    private Vector3 initialOffset;
    private Quaternion initialRotation;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform target; // Ahora tenemos un Transform como objetivo

    // Distancia desde el jugador donde queremos que se posicione la flecha
    public float distanceFromPlayer = 5f;

    // Altura sobre el jugador donde queremos que se posicione la flecha
    public float heightAbovePlayer = 2f;

    // Oscilación de la flecha
    public float floatHeight = 0.3f;  // La cantidad que se mueve arriba y abajo
    public float floatSpeed = 1.5f;   // La velocidad de oscilación

    // Rotación adicional para un movimiento dinámico
    public float rotationSpeed = 30f; // Velocidad de rotación constante

    // Movimiento aleatorio lateral (para más naturalidad)
    public float vibrationAmount = 0.1f; // Cantidad de vibración lateral
    public float vibrationSpeed = 2f;    // Velocidad de la vibración

    private float originalY;

    void Start()
    {
        arrow = this.gameObject;

        // Guardamos la posición inicial relativa de la flecha con respecto al jugador
        initialOffset = arrow.transform.position - player.position;

        // Guardamos la rotación inicial de la flecha
        initialRotation = arrow.transform.rotation;

        // Guardamos la posición Y original para oscilación
        originalY = arrow.transform.position.y;
    }

    void Update()
    {
        // Tomamos la dirección en la que el jugador está mirando (eje Y no cambia)
        Vector3 forwardDirection = player.forward;

        // Queremos que la flecha siempre esté frente al jugador a una distancia fija
        // Ajustamos la posición de la flecha a esa dirección
        Vector3 newPosition = player.position + forwardDirection * distanceFromPlayer + Vector3.up * heightAbovePlayer;

        // Movimiento oscilante arriba y abajo
        float newY = originalY + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        newPosition.y = newY;

        // Oscilación lateral suave para un movimiento más orgánico
        float vibration = Mathf.Sin(Time.time * vibrationSpeed) * vibrationAmount;
        newPosition.x += vibration;

        // Actualizamos la posición de la flecha según la dirección hacia donde el jugador está mirando
        arrow.transform.position = newPosition;

        // Calculamos la dirección hacia el objetivo (target.position)
        Vector3 directionToTarget = target.position - arrow.transform.position;

        // Creamos una rotación para que la flecha apunte hacia el objetivo
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Ahora, aplicamos solo la rotación en el eje Z para que apunte al objetivo
        // Y mantenemos la rotación original en los ejes X y Y
        arrow.transform.rotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, targetRotation.eulerAngles.z);

        // También, podemos añadir una rotación continua para darle más dinamismo
        arrow.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
