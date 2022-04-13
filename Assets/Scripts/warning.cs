using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warning : MonoBehaviour
{
    public GameObject warningPanel;
    public Toggle noSee;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Submit"))
        {
            Destroy(warningPanel);
        }
    }
    public void submit()
    {
        if (noSee.isOn) PlayerPrefs.SetInt("Submit", 1);
        Destroy(warningPanel);
    }
}
