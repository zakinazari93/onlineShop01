   M S B A M L   `   `   `  ����A  =KVwWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:KVwWPF.ViewsKVwWPF.Views  5   	        KVwWPF.Views.MaAdminWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:KVwWPF.Views     5   	     � Title$  MaAdminWindow��5   	   $	��411��6   $	��511��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��49* �6   �� 5      $
��346* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $
��145* �6#   �� 5      $
��202* �6#   �� 5      $
��164* �6#    5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��Kunde��6   $
��Left=�6$   $��75,0,0,0q�6?   $��Center=�6Q   $��26��6l   $��70��6x   $��1,1,1,1q�6�   �� 5      $��Produkt��6   $
��Left=�6&   $��75,0,0,0q�6A   $��1��6S   $��Center=�6`   $��26��6{   $��70��6�   $��1,1,1,1q�6�   �� 5      $��Rechnung��6   $
��Left=�6'   $��2��6B   $��Center=�6O   $��26��6j   $��70��6v   $��1,1,1,1q�6�   $��75,0,0,0q�6�   �� 5      $��Mitarbeiter��6   $
��Left=�6*   $��3��6E   $��Center=�6R   $��26��6m   $��70��6y   $��1,1,1,1q�6�   $��75,0,0,0q�6�   �� 5       $��Regal��6   $
��Left=�6$   $��75,0,0,0q�6?   $��4��6Q   $��Center=�6^   $��26��6y   $��70��6�   $��1,1,1,1q�6�   �� 5!      $��	Kategorie��6   $
��Left=�6(   $��75,0,0,0q�6C   $��5��6U   $��Center=�6b   $��26��6}   $��70��6�   $��1,1,1,1q�6�   �� 5"      $��1��6   $
��Left=�6'   $��Center=�6B   $	��150��6]   $��22��6i    �� SelectedValuePath$ KundePK��6�    �� DisplayMemberPath$ KundeNachname ��6�   ��6u   �� *KundeTabelle+ �� SelectedValue 6�   �� *
KundeKey+6�   �� 5#      $��1��6   $
��Left=�6'   $��1��6B   $��Center=�6O   $	��150��6j   $��22��6v   $ 	ProduktPK��6�   $ ProduktName��6�   ��6�   �� *ProduktTabelle+ 6�   �� *
ProduktKey+6�   �� 5$      $��1��6   $
��Left=�6'   $��2��6B   $��Center=�6O   $	��150��6j   $��22��6v   $ 
RechnungPK��6�   $ RechNr��6�   ��6�   �� *RechnungTabelle+ 6�   �� *RechnungKey+6�   �� 5%      $��1��6   $
��Left=�6'   $��3��6B   $��Center=�6O   $	��150��6j   $��22��6v   $
 MaPK��6�   $ 
MaNachname��6�   ��6�   �� *MitarbeiterTabelle+ 6�   �� *MitarbeiterKey+6�   �� 5&      $��1��6   $
��Left=�6'   $��4��6B   $��Center=�6O   $	��150��6j   $��22��6w   $ RegalPK��6�   $ RegalOrt��6�   ��6�   �� *RegalTabelle+ 6�   �� *
RegalKey+6�   �� 5'      $��1��6   $
��Left=�6'   $��5��6B   $��Center=�6O   $	��150��6j   $��22��6v   $ KategoriePK��6�   $ KategorieName��6�   ��6�   �� *KategorieTabelle+ 6�   �� *KategorieKey+6�   �� 5(      $��Bearbeite Kunde��6   $��2��6/   $��Center=�6?   $��0,0,0,0q�6\   $��Center=�6m   $	��130��6�   ��6�   �� *
EditKunCmd+�� 5)      $��Bearbeite Produkt��6   $��2��61   $��Center=�6A   $��0,0,0,0q�6^   $��1��6o   $��Center=�6|   $	��130��6�   ��6�   �� *EditProdCmd+�� 5*      $��Bearbeite Rechnung��6   $��2��62   $��Center=�6B   $��0,0,0,0q�6_   $��2��6p   $��Center=�6}   $	��130��6�   ��6�   �� *EditRechCmd+�� 5+      $��Bearbeite Mitarbeiter��6   $��2��65   $��Center=�6E   $��0,0,0,0q�6b   $��3��6s   $��Center=�6�   $	��130��6�   ��6�   �� *	EditMaCmd+�� 5,      $��Bearbeite Regal��6   $��2��6/   $��Center=�6?   $��0,0,0,0q�6\   $��4��6m   $��Center=�6z   $	��130��6�   ��6�   �� *EditRegalCmd+�� 5-      $��Bearbeite Kategorie��6   $��2��63   $��Center=�6C   $��0,0,0,0q�6`   $��5��6q   $��Center=�6~   $	��130��6�   ��6�   �� *
EditKatCmd+5/      �� 50   
   $(��"Hauptfenster für Mitarbeiterinnen��6   $��Center=�6<   $��0,0,0,0q�6Y   $��Center=�6j   $��1,1,1,1q�6�   $��14(�6�   $
��Bold"�6�   52      53      