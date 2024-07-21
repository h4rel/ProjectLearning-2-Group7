using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.IO;

public class RankingManager : MonoBehaviour
{
    public Text[] teamNames; // 4つのチーム名を表示するText
    public Text[] gpas;      // 4つのGPAを表示するText
    public Text[] scores;    // 4つのScoreを表示するText
    public Button button1;   // 1人用のボタン
    public Button button2;   // 2人用のボタン
    public Button button3;   // 3人用のボタン
    public Button button4;   // 4人用のボタン

    private void Start()
    {
        // 各ボタンに対応するランキングタイプを設定
        button1.onClick.AddListener(() => FetchRankingData("ranking1"));
        button2.onClick.AddListener(() => FetchRankingData("ranking2"));
        button3.onClick.AddListener(() => FetchRankingData("ranking3"));
        button4.onClick.AddListener(() => FetchRankingData("ranking4"));
    }

    private void FetchRankingData(string rankingType)
    {
        StartCoroutine(FetchRankingDataCoroutine(rankingType));
    }

    private IEnumerator FetchRankingDataCoroutine(string rankingType)
    {
        string response = "";
        string command = $"FETCH_{rankingType.ToUpper()}:";
        
        // サーバーからデータを取得する
        using (TcpClient client = new TcpClient("localhost", 5000))
        using (NetworkStream stream = client.GetStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        {
            writer.WriteLine(command);
            writer.Flush();

            response = reader.ReadLine();
        }

        if (response.StartsWith("fetchRankingSuccess"))
        {
            string[] data = response.Split(',');

            for (int i = 0; i < 4; i++)
            {
                teamNames[i].text = data[3 * i + 1];
                gpas[i].text = data[3 * i + 2];
                scores[i].text = data[3 * i + 3];
            }
        }
        else
        {
            Debug.LogError($"Failed to fetch {rankingType} data");
        }

        yield return null;
    }
}
