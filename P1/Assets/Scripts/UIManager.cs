using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public UnityEngine.UI.Text ScoringText;
    public UnityEngine.UI.Text FinishText;
    public GameObject FinishPanel;
    public GameObject[] Lives;

	// Use this for initialization
	void Start () {
        GameManager.instance.setUIManager(this);
        if(FinishPanel && FinishText)
            FinishPanel.SetActive(false);
    }

    public void UpdateScore(int points)
    {
        ScoringText.text = points.ToString();
    }

    public void LifeLost(int life)
    {
        Lives[life].SetActive(false);
    }

    public void FinishGame(bool playerWins)
    {
        //Estas comprobaciones son para que no fallen en las escenas primeras de /test
        if (FinishPanel && FinishText) 
        {
            FinishPanel.SetActive(true);
            if (playerWins)
            {
                FinishText.text = "Enhorabuena, has ganado!";
            }
            else
            {
                FinishText.text = "Has perdido";
            }
        }
    }
}
