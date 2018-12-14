using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBackground : MonoBehaviour {

    public Sprite[] spItems;
    public GameObject pbItem;
    Transform ctnt;


    private void Start()
    {
        ctnt = transform.Find("Scroll View").GetComponent<ScrollRect>().content;
        FillPanel();
    }
    void FillPanel()
    {
        for(int i = 0; i < spItems.Length; i++)
        {
            GameObject newItem = Instantiate(pbItem, ctnt);
            newItem.transform.GetChild(0).GetComponent<Image>().sprite = spItems[i];
            newItem.GetComponent<BgItem>().idx = i;
        }
    }
    public void OnItemClick(int idx)
    {
        for(int i = 0; i < ctnt.childCount; i++)
        {
            if(i==idx)
            {
                ctnt.GetChild(i).GetComponent<Image>().color = new Color(62, 183, 0);
            }
            else
            {
                ctnt.GetChild(i).GetComponent<Image>().color = new Color(255, 255, 255);
            }
        }
        GameManager.Instance.backgroundIdx = idx;
    }

}
