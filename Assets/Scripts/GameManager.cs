using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text text;
    private float timer;
    public GameObject bird;
    public GameObject ring;
    public float birdCount = 0;
    public float birdsActive = 0;
    public float stageTime;
    // Start is called before the first frame update
    void Awake()
    {
        Spawnring();
        timer = Time.time;
        SoundManager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - timer;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        stageTime++;
        text.text = "Time Falling:" + minutes + ":" + seconds;
        if(stageTime > 500)
        {
            birdsActive++;
            stageTime = 0;
        }

        if (birdCount < birdsActive)
        {
            SpawnBird();
        }

    }

    public void Spawnring()
    {
        float posX = Random.Range(-500f, 500f);
        float posZ = Random.Range(-500f, 500f);
        float posY = Random.Range(-10f, 80f);
        Instantiate(ring, new Vector3(posX, posY, posZ), Quaternion.Euler(0f, 0f, 0f));
    }

    public void endGame()
    {
        SceneManager.LoadScene(2);
    }

    public void SpawnBird()
    {

        //Instantiate(bird, new Vector3(0,0,0), Quaternion.Euler(0f, 0f, 0f));
        birdCount++;
    }   

}
