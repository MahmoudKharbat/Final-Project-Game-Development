using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfMoney { get; private set; }

    public UnityEvent<PlayerInventory> OnMoneyCollected;

    public void MoneyCollected()
    {
        NumberOfMoney+=100000;
        OnMoneyCollected.Invoke(this);
    }
}


