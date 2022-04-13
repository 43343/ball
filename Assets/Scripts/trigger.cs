using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger : MonoBehaviour
{
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "ball")
        {
            col.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameOver.SetActive(true);
            Invoke("ReloadedScene", 5.0f);
        }
    }
    void ReloadedScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
