using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    [SerializeField] private AudioSource deadSound;
    private OVRPlayerController playerController;

    private TimerHandler timerHandler;
    private Globals globals;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI killedText;
    [SerializeField] private TextMeshProUGUI rendimientoText;
    [SerializeField] private TextMeshProUGUI titleText;

    // Objetos a desaparecer
    [SerializeField] private TextMeshProUGUI gameTimer;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private GameObject bat;
    [SerializeField] private GameObject barRing;
    [SerializeField] private GameObject arrow;

    //Screen
    [SerializeField] private CanvasGroup finalScreen;

    void Start()
    {
        playerController = GameObject.Find("OVRPlayerController").GetComponent<OVRPlayerController>();
        timerHandler = GameObject.Find("Timer").GetComponent<TimerHandler>();
        globals = GameObject.Find("Globals").GetComponent<Globals>();
    }

    public void finalScreenConfig(bool win)
    {
        //Stop player
        playerController.Acceleration = 0;

        //Destroy enemies
        SpawnerManager.Instance.StopAllSpawners();
        SpawnerManager.Instance.DestroyAllEnemies();

        //Timer config
        float time = timerHandler.GetRemainingTime();
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100);

        //Text config

        timeText.text = "Tiempo total: " + string.Format("{0:D2}:{1:D2}:{2:D2}", minutes, seconds, milliseconds);
        killedText.text = "Enemigos eliminados: " + globals.getKilled();

        gameTimer.gameObject.SetActive(false);
        health.gameObject.SetActive(false);
        bat.SetActive(false);
        barRing.SetActive(false);
        arrow.SetActive(false);


        if (win)
        {
            titleText.text = "Has ganado!!!";
            titleText.color = Color.green;
            finishSound.Play();

            int kills = globals.getKilled();

            // Calcular puntuación del tiempo (40%)
            float timeScore = 0;
            if (time <= 210)
            {
                timeScore = 100;
            }
            else if (time <= 240)
            {
                timeScore = 80;
            }
            else if (time <= 300)
            {
                timeScore = 60;
            }
            else
            {
                timeScore = 40;
            }
            timeScore *= 0.4f;

            // Calcular puntuación de kills (60%)
            float killsScore = 0;
            if (kills > 10)
            {
                killsScore = 100;
            }
            else if (kills > 5)
            {
                killsScore = 80;
            }
            else if (kills > 0)
            {
                killsScore = 60;
            }
            else
            {
                killsScore = 40;
            }
            killsScore *= 0.6f;

            // Calcular puntuación global
            float rendimiento = timeScore + killsScore;

            // Convertir puntuación global a calificación
            string calificacion;
            if (rendimiento >= 90)
            {
                calificacion = "A+";
            }
            else if (rendimiento >= 80)
            {
                calificacion = "A";
            }
            else if (rendimiento >= 70)
            {
                calificacion = "B+";
            }
            else if (rendimiento >= 60)
            {
                calificacion = "B";
            }
            else if (rendimiento >= 50)
            {
                calificacion = "C+";
            }
            else
            {
                calificacion = "C";
            }

            rendimientoText.text = "Rendimiento: " + calificacion;
        }
        else
        {
            titleText.text = "Has perdido!!!";
            titleText.color = Color.red;
            rendimientoText.text = "";
            deadSound.Play();
        }

        StartCoroutine(FadeInScreen(2f));
    }

    private IEnumerator FadeInScreen(float duration)
    {
        float timeElapsed = 0f;
        float startAlpha = finalScreen.alpha;

        while (timeElapsed < duration)
        {
            finalScreen.alpha = Mathf.Lerp(startAlpha, 1f, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; // Espera un frame
        }

        finalScreen.alpha = 1f;
    }

}
