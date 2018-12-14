using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgItem : MonoBehaviour {

    public int idx = 0;
	void Start () {
		
	}
	public void OnClick()
    {
        
        FindObjectOfType<PanelBackground>().OnItemClick(idx);
    }
}
