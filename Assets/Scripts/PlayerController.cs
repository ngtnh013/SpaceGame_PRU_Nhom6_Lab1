using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10F;

    [Header("Missile")]
    public GameObject missile;

    public Transform missileSpawnPosition;

    public float destroyTime;

    public Transform muzzleSpawnPosition;

    [Header("Audio")]
    public AudioClip shootAudio;

    private void Update()
    {
        PlayerMovement();
        PlayerShoot();
    }

    void PlayerMovement()
    {
        //Player movement
        float xpos = Input.GetAxis("Horizontal");
        float ypos = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xpos, ypos, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            SpawnMissile();
            SpawnMuzzleFlash();
            GetComponent<AudioSource>().PlayOneShot(shootAudio);
        }
    }

    // Tạo đạn
    void SpawnMissile()
    {
        GameObject gm = Instantiate(missile, missileSpawnPosition);
        gm.transform.SetParent(null);
        Destroy(gm, destroyTime);
    }

    //Tạo hoạt ảnh khi bắn đạn ra
    void SpawnMuzzleFlash()
    {
        GameObject muzzle = Instantiate(GameManager.instance.muzzleFlash, muzzleSpawnPosition);
        muzzle.transform.SetParent(null);
        Destroy(muzzle, destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Time.timeScale = 0F;
            //Game Over Screen will appear here
            SceneManager.LoadScene("EndGameScene");
            Time.timeScale = 1F;
        }
    }
}
