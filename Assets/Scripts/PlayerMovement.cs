using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][InspectorName("Rigidbody")] Rigidbody2D rb;
    [SerializeField][InspectorName("Jump Force")] float force;

    [SerializeField][InspectorName("Fire Sprite")] GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector2.up * force * 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        print(rb.velocity);
        if (Input.anyKeyDown)
        {
            rb.AddForce(Vector2.up * force);
            StartCoroutine(Fire());
        }
        if (transform.position.y > 8 || transform.position.y < -8) {
            GameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameManager.GameOver();
    }

    IEnumerator Fire(){
        fire.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        fire.SetActive(false);
    }
}
