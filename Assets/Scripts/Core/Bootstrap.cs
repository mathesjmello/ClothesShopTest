using Player;
using UI;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = FindObjectOfType<Bootstrap>().gameObject;
                if (obj == null)
                {
                    obj = new GameObject("Bootstrap");
                    obj.AddComponent<Bootstrap>();
                }
                _instance = obj.GetComponent<Bootstrap>();
            }

            return _instance;
        }
    }

    private static Bootstrap _instance;

    public PlayerController pC;
    public HUDController hudC;
    public OutfitController outfitC;
    public InputManager inputM;
    public BuySellSys buySellSys;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;

        pC = FindObjectOfType<PlayerController>();
        hudC = FindObjectOfType<HUDController>();
        outfitC = FindObjectOfType<OutfitController>();
        inputM = FindObjectOfType<InputManager>();
        buySellSys = FindObjectOfType<BuySellSys>();
    }
}