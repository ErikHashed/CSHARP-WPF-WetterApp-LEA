   M S B A M L   `   `   `  ���� D  @WetterApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WetterApp	WetterApp      WetterApp.data   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:WetterApp       � Title$  daten��$	��750��$	��427�� � Topmost .  � 
ResizeMode$ NoResize=� � Icon$+ %/ced73fd957c14de6b1bd1807e36a7439.png�� � 	Resources    SunSliderStyle �� 
TargetType �� Property �� Value �� 
TargetType	 � Points  SliderThumbStyle   WetterApp.WeatherForecast  ValueToMarginConverter��%�   &	        &	 �     &	 �     �� " ��.���  � �� �� " ��.R�� .+��� ���#87CEFA$��50��.+�� ���#FFD700	 �   ������ ������� " n�.���  � y�$ 	Collapsed=�  .��� $��
0,0,0,-487q�$
��1488������ 
 �� EndPoint$
 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF2EE1FF�� � Offset$ 0.561Q�� $ White��$ 1Q�.+��� -    ��Name$ weatherImage��$��145,30,145,1338q�$	��120��$	��120���� -    ��Name$ txtErgebnis��$
��Left=�$��
38,112,0,0q�$	��Top=�$��76��$	��194���� -   $ txtTemp��$��208,115,0,0q�$��26(�$
��Left=�$	��256��$	��Top=�$
��Bold"��� -   $ 	txtMinMax��$��43,503,384,-114q�$��16(��� -    ��Name$ weatherforecastList��$��1q�$��0,218,0,912q�$��Center=�$	��336��$��20(����	#FF2EE1FF���� $
 0.5,1&�$ 0.5,0&�.��� $ 	#FF2EE1FF��$ 0.548Q�� $ White��$ 1Q����� .R���  �� Orientation$ 
Horizontal=�.+��� $��0 0 10 0q����� *Temperature+�� $��60��$��60��$��10 0 0 0q����� *
IconPath+�� $��7-Tage-Vorhersage��$
��Left=�
������ $��0q�$��
28,193,0,0q�$	��Top=�$	��128��$��25��$��14(��� -    ��Name$ 	nameLabel��$�� ��$��Center=�$��0,5,0,0q�$	��Top=�$	��120��$��58��$��24(��� -    ��Name$ Close��$��X��$��16(�$
��Bold"�
�������
���  ��
������ $��336,14,37,1440q����� " ��.R���  �� CornerRadius$ 15��#��z��#��z��$��1q�._��� $��Center=�$��Center=��� -   $ Sunrise��$
��Left=�$��
43,581,0,0q�$	��Top=�$��47��$��98��$��18(��� -	    ��Name$ sunIcon��$��140,568,151,800q�$
��Auto��$
��Auto���� -
   $ Sunset��$
��Left=�$��282,581,0,0q�$	��Top=�$��47��$	��108��$��18(�