using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float bossHealth = 100f;
    public int money = 0;
    public float time = 2f;
    bool fadein = false;

    public Image image;

    public void FinishLevel(float speed, float damage)
    {
        if (damage * speed * 10 < bossHealth)
            Restart();
        else
            LoadNextScene();
    }

    public void LoadNextScene()
    {
        fadein = true;
        StartCoroutine(LoadNext());

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(3);
        fadein = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (fadein)
        {
            Time.timeScale = 1.0f;
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeIn()
    {

        var tempColor = image.color;
        for (float f = 0; f <= 2; f += Time.deltaTime)
        {
            tempColor = image.color;
            tempColor.a = Mathf.Lerp(0f, 1f, f / 2);
            image.color = tempColor;
            yield return null;
        }
        fadein = false;
        tempColor = image.color;
        tempColor.a = 1;
        image.color = tempColor;
    }
}
