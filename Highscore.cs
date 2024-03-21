class HighScore
{
    public void UpdateHighScore(int currentScore)
    {
        string highScoreFile = "highscore.txt";
        int highScore = 0;

        if(File.Exists(highScoreFile))
        {
            string highScoreText = File.ReadAllText(highScoreFile);
            int.TryParse(highScoreText, out highScore);
        }
        if(currentScore > highScore)
        {
            File.WriteAllText(highScoreFile, currentScore.ToString());
        }

    }
    public int GetHighScore()
    {
        string highScoreFile = "highscore.txt";
        int highScore = 0;

        if (File.Exists(highScoreFile))
        {
            string highScoreText = File.ReadAllText(highScoreFile);
            int.TryParse(highScoreText, out highScore);
        }

        return highScore;
    }
}