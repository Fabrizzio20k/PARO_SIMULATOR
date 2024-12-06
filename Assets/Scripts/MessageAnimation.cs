using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAnimation : MonoBehaviour
{
    // Lista de GameObjects que tienen el CanvasGroup
    [SerializeField] private List<GameObject> messageObjects;

    // Tiempo que tardará en aparecer cada uno
    public float fadeDuration = 2f;

    // Tiempo entre cada aparición
    public float delayBetween = 60f;

    // Start is called before the first frame update
    void Start()
    {
        // Inicia la animación
        StartCoroutine(FadeInMessages());
    }

    // Corrutina que maneja el fade in progresivo
    private IEnumerator FadeInMessages()
    {
        foreach (var messageObject in messageObjects)
        {
            // Obtén el CanvasGroup del GameObject
            CanvasGroup canvasGroup = messageObject.GetComponent<CanvasGroup>();

            if (canvasGroup != null)
            {
                // Asegúrate de que el CanvasGroup está al 0 de alpha al inicio
                canvasGroup.alpha = 0f;

                // Activa el GameObject en caso de que esté desactivado
                messageObject.SetActive(true);

                // Llamar a la corrutina para hacer que el CanvasGroup aparezca gradualmente
                yield return StartCoroutine(FadeIn(canvasGroup));
            }

            // Espera un poco antes de hacer aparecer el siguiente
            yield return new WaitForSeconds(delayBetween);
        }
    }

    // Corrutina que maneja el fade in de un solo CanvasGroup
    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float timeElapsed = 0f;

        // Gradualmente aumenta el alpha hasta 1
        while (timeElapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que el alpha termine en 1 al final
        canvasGroup.alpha = 1f;
    }
}
