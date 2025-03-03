using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WRX
{
    /// <summary>
    /// 抽卡遊戲
    /// </summary>
    public class DrawingCardGame : MonoBehaviour 
    {
        /// <summary>
        /// 螢幕顯示訊息的文字
        /// </summary>
        private string message1 = "<color=#FFA500>目標 : EX (0.001%的機率) !!!</color>";
        private string message = "等待抽卡...";


        /// <summary>
        /// 顯示遊戲按鈕的控制變數 : 抽卡、結束遊戲
        /// </summary>
        private bool showGetCardButton = true;
        private bool showEndGameButton = false;
        private bool showReStartGameButton = true;


        /// <summary>
        /// 使用 GUI 顯示訊息
        /// </summary>
        protected void OnGUI()
        {
            // 顯示抽卡結果訊息
            GUI.Label(new Rect(80, 50, 400, 500), message1);
            GUI.Label(new Rect(120, 110, 400, 500), message);


            // 顯示抽卡統計資訊
            GUI.Label(new Rect(310, 70, 400, 50), $"總抽卡次數: {totalDraws}");
            //GUI.Label(new Rect(330, 100, 400, 20), $"EX卡片: {EXCardCount} 次");
            GUI.Label(new Rect(310, 100, 400, 20), $"<color=#800080>S卡片 (10%的機率): {SCardCount} 次</color>");
            GUI.Label(new Rect(310, 130, 400, 20), $"<color=#0000FF>R卡片 (20%的機率): {RCardCount} 次</color>");
            GUI.Label(new Rect(310, 160, 400, 20), $"<color=#00FF00>F卡片 (40%的機率): {FCardCount} 次</color>");
            GUI.Label(new Rect(310, 190, 400, 20), $"<color=#808080>N卡片 (45%的機率): {NCardCount} 次</color>");


            // 顯示 "抽卡" 按鈕
            if (showGetCardButton)
            {
                if (GUI.Button(new Rect(120, 200, 100, 50), "抽卡"))
                {
                    // 點擊後抽卡
                    GetCard();
                }
            }


            // 顯示 "結束遊戲" 按鈕
            if (showEndGameButton)
            {
                if (GUI.Button(new Rect(120, 200, 100, 50), "結束遊戲"))
                {
                    // 當玩家點擊結束遊戲按鈕時，結束遊戲
                    Application.Quit();
                }
            }

            // 顯示 "重新開始" 按鈕
            if (showReStartGameButton)
            {
                if (GUI.Button(new Rect(120, 250, 100, 50), "重新開始"))
                {
                    // 當玩家點擊重新開始按鈕時，重啟遊戲
                    RestartGame();
                }
            }
        }

        // 重新開始遊戲的方法
        private void RestartGame()
        {
            // 重新加載當前場景
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        /// <summary>
        /// 用來記錄總抽卡次數的變數
        /// </summary>
        private int totalDraws = 0;


        /// <summary>
        /// 用來記錄每種卡片的數量
        /// </summary>
        private int EXCardCount = 0;
        private int SCardCount = 0;
        private int RCardCount = 0;
        private int FCardCount = 0;
        private int NCardCount = 0;


        /// <summary>
        /// 隨機生成數字範圍方法
        /// </summary>
        private void GetCard()
        {
            // 隨機生成一個範圍數字
            int randomNumber = Random.Range(1, 200200);


            // 呼叫 Range 函式來處理
            Range(randomNumber);
        }


        /// <summary>
        /// 實作卡片觸發
        /// </summary>
        private void Range(int range)
        {
            // 每次抽卡，總次數加 1
            totalDraws++;


            // 根據隨機數字的範圍，決定抽到的卡片種類
            if (range >= 200000)
            {
                EXCardCount++;
                message = "<color=#FFA500>獲取卡片\n            EX\n恭喜通關遊戲!!!<color>";

                // 顯示結束遊戲與重新開始按鈕
                showEndGameButton = true;
                showGetCardButton = false;
                showReStartGameButton = true;
            }

            else if (range >= 190000 && range < 200000)
            {
                SCardCount++;
                message = "<color=#800080>獲取卡片\n            S\n差一點了!!!</color>";
            }

            else if (range >= 170000 && range < 190000)
            {
                RCardCount++;
                message = "<color=#0000FF>獲取卡片\n            R\n還可以還可以!!!</color>";
            }

            else if (range >= 90000 && range < 170000)
            {
                FCardCount++;
                message = "<color=#00FF00>獲取卡片\n            F\n比非洲人好一點而已~~<color>";
            }
            else if (range >= 1 && range < 90000)
            {
                NCardCount++;
                message = "<color=#808080>獲取卡片\n            N\n非洲人~~~\n跟你的人生一樣~~~<color>";
            }
        }
    }
}


