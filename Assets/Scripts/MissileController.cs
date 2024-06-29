using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float missileSpeed = 25F;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * missileSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            GameManager.instance.score++;
            GameManager.instance.scoreText.SetText(string.Concat("Score: ", GameManager.instance.score));         
            Destroy(gm, 2F);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
