using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject[] p1Lifes;
    public GameObject[] p2Lifes;
    public int p1Life;
    public int p2Life;
    public string mainMenu;

    void Start()
    {

    }

    void Update()
    {
        if (p1Life <=0 )
        {
            player1.SetActive(false);
            p2Wins.SetActive(true);        
        }
        if (p2Life <= 0)
        {
            player2.SetActive(false);
            p1Wins.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(mainMenu);
    }

    public void HurtPlayer1()
    {
        p1Life -= 1;
        for(int i=0; i<p1Lifes.Length; i++)
        {
            if (p1Life > i)
            {
                p1Lifes[i].SetActive(true); 
            }
            else
            {
                p1Lifes[i].SetActive(false);
            }
        }
    }

    public void HurtPlayer2()
    {
        p2Life -= 1;
        for (int i = 0; i < p2Lifes.Length; i++)
        {
            if (p2Life > i)
            {
                p2Lifes[i].SetActive(true);
            }
            else
            {
                p2Lifes[i].SetActive(false);
            }
        }
    }
}
