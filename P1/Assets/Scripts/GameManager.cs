using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private UIManager myUI;

    private int NumOfBarrels;
    private int NumOfEnemies;

    public GameObject LastPlatform;

    public bool test;

    private int playerLifes;

    private int playerPoints;
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
        playerPoints = 0;
        playerLifes = 3;
        if(myUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            myUI.UpdateScore(playerPoints);
        NumOfBarrels = GameObject.FindGameObjectsWithTag("barrel").Length;
        NumOfEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
        if(LastPlatform)
            LastPlatform.SetActive(false);
    }
	
    public void AddPoints(int points)
    {
        playerPoints += points;
        if(myUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            myUI.UpdateScore(playerPoints);
    }

    public void OnPlayerDamaged()
    {
        playerLifes--;
        if (playerLifes == 0 && !test) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
        {
            myUI.FinishGame(false);
        }
        Debug.Log("Vidas: " + playerLifes);
        if(myUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            myUI.LifeLost(playerLifes);
    }

    //a.k.a LifesLeft
    public bool PlayerLoseLife()
    {
        return playerLifes > 0;
    }

    public void setUIManager(UIManager ui)
    {
        myUI = ui;
    }

    public void subBarrel()
    {
        NumOfBarrels--;
    }
    public void subEnemy()
    {
        NumOfEnemies--;
        if(NumOfEnemies == 0)
        {
            LastPlatform.SetActive(true);
        }
    }

    public void PlayerTookAllBarrelsAndEnemies()
    {
        if(NumOfBarrels == 0 && NumOfEnemies == 0)
        {
            myUI.FinishGame(true);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
