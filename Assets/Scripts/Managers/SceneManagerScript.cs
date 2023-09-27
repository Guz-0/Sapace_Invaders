using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    
    public static SceneManagerScript Instance;

    [SerializeField] private float loadingSpeed = 1f;
    [SerializeField] private float lerpMax = 1f;
    private float lerpedProgress = 0f;

    [SerializeField] private AnimationCurve loadingCurve;

    [SerializeField] private Slider loadingSlider;
    [SerializeField] private TMP_Text loadingText;
    [SerializeField] private GameObject loadingScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        loadingScreen.SetActive(false);

    }

    public IEnumerator LoadScene(string name)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        asyncLoad.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        while (!asyncLoad.isDone)
        {
            float totalProgress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            lerpedProgress = Mathf.MoveTowards(lerpedProgress, totalProgress, loadingSpeed * Time.deltaTime);
            loadingSlider.value = lerpedProgress;

            loadingText.SetText((int)(totalProgress * 100) + "%");

            //Debug.Log(lerpedProgress);

            if (asyncLoad.progress >= 0.9f && lerpedProgress >= lerpMax)
            {
                asyncLoad.allowSceneActivation = true;
                StartCoroutine(stopLoadingScreen());
                Debug.Log("COMPLETED2");
                GameManager.Instance.highScore = 0;
                GameManager.Instance.numberOfRounds = 0;
                GameManager.Instance.maxMoveTime = GameManager.Instance.maxMoveTimeFirst;
            }

            /*if(totalProgress >= 1f)
            {
                asyncLoad.allowSceneActivation = true;
                loadingScreen.SetActive(false);
            }*/

            yield return null;
        }
    }

    private IEnumerator stopLoadingScreen()
    {
        yield return new WaitForSeconds(0.1f);
        loadingScreen.SetActive(false);

    }
}
