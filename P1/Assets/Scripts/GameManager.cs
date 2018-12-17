using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private UIManager myUI;

    private int numOfBarrels;
    private int numOfEnemies;

    public GameObject lastPlatform;

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
        numOfBarrels = GameObject.FindGameObjectsWithTag("barrel").Length;
        numOfEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
        if(lastPlatform)
            lastPlatform.SetActive(false);
    }
	
    //Método que simplemente añade puntos cuando es llamado.
    public void AddPoints(int points)
    {
        playerPoints += points;
        if(myUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            myUI.UpdateScore(playerPoints);
    }

    //Método que resta vidas cuando es llamado.
    public void OnPlayerDamaged()
    {
        playerLifes--;
        //Estas comprobaciones son para que no fallen en las escenas primeras de /test
        //Si el número de vidas es 0, entonces el juego ha terminado
        if (playerLifes == 0 && !test)
        {
            myUI.FinishGame(false);
        }
        Debug.Log("Vidas: " + playerLifes);
        if(myUI) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            myUI.LifeLost(playerLifes);
    }

    //Devuelve si el jugador sigue vivo.
    public bool PlayerLoseLife()
    {
        return playerLifes > 0;
    }

    public void SetUIManager(UIManager ui)
    {
        myUI = ui;
    }

    //Disminuye el número de barriles.
    public void SubBarrel()
    {
        numOfBarrels--;
    }

    //Disminuye el número de enemigos y si es 0, activa la bandera para ganar.
    public void SubEnemy()
    {
        numOfEnemies--;
        if(numOfEnemies == 0 && !test && lastPlatform)
        {
            lastPlatform.SetActive(true);
        }
    }

    //Si se han cogido todos los barriles y no quedan enemigos, una vez, que hayamos cogido la bandera, ganamos.
    public void PlayerTookAllBarrelsAndEnemies()
    {
        if(numOfBarrels == 0 && numOfEnemies == 0)
        {
            myUI.FinishGame(true);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
