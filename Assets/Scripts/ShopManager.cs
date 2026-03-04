using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;

    // open of sluit de shop
    public void ToggleShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
}
