using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMenu : MonoBehaviour {

    public GameObject mainmenu;
	
    public void Back()
    {
        mainmenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
