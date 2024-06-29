using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y <= -9f)
        {
            SceneManager.LoadScene("EndGameScene");
            // Time.timeScale được đặt thành 1.0 để cho phép thời gian trong trò chơi chạy với tốc độ bình thường.
            Time.timeScale = 1f;
        }
    }
}
