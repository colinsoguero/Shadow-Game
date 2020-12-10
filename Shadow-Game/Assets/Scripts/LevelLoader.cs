using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static LevelLoader instance;
    void Update()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void LoadNextLevel()
    {
        Webcam.instance.webcamTexture.Stop();
        Destroy(Webcam.instance.webcamTexture);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void Reset()
    {
        Webcam.instance.webcamTexture.Stop();
        Destroy(Webcam.instance.webcamTexture);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
