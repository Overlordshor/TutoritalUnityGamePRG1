using UnityEngine;

public class Bag : MonoBehaviour
{
    public event System.Action<Bag> OnUpdate;

    private int coinCount;

    public void AddCoin()
    {
        coinCount++;
        OnUpdate?.Invoke(this);
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}