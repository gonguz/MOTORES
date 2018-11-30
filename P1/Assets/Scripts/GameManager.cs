using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int playerLifes;

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
	}
	
    public void AddPoints(int points)
    {
        playerPoints += points;
    }

    public void OnPlayerDamaged()
    {
        playerLifes--;
    }

    //a.k.a LifesLeft
    public bool PlayerLoseLife()
    {
        return playerLifes > 0;
    }

}
