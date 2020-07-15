using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public Player Player;
    public Text CoinCount;
    private Bag bag;

    public void UpdateUI(Bag bag)
    {
        CoinCount.text = bag.GetCoinCount().ToString();
    }

    private void Start()
    {
        bag = Player.GetComponent<Bag>();
        bag.OnUpdate += UpdateUI;
    }

    private void OnDestroy()
    {
        bag.OnUpdate -= UpdateUI;
    }
}