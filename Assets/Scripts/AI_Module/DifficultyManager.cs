using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard, Extreme }

    public Difficulty currentDifficulty = Difficulty.Medium;

    [Header("Game Variables")]
    public float enemySpeed;
    public float spawnRate;
    public float targetSize;

    public void AdjustDifficulty(float accuracy, float reactionTime, int score)
    {
        if (accuracy > 0.9f && reactionTime < 0.3f && score > 15)
            SetDifficulty(Difficulty.Extreme);
        else if (accuracy > 0.75f)
            SetDifficulty(Difficulty.Hard);
        else if (accuracy > 0.5f)
            SetDifficulty(Difficulty.Medium);
        else
            SetDifficulty(Difficulty.Easy);
    }

    private void SetDifficulty(Difficulty difficulty)
    {
        currentDifficulty = difficulty;

        switch (difficulty)
        {
            case Difficulty.Easy:
                enemySpeed = 1.0f;
                spawnRate = 1.5f;
                targetSize = 1.2f;
                break;
            case Difficulty.Medium:
                enemySpeed = 2.0f;
                spawnRate = 1.0f;
                targetSize = 1.0f;
                break;
            case Difficulty.Hard:
                enemySpeed = 3.0f;
                spawnRate = 0.75f;
                targetSize = 0.8f;
                break;
            case Difficulty.Extreme:
                enemySpeed = 4.0f;
                spawnRate = 0.5f;
                targetSize = 0.6f;
                break;
        }

        Debug.Log($"[DifficultyManager] Set to {difficulty}: speed={enemySpeed}, spawnRate={spawnRate}, size={targetSize}");
    }
}