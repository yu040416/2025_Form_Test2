using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[,] matrix = new int[6,4];
            int i, j;

            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    //インスタンスの生成
                    Test_Button testButton = new Test_Button();

                    //ボタンの位置を設定
                    testButton.Location = new Point(50 * i, 50 * j);

                    //ボタンの大きさを設定
                    testButton.Size = new Size(50, 50);

                    //ボタン内テキストの設定
                    testButton.Text = "あいうえお";
                    //ボタンのイベント
                    testButton.Click += button1_Click;
                    /* private void button1_Click(object sender, EventArgs e)
                    * {
                    *    MessageBox.Show("C#の世界へようこそ!");
                    * }
                    * を呼び出している
                    */

                    //コントロールボタンを追加
                    Controls.Add(testButton);
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C#の世界へようこそ!");
        }
    }
}
