using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnPoints;
    float spawnInterval;
    private float timer;

    Score scoreManager;

    void Start()
    {
        scoreManager = FindAnyObjectByType<Score>();
        SpawnBall();
    }

    void Update()
    {
        spawnInterval = 3f / (scoreManager.score + 1f) + 0.5f;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0;
        }
    }
    void SpawnBall()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform sp = spawnPoints[index];
        GameObject ball = Instantiate(ballPrefab, sp.position, Quaternion.identity);
        BallMover mover = ball.AddComponent<BallMover>();
        mover.Init(sp.right);
    }


}
