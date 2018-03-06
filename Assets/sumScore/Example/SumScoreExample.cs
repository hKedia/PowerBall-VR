using UnityEngine;

/// <summary>
/// Examples for usage of SumScore and SumScoreManager
/// </summary>
public class SumScoreExample : MonoBehaviour {
    bool started = false;

    public void SetStarted(bool hasStarted) {
        started = hasStarted;
    }

    /// <summary>
    /// Example of how to add points from a game object.
    /// </summary>
    /// <remarks>Can call from button in inspector</remarks>
    /// <param name="points">Number of points to add (negative to subtract)</param>
	public void AddPoints(int points) {
        if (started) {
            SumScore.Add(points);
        }
    }

    /// <summary>
    /// Example of how to subtract points from a game object.
    /// </summary>
    /// <remarks>Can call from button in inspector</remarks>
    /// <param name="points">Number of points to subtract from score</param>
    public void SubtractPoints (int points) {
        if (started) {
            SumScore.Add(-points);
        }
    }

    /// <summary>Resets score to zero</summary>
    /// <remarks>Can call from button in inspector</remarks>
    public void ResetPoints () {
        SumScore.Reset();
    }

    /// <summary>Save if current score is greater than high score</summary>
    public void CheckHighScore () {
        if (SumScore.Score > SumScore.HighScore)
            SumScore.SaveHighScore();
    }

    /// <summary>Resets high score to zero</summary>
    /// <remarks>Can call from button in inspector</remarks>
    public void ClearHighScore () {
        SumScore.ClearHighScore();
    }
}
