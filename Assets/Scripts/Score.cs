using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /// <summary>Scoreを表示するGUIText</summary>
    [SerializeField] Text scoreGUIText;
    /// <summary>HighScoreを表示するGUIText</summary>
    [SerializeField] Text highScoreGUIText;
    /// <summary>Score</summary>
    private int score;
    /// <summary>highScore</summary>
    private int highScore = 0;
    //PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";


    private void Start()
    {
         Initialize();
    }

    private void Update()
    {
        //スコアがハイスコアより大きければ
        if (highScore < score)
        {
            highScore = score;
        }

        // スコア・ハイスコアを表示する
        scoreGUIText.text = "score :" + score.ToString();
        highScoreGUIText.text = "HighScore :" + highScore.ToString();
    }

    //ゲーム開始前の状態に戻す
    private void Initialize()
    {

        //scoreを0に戻す
        score = 0;

        //highScoreを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    //ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point;
    }

    //ハイスコアの保存
    public void Save()
    {
        //highScoreを保存する
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        //ゲーム開始前の状態に戻す
        Initialize();
    }
}