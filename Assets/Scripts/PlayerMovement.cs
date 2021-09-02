using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float turnSpeed = 1.7f;
    public ParticleSystem explosionPS;
    public GameObject gameOverElements;
    public TextMeshProUGUI highScoreText;
    public AudioSource engineSound;
    public GameObject[] spawners;
    public GameObject[] enemies;

    private float rotation;
    private float movement;
    private bool isDead = false;
    private Rigidbody rb;
    private int highscore = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        highscore = PlayerPrefs.GetInt("highscore");
    }

    private void FixedUpdate()
    {

        if (!isDead)
        {
            rotation = Input.GetAxis("Horizontal");
            movement = Input.GetAxis("Vertical");

            engineSound.volume = 0.05f + Mathf.Abs(movement) / 4;

            if (transform.position.x > 260 || transform.position.x < -10 || transform.position.z > 260 || transform.position.z < -10)
            {
                Death();
            }
        }

        Quaternion deltaRotation = Quaternion.Euler(0, 0, rotation * turnSpeed);

        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(rb.position + -transform.up * moveSpeed * movement);

        rb.AddForce(Vector3.down * 20);
    }

    public void Death()
    {
        if (Camera.main.GetComponent<CameraMovement>().score > highscore)
        {
            highscore = Camera.main.GetComponent<CameraMovement>().score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        else
        {
            highScoreText.text = "HighScore: " + highscore;
            highScoreText.color = Color.red;
        }
        isDead = true;
        rotation = 0;
        movement = 0;
        GetComponent<Shooting>().StopShooting();

        rb.AddForce(Vector3.up * 2000);
        explosionPS.Play();

        gameOverElements.SetActive(true);

        GetComponent<AudioSource>().Play();
        engineSound.volume = 0;

        foreach (var item in spawners)
        {
            item.GetComponent<SpawnEnemies>().CancelInvoke();
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in enemies)
        {
            item.GetComponent<StopEnemy>().StopEnemies();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}