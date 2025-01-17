using System.Linq;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    public int courseTotalScore = 0;
    public int[] holeScores = new int[25];

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (control == null)
        {
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public int UpdateTotalScore()
    {
        courseTotalScore = holeScores.Sum();
        return courseTotalScore;
    }
}
