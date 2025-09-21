using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    TextMeshProUGUI textTime;
    public float timeElapsed = 30f;
    void Start()
    {
        textTime = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timeElapsed -= Time.deltaTime;
        textTime.text = "Time: " + timeElapsed.ToString("F0") + "s";
        if (timeElapsed <= 0)
        {
            textTime.text = "Time's up!";
            Time.timeScale = 0f;
        }
    }
}
