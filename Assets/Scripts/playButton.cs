using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButton : MonoBehaviour
{
    public GameObject CoroutineTimer;
    public GameObject TextTimer;
    public void play()
    {
        CoroutineTimer.SetActive(true);
        Destroy(gameObject);
    }
}
