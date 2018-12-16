using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private UIManager MyUI;

    private int NumOfBarrels;
    private int NumOfEnemies;

    public GameObject LastPlatform;

    public bool Test;

    private int PlayerLifes;

    private int PlayerPoints;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
            DontDestroyOnLoad(this);
    }
    private void Start () {
        PlayerPoints = 0;
        PlayerLifes = 3;
        if(MyUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            MyUI.UpdateScore(PlayerPoints);
        NumOfBarrels = GameObject.FindGameObjectsWithTag("barrel").Length;
        NumOfEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
        if(LastPlatform)
            LastPlatform.SetActive(false);
    }
	
    public void AddPoints(int points)
    {
        PlayerPoints += points;
        if(MyUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            MyUI.UpdateScore(PlayerPoints);
    }

    public void OnPlayerDamaged()
    {
        PlayerLifes--;
        if (PlayerLifes == 0 && !Test) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
        {
            MyUI.FinishGame(false);
        }
        Debug.Log("Vidas: " + PlayerLifes);
        if(MyUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            MyUI.LifeLost(PlayerLifes);
    }

    //a.k.a LifesLeft
    public bool PlayerLoseLife()
    {
        return PlayerLifes > 0;
    }

    public void SetUIManager(UIManager ui)
    {
        MyUI = ui;
    }

    public void SubBarrel()
    {
        NumOfBarrels--;
    }
    public void SubEnemy()
    {
        NumOfEnemies--;
        if(NumOfEnemies == 0 && !Test && LastPlatform)
        {
            LastPlatform.SetActive(true);
        }
    }

    public void PlayerTookAllBarrelsAndEnemies()
    {
        if(NumOfBarrels == 0 && NumOfEnemies == 0)
        {
            MyUI.FinishGame(true);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
