using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform SpawnPrefab;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;
    public float timeBetweenMonsters = 0.3f;
    public Text waveCountdownText;

    private int waveIndex = 0;
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenMonsters);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPrefab.position, SpawnPrefab.rotation);
    }
}
