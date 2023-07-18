using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCircle : MonoBehaviour
{
    public Image progressImage;
    private Coroutine loadingCoroutine;

    private void Start()
    {
        progressImage.fillAmount = 0f;
    }

    public void StartLoading()
    {
        loadingCoroutine = StartCoroutine(LoadingRoutine());
    }

    public void StopLoading()
    {
        if (loadingCoroutine != null)
        {
            StopCoroutine(loadingCoroutine);
            progressImage.fillAmount = 0f;
        }
    }

    private IEnumerator LoadingRoutine()
    {
        float elapsedTime = 0f;
        float duration = 3f;

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;
            progressImage.fillAmount = progress;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}