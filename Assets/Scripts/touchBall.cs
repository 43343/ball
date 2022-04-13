using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class touchBall : MonoBehaviour
{
    public float thrust;
    private Vector2 velocity;
    public float angularChangeInDegrees;
    public Text textCount;
    public GameObject gameOver;
    Rigidbody2D rigidbody;
    AudioSource audioSource;
    Animation anim;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
        //Time.timeScale = 0f;
    }
    public void touch()
    {
        anim.Play("BallAnimation3");
        audioSource.Play();
        float velocityX = Random.Range(-3000, 3000);
        velocity = new Vector2(velocityX, 0);
        Vector2 vector = new Vector2(Random.Range(-1.0f,1.0f) * thrust, 1.0f*thrust);
        rigidbody.AddForce(vector, ForceMode2D.Impulse);
        var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rigidbody.inertia;
        if(velocityX > 0)rigidbody.AddTorque(impulse * -1, ForceMode2D.Impulse);
        else if(velocityX < 0) rigidbody.AddTorque(impulse, ForceMode2D.Impulse);
        if (count>20) rigidbody.gravityScale += 3f;
        else rigidbody.gravityScale += 1.6f;
        if(count>50) thrust += 50f;
        else thrust += 24f;
        angularChangeInDegrees += 24f;
        count++;
        textCount.text = "Очки: " + count.ToString();
    }
}
