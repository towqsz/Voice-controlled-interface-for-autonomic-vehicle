   M S B A M L   `   `   `  ����H  DCircularGauge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CircularGaugeCircularGauge  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089(    "CircularGauge.ImageOffsetConverter   imageOffsetConverter-   'CircularGauge.RadiusToDiameterConverter  radiusToDiameterConverter*   $CircularGauge.PointerCenterConverter  pointerCenterConverter8   2CircularGauge.RangeIndicatorLightPositionConverter ( $rangeIndicatorLightPositionConverter!   CircularGauge.SizeConverter  sizeConverter,   &CircularGauge.BackgroundColorConverter  backgroundColorConverter-   'CircularGauge.GlassEffectWidthConverter  glassEffectWidthConverter3   -CircularGauge.ColorToSolidColorBrushConverter # colorToSolidColorBrushConverter(   "CircularGauge.CircularGaugeControl  �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint � Color � Offset �� 
TargetType �Name	 �� RelativeSource
 �� Path �� 	Converter A�Name   DialBorderThickness   ImageSource �� ConverterParameter   DialText   DialTextFontSize F�Name   PointerLength   PointerThickness �� Stretch J� RenderTransformOrigin   PointerCapRadius J� Opacity   Radius�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      %localclr-namespace:CircularGauge  5      %  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     '  �     7  7  7  7  7  7  7  7   7  7  7  7  7  7  7     5      6!     5      6&     5      6#     5       61     5!      6     5"      6%     5#      6&     5$      6,   �� 5'      "   6   .�5(   
   ��  �@ ResetPointerOnStartUp . 62   �� 5)   
    �@ ScaleValuePrecision$ 5��60   �� 5*   
    � �� 5+      �� 5,      $ 0.5,1&�6&   $ 0.5,0&�67   .��5-      � $ 	#FFA3AFD6��6#   $ 0.321Q�65   � 5.      $ 	#FF8399A9��6#   $ 0.674Q�65   � 5/      $ 	#FF718597��6#   $ 0.375Q�65   � 50      $ 	#FF617584��6#   $ 1Q�65   51      53      �� 56   
    �@ BelowOptimalRangeColor$ Yellow��63   �� 57   
    �@ OptimalRangeColor$ Green��6.   �� 58   
    �@ AboveOptimalRangeColor$	 Red��63   �� 59   
    �@ DialTextColor$ White��6*   �� 5:   
    �@ DialTextFontSize$ 8��6-   �� 5;   
    �@ ScaleLabelFontSize$ 10Q�6/   �� 5=   
    � �� 5>      �� 5?      "  6"   .R�5A      � $ 
LayoutRoot��6   ��5B      �� 	 �� *TemplatedParent+$
 Radius�8   ��5C      �� 	 �� *TemplatedParent+$
 Radius�8  .+�5F      A� $ 
OuterFrame��6"   #��z 66   ��5G   "   �� 	 �� *TemplatedParent+$
 Radius�8  ��5H   "   �� 	 �� *TemplatedParent+$
 Radius�8  ��5I   "   �� 	 �� *TemplatedParent+$
 GaugeBackgroundColor�8  ��5K      �� 5L   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5M   &   � $ 	#FF636060��63   $ 1Q�6E   � 5N   &   $ 	#FF5F5C5C��63   $ 0Q�6E   � 5O   &   $ 	#FFEEDEDE��63   $
 0.35Q�6E   � 5P   &   $ 	#FFA09595��63   $ 0.705Q�6E   5Q   #   5S      �� 5W      #��z 6    ��5X       �� 	 �� *TemplatedParent+$
 	ImageSize�8  $ Width����5[       �� 	 �� *TemplatedParent+$
 	ImageSize�8  $ Height��z�5^       �� 	 �� *TemplatedParent+$
 ImageOffset�8  5a      �� 5d      #��z 6$   $��Center=�5e   $   $��Center=�6A   #��z 5h   $   $
��Bold"�5i   $   ��5f   $   �� 	 �� *TemplatedParent+$
 DialTextColor�8  z�5k      �� 	 �� *TemplatedParent+$
 DialTextOffset�8 	 5n      F� 5q      $ Pointer��6   ���	#FFE91C1C$��2��6C   #��z 5r      #��z 5s      $��Center=�6K   "����@B @B �@B ��� � _L	��[ 	$
 Fill=�5t   :   $ 0,0.5&�6J   z�5u      �� 	 �� *TemplatedParent+$
 PointerLength�8 
 ��5w      �� 5x   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5y   &   � $ 	#FF890A0A��63   $ 0.197Q�6E   � 5z   &   $ 	#FFC40808��63   $ 1Q�6E   � 5{   &   $ 	#FFE32323��63   $
 0.61Q�6E   5|   #   5      A� 5�      $ 
PointerCap��6"   #��z 66   #��z 6b   $��4��6�   $ 1Q�6�   ��5�      �� 5�   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5�   &   � $ 	#FF000000��63   $ 0.675Q�6E   � 5�   &   $ 	#FFC1B5B5��63   $ 0.031Q�6E   5�   #   ��5�      �� 5�   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5�   &   � $ 	#FF152029��63   $ 0.846Q�6E   � 5�   &   $ 	#FF140204��63   $ 0.342Q�6E   5�   #   5�      A� 5�      $ RangeIndicatorLight��6"   ��5�   #   �� 	 �� *TemplatedParent+$
 RangeIndicatorLightRadius�8  ��5�   #   �� 	 �� *TemplatedParent+$
 RangeIndicatorLightRadius�8  z�5�   !   �� 	 �� *TemplatedParent+$
 RangeIndicatorLightOffset�8  ��5�      �� 5�   "   $	 0,0&�66   $	 1,1&�6G   .��5�   &   � $ 	LightGray��63   $	 0.2Q�6E   � 5�   &   $
 Gray��63   $	 0.5Q�6@   � 5�   &   $ Black��63   $	 0.8Q�6A   5�   #   5�      F� 5�      $ GlassEffect��6   $��1��64   $
 Fill=�6H   $��Bottom=�6W   #��z 5�      $
 0.18Q�5�      ����������p@� 	�e���p@�4�(�}�p@��p�_F��p�ا ���r���@r�[	�0:ݢ@����Y<��Rv*F���f��P������������p@� 		��5�      �� 	 �� *TemplatedParent+$
 Radius�8  ��5�      �� 5�   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5�   &   � $ 	#68FCFCFC��63   � 5�   &   $ 	#FFF8FCF8��63   $ 1Q�6E   5�   #   5�      5�      5�      5�      5�      5�      