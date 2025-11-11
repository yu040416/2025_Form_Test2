using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Test
{
    public class TestButton : Button
    {
        /// <summary>onの時の色</summary>
        private Color _onColor = Color.LightBlue;

        /// <summary>offの時の色</summary>
        private Color _offColor = Color.DarkBlue;

        /// <summary>現在OnかOffか</summary>
        private bool _enable;

        /// <summary>Form1の参照</summary>
        private Form1 _form1;

        /// <summary>横位置</summary>
        private int _x;

        /// <summary> 縦位置</summary>
        private int _y;

        /// <summary>
        /// 反転させる範囲のデータ
        /// </summary>
        private int[][] _toggleData =
        {
            new int[]{0,0 },
            new int[]{1,0 },
            new int[]{-1,0 },
            new int[]{0,1 },
            new int[]{0,-1 },
        };

        public TestButton(Form1 form1, int x, int y, Size size, string text)
        {
            // Form1の参照を保管
            _form1 = form1;

            // 横位置を保管
            _x = x;
            // 縦位置を保管
            _y = y;

            // ボタンの位置を設定
            Location = new Point(x * size.Width, y * size.Height);
            // ボタンの大きさを設定
            Size = size;
            // ボタン内のテキストを設定
            Text = text;

            SetEnable(false);

            Click += ClickEvent;
        }

        /// <summary>onとoffの設定</summary> 
        /// <param name="on"></param>
        public void SetEnable(bool on)
        {
            _enable = on;
            if (on)
            {
                BackColor = _onColor;
            }
            else
            {
                BackColor = _offColor;
            }
        }

        /// <summary>
        /// 呼び出すたびにOnとOffを入れ替える関数
        /// </summary>
        public void Toggle()
        {
            SetEnable(!_enable);
        }

        /// <summary>
        /// 各ボタンがクリックされた時に呼び出される関数
        /// クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickEvent(object sender, EventArgs e)
        {
            ////　楽な書き方
            //_form1.GetTestButton(_x, _y)?.Toggle();
            //_form1.GetTestButton(_x + 1, _y)?.Toggle();
            //_form1.GetTestButton(_x - 1, _y)?.Toggle();
            //_form1.GetTestButton(_x, _y + 1)?.Toggle();
            //_form1.GetTestButton(_x, _y - 1)?.Toggle();


            // かっちょいい書き方
            for (int i = 0; i < _toggleData.Length; i++)
            {
                var data = _toggleData[i];
                var button = _form1.GetTestButton(_x + data[0], _y + data[1]);

                if (button != null)
                {
                    button.Toggle();
                }
            }
        }
    }
}