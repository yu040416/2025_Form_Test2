using System;
using System.Drawing;
using System.Windows.Forms;

namespace Form_Test
{
    public partial class Form1 : Form
    {
        // constをつけると初期化時にのみ値の変更が可能になる

        /// <summary>
        /// ボタンの横幅
        /// </summary>
        const int BUTTON_SIZE_X = 100;
        /// <summary>
        /// ボタンの縦
        /// </summary>
        const int BUTTON_SIZE_Y = 100;

        /// <summary>
        /// ボタンが横に何個並ぶか
        /// </summary>
        const int BOARD_SIZE_X = 3;
        /// <summary>
        /// ボタンが縦に何個並ぶか
        /// </summary>
        const int BOARD_SIZE_Y = 3;

        /// <summary>
        /// TestButtonの二次元配列
        /// </summary>
        private TestButton[,] _buttonArray;
        // フィールドとしてRandomインスタンスを追加
        private Random _random = new Random();

        public Form1()
        {
            InitializeComponent();

            //_buttonArrayの初期化
            _buttonArray = new TestButton[BOARD_SIZE_Y, BOARD_SIZE_X];

            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                {
                    // インスタンスの生成
                    TestButton testButton =
                        new TestButton(
                            this,
                            i, j,
                            new Size(BUTTON_SIZE_X, BUTTON_SIZE_Y),
                            "");

                    // 配列にボタンの参照を追加
                    _buttonArray[j, i] = testButton;

                    // コントロールにボタンを追加
                    Controls.Add(testButton);
                }
            }

            // 初期盤面のランダム化
            RandomizeBoard();
        }

        /// <summary>
        /// TestButtonを取得する関数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public TestButton GetTestButton(int x, int y)
        {
            // 配列外参照対策
            if (x < 0 || x >= BOARD_SIZE_X) return null;
            if (y < 0 || y >= BOARD_SIZE_Y) return null;

            return _buttonArray[y, x];
        }

        // 自動生成
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("クリック");
        }
        public void RandomizeBoard()
        {
            if (_buttonArray == null) return;
            int rows = _buttonArray.GetLength(0);
            int cols = _buttonArray.GetLength(1);
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    bool isOn = _random.Next(2) == 0;
                    _buttonArray[x, y].SetEnable(isOn);
                }
            }
        }
        /// <summary>
        /// 全ボタンがOnまたはOffかをチェックする
        /// </summary>
        public void CheckClear()
        {
            if (_buttonArray == null) return;

            bool firstState = _buttonArray[0, 0]._IsEnabled(); // 最初のボタンの状態を基準にする

            for (int x = 0; x < BOARD_SIZE_X; x++)
            {
                for (int y = 0; y < BOARD_SIZE_Y; y++)
                {
                    if (_buttonArray[y, x]._IsEnabled() != firstState)
                    {
                        return; // 1つでも違う状態があればクリアではない
                    }
                }
            }

            // 全部同じ状態ならクリア
            MessageBox.Show("クリア！");
        }
    }
}

