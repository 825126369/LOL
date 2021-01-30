using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //设置鼠标位置
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private void Form1_Load(object sender, EventArgs e)
        {
            //安装勾子
            kh = new KeyboardHook();
            kh.SetHook();
            kh.OnKeyDownEvent += kh_OnKeyDownEvent;
        }
        KeyboardHook kh;

        void kh_OnKeyDownEvent(object sender, KeyEventArgs e)
        {

            if (e.KeyData == (Keys.J | Keys.Control))
            {
                timer1.Start();
            }

            if (e.KeyData == (Keys.H | Keys.Control))
            {
                timer1.Stop();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           kh.UnHook();
        }

        public void ReStart()
        {
            //重新开始游戏
            //这里需要等待游戏结束后才能执行
            //首先延迟几秒然后点击再来一局按钮
            ClickREstargame();

            //点击之后等待1分钟，因为一般60秒内能匹配到人所以保证不点错
            System.Threading.Thread.Sleep(30000);//30秒
            //先点进入游戏按钮
            Lodgame();
            //选英雄-防止一个备选
            Select_Zed();
            Select_Leesin();
        }
        public void Lodgame()
        {
            //进入游戏点击，无需延迟直接点
            int x = 768;
            int y = 443;
            SetCursorPos(x, y); //设置鼠标位置，x，y为账号框相对屏幕的位置       

            //System.Threading.Thread.Sleep(200);//设置暂停时间’
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);//设置暂停时间
        }
        /// <summary>
        /// 点击再来一局
        /// </summary>
        public void ClickREstargame()
        {
            //点击再来一局1100-661
            //这里直接点击无需延迟
            int x = 1100;
            int y = 661;
            SetCursorPos(x, y); //设置鼠标位置，x，y为账号框相对屏幕的位置       

            //System.Threading.Thread.Sleep(200);//设置暂停时间’
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);//设置暂停时间
        }
        /// <summary>
        /// 选择英雄-劫
        /// </summary>
        public void Select_Zed()
        {
            //选择盲僧
            int end_x = 393;
            int end_y = 303;
            SetCursorPos(end_x, end_y); //设置鼠标位置，x，y为账号框相对屏幕的位置       

            //System.Threading.Thread.Sleep(200);//设置暂停时间’
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);//设置暂停时间
        }
        /// <summary>
        /// 选择英雄-盲僧
        /// </summary>
        public void Select_Leesin()
        {
            //选择盲僧
            int end_x = 697;
            int end_y = 226;
            SetCursorPos(end_x, end_y); //设置鼠标位置，x，y为账号框相对屏幕的位置       

            //System.Threading.Thread.Sleep(200);//设置暂停时间’
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);//设置暂停时间
        }
        int i = 0;
        /// <summary>
        /// 进入游戏后
        /// </summary>
        public void Start_game()
        {
            //定时点击结束游戏的按钮
            int end_x = 682;
            int end_y = 480;
            SetCursorPos(end_x, end_y); //设置鼠标位置，x，y为账号框相对屏幕的位置       

            //System.Threading.Thread.Sleep(200);//设置暂停时间’-1100-661
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);//设置暂停时间
            i++;
            //移动
            int x = 774;

            int y = 275;


            SetCursorPos(x, y); //设置鼠标位置，x，y为账号框相对屏幕的位置       

            //System.Threading.Thread.Sleep(200);//设置暂停时间’
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);//设置暂停时间
            //点技能加点-676-666
            int d_x = 676;
            int d_y = 666;
            SetCursorPos(d_x, d_y); //设置鼠标位置，x，y为账号框相对屏幕的位置       
            System.Threading.Thread.Sleep(200);
            //System.Threading.Thread.Sleep(200);//设置暂停时间’
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);//设置暂停时间
            //释放技能
            int s_x = 675;
            int s_y = 709;
            SetCursorPos(s_x, s_y); //设置鼠标位置，x，y为账号框相对屏幕的位置       
            System.Threading.Thread.Sleep(200);
            //System.Threading.Thread.Sleep(200);//设置暂停时间’
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(200);
            //System.Threading.Thread.Sleep(100);//设置暂停时间
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PrintProcessName();

            if (System.Diagnostics.Process.GetProcessesByName("League of Legends").ToList().Count > 0)
            {
                //游戏开始
                Start_game();
            }

            else
            {
                //游戏结束启动重新开始模块

                //因为结束后会卡，暂停30秒再继续
               // System.Threading.Thread.Sleep(100);//30秒
               // ReStart();

               // i++;
               // this.Text = i + "";

            }

        }

        private void PrintProcessName()
        {
            Process cProcess = Process.GetCurrentProcess();
            this.Label1.Text = "当前进程名： " + cProcess.ProcessName;

            this.listView1.Items.Clear();
            if (System.Diagnostics.Process.GetProcessesByName("League of Legends").ToList().Count > 0)
            {
                foreach(var v in System.Diagnostics.Process.GetProcessesByName("League of Legends"))
                {
                    this.listView1.Items.Add("LOL 进程名： " + v.ProcessName + "," + v.MachineName + "," + v.Id);
                }
            }
        }
        
    }
}
