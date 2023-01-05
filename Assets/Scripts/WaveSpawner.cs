using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] waves;
    [SerializeField] private LineController[] lineControllers;
    public LineController[] LineControllers { get => lineControllers; }

    private static WaveSpawner _instance;
    public static WaveSpawner Instance { get { return _instance; } }
    private int _currentEnemyIndex;
    private int _currentWaveIndex;
    private int _enemiesLeftToSpawn;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Start()
    {
        if(waves.Length > 0)
            _enemiesLeftToSpawn = waves[0].WaveSettings.Length;
        LaunchWave();
    }

    private IEnumerator SpawnEnemyInWave()
    {
        if(_enemiesLeftToSpawn > 0)
        {
            yield return new WaitForSeconds(waves[_currentWaveIndex]
                .WaveSettings[_currentEnemyIndex]
                .SpawnDelay);
            Instantiate(waves[_currentWaveIndex]
                .WaveSettings[_currentEnemyIndex].Enemy,
                waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex]
                .NeededSpawner.transform.position, Quaternion.identity);
            waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex]
                .NeededSpawner.GetComponent<LineController>().EnemiesAlive++;
            _enemiesLeftToSpawn--;
            _currentEnemyIndex++;
            StartCoroutine(SpawnEnemyInWave());
        }
        else
        {
            if (_currentWaveIndex < waves.Length - 1)
            {
                _currentWaveIndex++;
                _enemiesLeftToSpawn = waves[_currentWaveIndex].WaveSettings.Length;
                _currentEnemyIndex = 0;
            }
        }
    }

    public void LaunchWave()
    {
        StartCoroutine(SpawnEnemyInWave());
    }
}

[System.Serializable]
public class Waves 
{
    [SerializeField] private WaveSettings[] waveSettings;
    public WaveSettings[] WaveSettings { get => waveSettings; }
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject enemy;
    public GameObject Enemy { get => enemy; }
    [SerializeField] private GameObject neededSpawner;
    public GameObject NeededSpawner { get => neededSpawner; }
    [SerializeField] private float spawnDelay;
    public float SpawnDelay { get => spawnDelay; }
}
