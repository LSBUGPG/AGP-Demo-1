using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {  Spawning, Waiting, Counting};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform kiwi;
        public Transform enemy;
        public Transform tornado;
        public int count;  //Number of Kiwis
        public int eCount; //Number of Enemies
        public int tCount; //Number of Tornados
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public int remKiwi;
    bool KiwiLeft;

    public Text announceText;
    public Text kiwisLeft;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.Counting;

    void Start()
    {
        waveCountdown = timeBetweenWaves;

    }


    // Update is called once per frame
    void Update()
    {
        kiwisLeft.text = ("Kiwis remaining: " + GameObject.FindGameObjectsWithTag("Kiwi").Length);
        if (state == SpawnState.Waiting)
        {
            
            if (KiwiLeft == false)
            {
                //start next wave
                WaveFinished();
               
            }
            else
            {
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave] ) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    public void kiwiCheck()
    {
        if (remKiwi <= 0)
        {
            KiwiLeft = false;
        }
    }
    void WaveFinished()
    {
        announceText.text = ("stage complete!");
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            announceText.text = ("All Waves complete! looping...");
        }
        else
        {
            nextWave++;
        }

    }
    IEnumerator SpawnWave(Wave _wave)
    {
        announceText.text = ("Spawning wave " + _wave.name);
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnKiwi(_wave.kiwi);
            yield return new WaitForSeconds(1f/_wave.rate);
            KiwiLeft = true;
        }
        for (int i = 0; i < _wave.eCount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        for (int i = 0; i < _wave.tCount; i++)
        {
            SpawnTornado(_wave.tornado);
            yield return new WaitForSeconds(1f / _wave.rate);
        }


        state = SpawnState.Waiting;
        announceText.text = "";
        yield break;
    }

    void SpawnKiwi(Transform _kiwi)
    {
        float posX = Random.Range(-500f, 500f);
        float posZ = Random.Range(-500f, 500f);
        float posY = Random.Range(-10f, 80f);
        Instantiate(_kiwi, new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
        remKiwi++;
        //Debug.Log("Kiwi Spawn" + _kiwi.name);
    }
    void SpawnEnemy(Transform _enemy)
    {
        float posX = Random.Range(-500f, 500f);
        float posZ = Random.Range(-500f, 500f);
        float posY = Random.Range(-10f, 80f);
        Instantiate(_enemy, new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
    }
    void SpawnTornado(Transform _tornado)
    {
        float posX = Random.Range(-500f, 500f);
        float posZ = Random.Range(-500f, 500f);
        float posY = Random.Range(-10f, 80f);
        Instantiate(_tornado, new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
    }
}
