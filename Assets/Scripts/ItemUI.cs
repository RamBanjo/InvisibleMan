using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

    public Text itemDisplayer;

    // Start is called before the first frame update
    void Start()
    {
        Player.ItemChangeDelegate += SetDisplayedItem;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Player.ItemChangeDelegate -= SetDisplayedItem;
    }

    private void SetDisplayedItem(GameManager.Items item) {

        string shownItem = "-";

        switch (item) {
            case GameManager.Items.FLOUR:
                shownItem = "FLR";
                break;
            case GameManager.Items.NET:
                shownItem = "NET";
                break;
            case GameManager.Items.PAINT:
                shownItem = "PNT";
                break;
            default:
                break;
        }

        itemDisplayer.text = shownItem;

    }
}
