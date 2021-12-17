using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    private Text scoreText;
    private int score;

    public GameObject scorePanel;
    public Text endScore;
    public Animator endPanelAnim;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    // Update is called once per frame
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.1f);
        score++;
        scoreText.text = score.ToString();

        StartCoroutine(CountScore());
    }

    public void GameOver()
    {
        scorePanel.SetActive(false);
        endScore.text = "Height: " + score;
        endPanelAnim.Play("EndPanel");
    }

    public void Again()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
