   M S B A M L   `   `   `  ����A  =KVwWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:KVwWPF.ViewsKVwWPF.Views  5   	   !    KVwWPF.Views.RechnungWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:KVwWPF.Views     5   	     � Title$  Rechnung��5   	   $	��172��6   $	��503��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��163* �6   �� 5      $
��392* �6    � RowDefinitions 5   
   �� 5      $	��68* �6   �� 5      $	��71* �6   �� 5      $	��69* �6   �� 5      $	��69* �6   .+�5   
   �� $��Gesamtsumme��6   $	��100��6&   $��Center=�62   $��0,0,0,0q�6O   $��Center=�6`   �� 5   
   $��Mehrwertsteuer��6   $	��100��6)   $��Center=�65   $��0,0,0,0q�6R   $��1��6c   $��Center=�6p   �� 5   
   $��Datum��6   $	��100��6    $��Center=�6,   $��0,0,0,0q�6I   $��2��6Z   $��Center=�6g   �� 5   
   $��1��6   $��Center=�6"   $��0,0,0,0q�6?    �� TextWrapping$
 Wrap=�6P   $��Center=�6d   $	��120��6   ��6�   �� *RechnungSumme+�� 5   
   $��1��6   $��Center=�6"   $��0,0,0,0q�6?   $��1��6P   $
 Wrap=�6]   $��Center=�6q   $	��120��6�   ��6�   �� *MWSt+�� 5   
   $��1��6   $��Center=�6"   $��0,0,0,0q�6?   $��2��6P   $
 Wrap=�6]   $��Center=�6q   $	��120��6�   ��6�   �� *Datum+�� 5   
   $��Fertig��6   $	��120��6"   $��1��6.   $��Center=�6>   $��0,0,0,0q�6[   $��3��6l   $��Center=�6y   ��6�   �� *	FinishCmd+5      5      