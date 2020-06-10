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

            //串口
            serial.DataReceived += Serial_DataReceived;
            #endregion
        }

        #region 事件
        //串口接收到数据
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rxBuff += serial.ReadExisting();
        }
        
        //定时器
        private void Timer_Tick(object sender, EventArgs e)
        {
            //更新串口接收窗口
            textRX.Text = rxBuff;
            textRX.ScrollToEnd();

            //查询串口状态
            if(!serial.IsOpen) { buttonOpen.Content = "打开串口"; }
            else { buttonOpen.Content = "关闭串口"; }
        }

        //清空接收框信息
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rxBuff = string.Empty;
        }

        //打开串口
        private void buttonOpen_Click(object sender, RoutedEventArgs e)
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
        private void textTX_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                if (textTX.Text != string.Empty)
                {
                    if (serial.IsOpen)
                    {
                        serial.WriteLine(textTX.Text + "\r\n");
                        textTX.Clear();
                        e.Handled = true;
                    }
                }
            }
        }
        #endregion

        #region 变量
        SerialPort serial = new SerialPort();
        DispatcherTimer timer = new DispatcherTimer();
        string rxBuff;
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
        #endregion
    }
}
