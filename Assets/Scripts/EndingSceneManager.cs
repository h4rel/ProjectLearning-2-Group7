using System.Collections;
using System.Net.Sockets;
using System.IO;
using System.Text;
using UnityEngine;

public class EndingSceneManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(InsertRankingData());
    }

    private IEnumerator InsertRankingData()
    {
        // コルーチンで待機するためのウェイト
        yield return new WaitForSeconds(1); // 必要に応じて適切な待機時間に調整

        string command = "";
        string data = "";

        if (GlobalVariables.NOP == 1)
        {
            command = "INSERT_RANKING1";
            data = GlobalVariables._name + "," + GlobalVariables.GPA + "," + GlobalVariables.score;
        }
        else if (GlobalVariables.NOP == 2)
        {
            command = "INSERT_RANKING2";
            data = GlobalVariables.teamname + "," + GlobalVariables.GPA + "," + GlobalVariables.score;
        }
        else if (GlobalVariables.NOP == 3)
        {
            command = "INSERT_RANKING3";
            data = GlobalVariables.teamname + "," + GlobalVariables.GPA + "," + GlobalVariables.score;
        }
        else if (GlobalVariables.NOP == 4)
        {
            command = "INSERT_RANKING4";
            data = GlobalVariables.teamname + "," + GlobalVariables.GPA + "," + GlobalVariables.score;
        }
        else
        {
            Debug.LogError("Invalid number of players: " + GlobalVariables.NOP);
            yield break;
        }

        string message = command + ":" + data;

        try
        {
            using (TcpClient client = new TcpClient("localhost", 5000))
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                writer.AutoFlush = true; // 自動フラッシュを有効にする
                writer.WriteLine(message); // メッセージを送信

                // サーバーからのレスポンスを受信
                string response = reader.ReadLine();
                if (response != null)
                {
                    Debug.Log("Server response: " + response);
                }
                else
                {
                    Debug.LogError("No response from server.");
                }
            }
        }
        catch (IOException ex)
        {
            Debug.LogError("Error sending data to server: " + ex.Message);
        }
    }
}
