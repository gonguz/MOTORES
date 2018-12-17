using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public UnityEngine.UI.Text scoringText;
    public UnityEngine.UI.Text finishText;
    public GameObject finishPanel;
    public GameObject[] lives;
    public string sceneName;

	// Use this for initialization
	void Start () {
        GameManager.instance.SetUIManager(this);
        if(finishPanel && finishText)
            finishPanel.SetActive(false);
    }

    //Actualizamos puntuación del canvas.
    public void UpdateScore(int points)
    {
        scoringText.text = points.ToString();
    }

    //Actualizamos UI de las vidas.
    public void LifeLost(int life)
    {
        lives[life].SetActive(false);
    }

    //Si el juego ha terminado entonces cargamos el correspondiente panel de victoria o derrota.
    public void FinishGame(bool playerWins)
    {
        //Estas comprobaciones son para que no fallen en las escenas primeras de /test
            if (finishPanel && finishText)
            {
                finishPanel.SetActive(true);
                if (playerWins)
                {
                    finishText.text = "Enhorabuena, has ganado!";
                }
                else
                {
                    finishText.text = "Has perdido";
                }
            }
            else
            {
                GameManager.instance.ChangeScene(sceneName);
            }
    }
}
