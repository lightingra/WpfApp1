   M S B A M L   `   `   `  ���� K  GNOVA调参助手, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1       � Title$  NOVA调参助手��$	��450��$��834.704��.��� .+��� $
��Left=�$	��399��$��	10,10,0,0q�$	��Top=�$	��139��
���   �.+��� -   $��ComNames�� �� Left$ 10��
 �� Top$ 10��$	��120���� -   $��textBaudRate��$��23��$ 10�� �� TextWrapping$
 Wrap=�$��250000��$ 36��$	��120���� -   $��
buttonOpen��$��打开串口��$ 10��$ 64��$	��120���� -   $��清空接收区��$ 10��$ 88��$	��119���� $
��Left=�$	��399��$��
154,10,0,0q�$	��Top=�$	��478��.+��� -   $��textRX��$	��351��$ 10��$
 Wrap=�$ 10��$	��458��
���   ����	#FF8B7777���	#FF00FD45 �� 
IsReadOnly . " �� VerticalScrollBarVisibility$ Visible=��� -   $��textTX��$��23��$ 10��$
 Wrap=�$	 366��$	��458��
���   ����	#FF00FF17 �� IsInputMethodEnabled .   �� CharacterCasing$ Upper=��� $��回车发送��$	 400��$	 366��
���  ���� $
��Left=�$	��399��$��
637,10,0,0q�$	��Top=�$	��180��.+��� -   $��textM92X��$��23��$ 10��$
 Wrap=�$��80.00��$ 10��$	��120���� -   $��textM92Y��$��23��$ 10��$
 Wrap=�$��80.00��$ 38��$	��120���� $��	脉冲/mm��$ 61��$ 10�� J� RenderTransformOrigin$ 0.048,0.526&��� $��	脉冲/mm��$ 61��$ 40��$ 0.048,0.526&��� -	   $��查询参数��$ 10��$ 70��$	��120���� -
   $��修改参数��$ 10��$ 94��$	��120���� -   $��保存参数��$ 10��$	 118��$	��120���� -   $��恢复设置��$ 10��$	 142��$	��120���� $
��X轴��$	 135��$ 10���� $
��Y轴��$	 135��$ 44��