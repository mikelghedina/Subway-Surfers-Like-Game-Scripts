using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public Image[] hearts;
    public int health;
    public int nOfHearts;
    public Sprite fullheart;
    public Sprite emptyheart;
    
    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLvl = 30;
    public Text scoreText;
    public PlayerMove PMover;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (score >= scoreToNextLvl)
            LevelUp();

        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();

        if(score > PlayerPrefs.GetInt("HighScore", (int)score))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            
        }

        HealthController();
    }
    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLvl *= 2;
        difficultyLevel++;

        PMover.SetSpeed(difficultyLevel);
    }
    
    public void HealthController()
    {
        if (health > nOfHearts)
        {
            health = nOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }
            if (i < nOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    
}
