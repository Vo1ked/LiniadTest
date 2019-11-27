using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    private static int _currentLevel;
    public SwipeManager swipeManager;
    Text _currentLevelText;
    bool pause = false;
    void Awake()
    {
        Instance = this;
        swipeManager = GetComponent<SwipeManager>();
    }
    private int _holes = 0;
    public void AddHole()
    {
        _holes++;
    }

    public void RemoveHole()
    {
        _holes--;
        if(_holes < 1)
        {
            LevelComplite();
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(_currentLevel);
    }

    public void Pause()
    {
        pause = !pause;
        Time.timeScale = pause ? 0 : 1;
    }

    void LevelComplite()
    {
        _currentLevel = (_currentLevel) % SceneManager.sceneCount;
        SceneManager.LoadScene(_currentLevel);
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentLevelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        _currentLevelText.text = "Level " + _currentLevel + 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
