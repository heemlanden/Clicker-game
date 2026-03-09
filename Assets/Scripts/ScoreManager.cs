using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //  Score variabelen
    public int score = 0;
    public int puntenPerKlik = 1;
    public int multiplier = 1;

    public TextMeshProUGUI scoreText;

    //  Milestone systeem (plant)
    public Image plantButtonImage; // de knop image
    public Sprite plantStage1;
    public Sprite plantStage2;
    public Sprite plantStage3;
    public Sprite plantStage4;

    //  Milestone popup
    public GameObject milestonePopup;

    // Upgrade manager
    public UpgradeManager upgradeManager;

    void Start()
    {
        LaadData();
        UpdateScoreText();
        UpdatePlant();
    }

    public void KlikOpPlant()
    {
        score += puntenPerKlik * multiplier;

        UpdateScoreText();
        UpdatePlant();

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

    // 🌿 Milestone functie
    void UpdatePlant()
    {
        if (score >= 5000 && plantButtonImage.sprite != plantStage4)
        {
            plantButtonImage.sprite = plantStage4;
            ShowMilestonePopup();
        }
        else if (score >= 2000 && plantButtonImage.sprite != plantStage3)
        {
            plantButtonImage.sprite = plantStage3;
            ShowMilestonePopup();
        }
        else if (score >= 500 && plantButtonImage.sprite != plantStage2)
        {
            plantButtonImage.sprite = plantStage2;
            ShowMilestonePopup();
        }
        else if (score < 500)
        {
            plantButtonImage.sprite = plantStage1;
        }
    }

    //  Milestone popup functies
    void ShowMilestonePopup()
    {
        if (milestonePopup != null)
        {
            milestonePopup.SetActive(true);
            Invoke("HideMilestonePopup", 2f); // 2 seconden zichtbaar
        }
    }

    void HideMilestonePopup()
    {
        milestonePopup.SetActive(false);
    }

    // 🔄 Reset knop functie
    public void ResetGame()
    {
        score = 0;
        puntenPerKlik = 1;
        multiplier = 1;

        PlayerPrefs.DeleteAll();

        UpdateScoreText();
        UpdatePlant();

        if (upgradeManager != null)
        {
            upgradeManager.ResetUpgrades();
        }
    }
}