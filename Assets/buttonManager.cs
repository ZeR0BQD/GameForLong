using UnityEngine;

public class buttonManager : MonoBehaviour
{
    public GameObject[] objects = new GameObject[4];
    void Awake()
    {
        Time.timeScale = 0f;
    }

    public void ShowAll()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                objects[i].SetActive(true);
            }
        }
    }

    public void FirstTimePlay()
    {
        Time.timeScale = 1f;
        ShowAll();
        GameObject.Find("Canvas/ButtonSomeThing").gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
}
