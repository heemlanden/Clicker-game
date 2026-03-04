using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int puntenPerKlik = 1;
    public int multiplier = 1;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        LaadData();
        UpdateScoreText();
    }

    public void KlikOpPlant()
    {
        score += puntenPerKlik * multiplier;
        UpdateScoreText();
        SlaDataOp();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Groeipunten: " + score;
    }

    public void SlaDataOp()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("puntenPerKlik", puntenPerKlik);
        PlayerPrefs.SetInt("multiplier", multiplier);
    }

    void LaadData()
    {
        score = PlayerPrefs.GetInt("score", 0);
        puntenPerKlik = PlayerPrefs.GetInt("puntenPerKlik", 1);
        multiplier = PlayerPrefs.GetInt("multiplier", 1);
    }
}