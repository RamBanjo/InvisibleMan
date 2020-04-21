using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

    public Image itemDisplayer;

    // Start is called before the first frame update
    void Start()
    {
        Player.ItemChangeDelegate += SetDisplayedItem;
        itemDisplayer.enabled = false;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Player.ItemChangeDelegate -= SetDisplayedItem;
    }

    private void SetDisplayedItem(GameManager.Items item) {

        Sprite shownItem;

        

        if(item == GameManager.Items.NONE) {
            itemDisplayer.enabled = false;
        } else {
            itemDisplayer.enabled = true;
            shownItem = GameManager.s_gamePickups[(int)item - 1].unselected;
            itemDisplayer.sprite = shownItem;
        }

    }
}
