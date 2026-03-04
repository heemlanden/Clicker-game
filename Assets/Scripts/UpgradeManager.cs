using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public ScoreManager scoreManager;

    public int upgradeCost = 50;
    public int multiplierCost = 200;

    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI multiplierText;

    void Start()
    {
        // Laad eerder opgeslagen waarden
        LoadData();
        UpdateUI();
    }

    public void KoopUpgrade()
    {
        if (scoreManager.score >= upgradeCost)
        {
            scoreManager.score -= upgradeCost;
            scoreManager.puntenPerKlik += 1;

            upgradeCost *= 2;

            scoreManager.UpdateScoreText();
            scoreManager.SlaDataOp();
            SaveData();
            UpdateUI();
        }
    }

    public void KoopMultiplier()
    {
        if (scoreManager.score >= multiplierCost)
        {
            scoreManager.score -= multiplierCost;
            scoreManager.multiplier *= 2;

            multiplierCost *= 3;

            scoreManager.UpdateScoreText();
            scoreManager.SlaDataOp();
            SaveData();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        upgradeText.text = "Upgrade (+1 per klik) - Kost: " + upgradeCost;
        multiplierText.text = "Multiplier x" + scoreManager.multiplier + " - Kost: " + multiplierCost;
    }

    // 🟢 Opslaan van kosten
    void SaveData()
    {
        PlayerPrefs.SetInt("upgradeCost", upgradeCost);
        PlayerPrefs.SetInt("multiplierCost", multiplierCost);
    }

    // 🟢 Laden van kosten bij start
    void LoadData()
    {
        upgradeCost = PlayerPrefs.GetInt("upgradeCost", upgradeCost);
        multiplierCost = PlayerPrefs.GetInt("multiplierCost", multiplierCost);
    }
}