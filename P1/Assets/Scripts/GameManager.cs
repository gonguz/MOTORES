using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

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
    void Start () {
        playerPoints = 0;
	}
	
    public void AddPoints(int points)
    {
        playerPoints += points;
    }

}
