using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    private string moneyString = "  Money: ";
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateMoneyText(PlayerInventory playerInventory)
    {
        moneyText.text = moneyString + playerInventory.NumberOfMoney.ToString() + "$";
    }
}