using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO.Ports;
using System.Threading;
using System.Windows.Threading;
using System.Security.Policy;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region 初始化代码段
            //定时器
            timer.Interval = new TimeSpan(100);
            timer.Tick += Timer_Tick;
            timer.Start();
            #endregion
        }

        #region 发送指令
        private bool SendCommond(string d)
        {
            if (serial.IsOpen)
            {
                serial.WriteLine(d+"\r\n");
                textRX.Text += d + "\r\n";
                return true;
            }
            return false;
        }
        #endregion

        #region 事件
        
        //定时器
        private void Timer_Tick(object sender, EventArgs e)
        {
            //更新串口接收窗口
            try
            {
                if (serial.IsOpen && serial.BytesToRead > 0)
                {
                    byte[] buffer_serial_read = new byte[serial.BytesToRead];
                    serial.Read(buffer_serial_read, 0, serial.BytesToRead);
                    textRX.Text += Encoding.UTF8.GetString( buffer_serial_read );
                    textRX.ScrollToEnd();
                }
            }
            catch
            {

            }

            //查询串口状态
            if(!serial.IsOpen) { buttonOpen.Content = "打开串口"; }
            else { buttonOpen.Content = "关闭串口"; }
        }

        //清空接收框信息
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textRX.Clear();
        }

        //打开串口
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!serial.IsOpen && buttonOpen.Content.ToString() == "打开串口")
                {
                    serial.BaudRate = Convert.ToInt32(textBaudRate.Text);
                    serial.Open();
                }
                else if(buttonOpen.Content.ToString()=="关闭串口")
                {
                    serial.Close();
                }
            }
            catch
            {
                MessageBox.Show("打开串口失败");
            }
        }

        //查询可用串口
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            ComNames.ItemsSource = SerialPort.GetPortNames();
        }

        //更改串口号
        private void ComNames_DropDownClosed(object sender, EventArgs e)
        {
            if (!serial.IsOpen && ComNames.Text!=string.Empty)
            {
                serial.PortName = ComNames.Text;
            }
        }

        //发生指令
        private void TextTX_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                if (textTX.Text != string.Empty)
                {
                    if (serial.IsOpen)
                    {
                        serial.WriteLine(textTX.Text + "\r\n");
                        textRX.Text += textTX.Text + "\r\n";
                        e.Handled = true;
                    }
                }
            }
            if(e.Key==Key.Q)
            {
                if (serial.IsOpen)
                {
                    serial.WriteLine("M410\r\n");
                    textRX.Text += "M410\r\n";
                    e.Handled = true;
                }
            }
        }

        //SD卡打印
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.WriteLine("M21\r\n");
                serial.WriteLine("M23 LEFA.TXT\r\n");
                serial.WriteLine("M24\r\n");
                textTX.Clear();
                e.Handled = true;
            }
        }
        #endregion

        #region 变量
        readonly SerialPort serial = new SerialPort();
        readonly DispatcherTimer timer = new DispatcherTimer();
        #endregion

        #region 参数设置 
        //查询参数
        //M503
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.WriteLine("M503\r\n");
                textTX.Clear();
                e.Handled = true;
            }
        }

        //修改参数
        //M92
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(textM92X.Text!=string.Empty && textM92Y.Text!=string.Empty)
            {
                if (serial.IsOpen)
                {
                    serial.WriteLine("M92 X" + textM92X.Text + " Y " + textM92Y.Text + "\r\n");
                    textTX.Clear();
                    e.Handled = true;
                }
            }
        }

        //保存参数
        //M500
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.WriteLine("M500\r\nM504\r\n");
                textTX.Clear();
                e.Handled = true;
            }
        }

        //恢复参数
        //M502
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.WriteLine("M502\r\n");
                textTX.Clear();
                e.Handled = true;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SendCommond("M112");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            SendCommond("G91");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            SendCommond("M119");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            SendCommond("M410");
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            SendCommond("G0 X" + textG0.Text);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            SendCommond("G0 Y" + textG0.Text);
        }
        #endregion

        //设置为绝对坐标

    }
}
