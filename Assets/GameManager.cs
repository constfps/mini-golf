using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int holeNumber = 0;

    public GolfBallController golfBallController;

    public TextMeshProUGUI currentHoleNumberText;
    public TextMeshProUGUI currentHoleShotsText;
    public TextMeshProUGUI[] holeScoreText;
    public TextMeshProUGUI courseTotalScoreText;

    private void Start()
    {
        courseTotalScoreText.text = GameControl.control.UpdateTotalScore().ToString();
        holeNumber = SceneManager.GetActiveScene().buildIndex;
        currentHoleNumberText.text = holeNumber.ToString();

        for (int i = 0; i < holeScoreText.Length; i++)
        {
            holeScoreText[i].text = GameControl.control.holeScores[i].ToString();
        }
    }

    public void UpdateScore()
    {
        currentHoleShotsText.text = golfBallController.shotsTaken.ToString();
    }

    public void WinHole(int score)
    {
        GameControl.control.holeScores[holeNumber - 1] = score;
        holeScoreText[holeNumber - 1].text = score.ToString();
        courseTotalScoreText.text = GameControl.control.UpdateTotalScore().ToString();
        Invoke("LoadNextHole", 2);
    }

    public void LoadNextHole()
    {
        SceneManager.LoadScene(++holeNumber);
    }
}
