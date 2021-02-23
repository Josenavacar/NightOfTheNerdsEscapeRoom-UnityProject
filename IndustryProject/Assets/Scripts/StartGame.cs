using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private int buildIndexToLoad = 0;

    private float currentCountDown = 0;
    private float countDown = 3;
    private bool active = false;
    
    void Update()
    {
        if(active)
        {
            currentCountDown-= Time.deltaTime;

            

            if(currentCountDown <= 0)
            {
                BeginGame();
            }
        }
    }

    private void BeginGame()
    {
        SceneManager.LoadScene(buildIndexToLoad);
    }

    public void StartTimer()
    {
        currentCountDown = countDown;
        active = true;
    }

    public void StopTimer()
    {
        active = false;
    }
}
