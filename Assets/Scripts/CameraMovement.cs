using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Texture2D cursor;
    public TextMeshProUGUI scoreText;
    public float height = 65f;
    public int score = 0;
    public GameObject pauseElements;
    public AudioSource engineSound;

    public bool isPaused = false;

    private void Start()
    {
        Cursor.SetCursor(cursor,new Vector2(32,32),CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
                pauseElements.SetActive(true);
                engineSound.volume = 0;
            }
            else
            {
                ContinueGame();
            }
        }

        transform.position = new Vector3(player.transform.position.x, height + player.transform.position.y, player.transform.position.z - 35);
        transform.LookAt(player.transform.position);
    }

    public void AddScore()
    {
        GetComponent<AudioSource>().Play();
        score++;
        scoreText.SetText("Score: " + score);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseElements.SetActive(false);
    }
}