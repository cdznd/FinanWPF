   M S B A M L   `   `   `  ����C  ?FinanWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:FinanWPF.Views.Crud.ReadViewFinanWPF.Views.Crud.ReadView  5   	   1    +FinanWPF.Views.Crud.ReadView.view_Categoria   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:FinanWPF.Views.Crud.ReadView     5   	     � Title$  
Categorias��5   	   $	��581��6   $
��1095��6)   .��5	      � .+�5   
   �� -   5         ��Name$ title_TitleCategoriaView��5      $
��Left=�5      $��	10,10,0,0q�5      $��
Categorias��5      $��20(�5      $
��Bold"�5      $	��Top=�5      $��39��5      $	��173��5      �� 5   
   -   5        $! title_TitleAllCategoriaView��5      $
��Left=�5      $��
625,10,0,0q�5      $��Todas categorias:��5      $��15(�5      $
��Bold"�5      $	��Top=�5      $��28��5      $	��173��5      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ dataGrid_Categoria��5"      $��624,49,17,67q�5#         AutoGenerateColumns$ False��5%      ��5$      �� *SourceCollection+   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Categoria��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5*   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5+   %   �� *Nome+  5-      $
 Data��6%   $ 1* 5.   %    5/   %   �� *Data+53      �� 56   
   -   5        $  title_LancamentosCategoria��56      $!��Lançamentos por categoria:��57      $
��Left=�58      $��
10,185,0,0q�59      $
��bold"�5:      $	��Top=�5;      $	��169��5<      $��25��5=        5@   
   -   5        $ dataGrid_Categoria2��5@      $��10,219,487,103q�5A      $ False��5C      ��5B      �� *SourceCollection+ 5E        5G      $ 	Categoria��6%   $ 1* 5H   %    5I   %   �� *Nome+  5K      $ Conta��6%   $ 1* 5L   %    5M   %   �� *Conta+  5O      $ Valor��6%   $ 1* 5P   %    5Q   %   �� *Valor+  5S      $
 Data��6%   $ 1* 5T   %    5U   %   �� *Data+5Y      �� 5\   
   -   5         ��Name$ btn_voltarCategoria��5\      $��Voltar��5]      $
��Left=�5^      $��478,467,0,0q�5_      $	��Top=�5`      $��35��5a      $	��130��5b      6   �� 5e   
   -   5        $ btn_MostrarCategoria��5e      $��	Pesquisar��5f      $
��Left=�5g      $��
520,90,0,0q�5h      $	��Top=�5i      $��30��5j      $��88��5k      6   �� 5n   
   -   5        $ btn_deletarCategoria��5n      $��Excluir categoria��5o      $
��Left=�5p      $��241,477,0,0q�5q      $	��Top=�5r      $��25��5s      $	��110��5t      5u      �� 5x   
   -	   5        $ btn_editarCategoria��5x      $��Editar categoria��5y      $
��Left=�5z      $��136,477,0,0q�5{      $	��Top=�5|      $��25��5}      $	��100��5~      	 J� RenderTransformOrigin$	 0.491,1.324&�5   3   �� 5�   
   -
   5        $ btn_CadastrarCategoria��5�      $��Cadastrar categoria��5�      $
��Left=�5�      $��
10,477,0,0q�5�      $	��Top=�5�      $��25��5�      $	��121��5�      5�      �� 5�   
   -   5        
 ��Name$
 drop_FindCategoria��5�      $
��Left=�5�      $��
242,49,0,0q�5�      $	��Top=�5�      $	��366��5�      $��35��6   �� 5�   
   -   5        $ text_TitleCategoria��5�      $��
Categoria:��5�      $
��Left=�5�      $��	10,49,0,0q�5�      $��15(�5�      $
��bold"�5�      $	��Top=�5�      $��86��5�      $��35��5�      �� 5�   
   -   5        $ 	Categoria��5�      $�� ��5�      $
��Left=�5�      $��	96,49,0,0q�5�      $��15(�5�      $	��Top=�5�      $	��136��5�      $��35��5�      �� 5�   
   -   5        $ text_NumeroLancamentos��5�      $��Numero de lancamentos:��5�      $
��Left=�5�      $��	10,89,0,0q�5�      $	��Top=�5�      $
��bold"�5�      $	��157��5�      $��26��5�      �� 5�   
   -   5        $ Lancamentos��5�      $�� ��5�      $
��Left=�5�      $��
164,90,0,0q�5�      $	��Top=�5�      $	��351��5�      $��25��5�      �� 5�   
   -   5        $ text_DataCriacao��5�      $��Data de criacao��5�      $
��Left=�5�      $��
10,120,0,0q�5�      $
��bold"�5�      $	��Top=�5�      $	��100��5�      $��25��5�      �� 5�   
   -   5        $ DataCriacao��5�      $�� ��5�      $
��Left=�5�      $��110,120,0,0q�5�      $	��Top=�5�      $	��405��5�      $��30��5�      5�      5�      