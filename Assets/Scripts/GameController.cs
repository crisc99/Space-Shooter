using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
public GameObject hazard;
public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;
public Text restartText;
public Text gameOverText;

private bool gameOver;
private bool restart;

public Text ScoreText;
private int score;

void Start()
{
    gameOver = false;
    restart = false;
    restartText.text = "";
    gameOverText.text = "";
score = 0;
UpdateScore();
StartCoroutine(SpawnWaves());
}

void Update ()
{
 if (restart)
 {
     if (Input.GetKeyDown (KeyCode.R))
     {
      SceneManager.LoadScene("Space");
     }
 }
    if(Input.GetKeyDown("escape")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
         Application.Quit(); // Quits the game
     }
}

IEnumerator SpawnWaves()
{
yield return new WaitForSeconds(startWait);
while (true)
{
for (int i = 0; i < hazardCount; i++)
{
Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
Quaternion spawnRotation = Quaternion.identity;
Instantiate(hazard, spawnPosition, spawnRotation);
yield return new WaitForSeconds(spawnWait);
}
yield return new WaitForSeconds(waveWait);

if (gameOver)
{
    restartText.text = "Press 'R' for Restart";
    restart = true;
    break;
}
}
}

public void AddScore(int newScoreValue)
{
score += newScoreValue;
UpdateScore();
}

void UpdateScore()
{
ScoreText.text = "Score: " + score;
}

public void GameOver ()
{
    gameOverText.text = "Game Over!";
    gameOver = true;
}

}
