   M S B A M L   `   `   `  ���� E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Calculator
Calculator      Calculator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Calculator     -     � Title$  
Calculator��$	��550��$	��350�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=� � Icon$ icon.png��.���  � ColumnDefinitions �� �� �� ��  � RowDefinitions �� �� �� �� �� �� �� .+��� -    ��Name$ btnOne��$��5��$��Center=�$��Center=�$��1��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnTwo��$��1��$��5��$��Center=�$��Center=�$��2��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnThree��$��2��$��5��$��Center=�$��Center=�$��3��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnFour��$��4��$��Center=�$��Center=�$��4��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnFive��$��1��$��4��$��Center=�$��Center=�$��5��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnSix��$��2��$��4��$��Center=�$��Center=�$��6��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnSeven��$��3��$��Center=�$��Center=�$��7��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -	   $ btnEight��$��1��$��3��$��Center=�$��Center=�$��8��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -
   $ btnNine��$��2��$��3��$��Center=�$��Center=�$��9��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnZero��$��1��$��6��$��Center=�$��Center=�$��0��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnPlusMinus��$��6��$��Center=�$��Center=�$	��+/-��$��25(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnDot��$��2��$��6��$��Center=�$��Center=�$��.��$��45(����	#FF1A283E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnEqual��$��4��$��6��$��Center=�$��Center=�$��=��$��45(����	#FFB87729
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnAddition��$��4��$��5��$��Center=�$��Center=�$��+��$��25(����	#FF141E2E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnSubstraction��$��4��$��4��$��Center=�$��Center=�$��-��$��25(����	#FF141E2E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnMultiplication��$��4��$��3��$��Center=�$��Center=�$��*��$��25(����	#FF141E2E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnDivision��$��4��$��2��$��Center=�$��Center=�$��/��$��25(����	#FF141E2E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnBackspace��$��2��$��2��$��Center=�$��Center=�$	��DEL��$��25(����	#FF141E2E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnClear��$��1��$��2��$��Center=�$��Center=�$��CE��$��25(����	#FF141E2E
�������$��Regular"�$��Bahnschrift Light)��� -   $ btnClearAll��$��2��$��Center=�$��Center=�$��C��$��25(����	#FF141E2E
�������$��Regular"�$��Bahnschrift Light)��� -    ��Name$ 	txbResult��$��5��$��2��$��Right=�$��Center=�$��0��$��70(����#28303B
�������$��Regular"�$��Bahnschrift Light)� �� 
IsReadOnly . $��0q��� -   $ txbPrevious��$��30��$��4��$��Right=�$��Center=�$��30,10,30,35q�$��20(����#28303B
�������$��0q� . 