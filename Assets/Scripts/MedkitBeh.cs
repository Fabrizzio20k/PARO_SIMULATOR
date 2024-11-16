using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitBeh : MonoBehaviour
{
    [SerializeField]
    private GameObject MedKit;
    private HealthHandler healthHandler;
    private GameObject audioSource;
    private int healthUp = 20;

    void Start()
    {
        healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        audioSource = GameObject.Find("HealSound");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            healthHandler.IncreaseHealth(healthUp);
            audioSource.GetComponent<AudioSource>().Play();
            Destroy(MedKit);
        }
    }
}
