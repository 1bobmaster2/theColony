using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FMODSplashScreen : MonoBehaviour
{
    [SerializeField] private List<Image> splashScreenSprites = new();
    void Awake()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }

        foreach (Image img in splashScreenSprites)
        {
            StartCoroutine(Delay(img, 2f));
        }
    }

    IEnumerator Delay(Image img, float delay)
    {
        yield return new WaitForSeconds(delay);
        yield return FadeOutSplashScreen(img);
    }
    
    IEnumerator FadeOutSplashScreen(Image img)
    {
        float duration = 1f; 
        float elapsedTime = 0f;
        float startAlpha = img.color.a;
        float endAlpha = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; 
            float alpha = Mathf.SmoothStep(startAlpha, endAlpha, t);
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            yield return null;
        }

        img.color = new Color(img.color.r, img.color.g, img.color.b, endAlpha);
        img.enabled = false;
    }
}
