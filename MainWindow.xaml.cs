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

namespace Pixel_Art
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tamaño = 18;
        Brush color = Brushes.Black;
        public MainWindow()
        {
            InitializeComponent();
            CrearGrid();
            
        }
        private void CrearGrid()
        {
            for (int i = 0; i < tamaño; i++)
            {
                espacioDibujo.RowDefinitions.Add(new RowDefinition());
                espacioDibujo.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int j = 0; j < tamaño; j++)
            {
                for (int k = 0; k < tamaño; k++)
                {
                    Border borde = new Border();
                    borde.BorderBrush = Brushes.Black;
                    borde.BorderThickness = new Thickness(1);

                    Grid.SetRow(borde, j);
                    Grid.SetColumn(borde, k);

                    espacioDibujo.Children.Add(borde);
                }
            }
        }


        private void NuevoGridButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("¿Seguro que quiere empezar de nuevo?", "Aviso");
            Button boton = (Button)sender;

            if (boton.Name == "buttonGrande")
            { 
                espacioDibujo.RowDefinitions.Clear();
                espacioDibujo.ColumnDefinitions.Clear();
                espacioDibujo.Children.Clear();
                tamaño = 24;
                CrearGrid();
            }
            else if (boton.Name == "buttonPequeño")
            {
                espacioDibujo.RowDefinitions.Clear();
                espacioDibujo.ColumnDefinitions.Clear();
                espacioDibujo.Children.Clear();
                tamaño = 10;
                CrearGrid();
            }
            else
            {
                espacioDibujo.RowDefinitions.Clear();
                espacioDibujo.ColumnDefinitions.Clear();
                espacioDibujo.Children.Clear();
                tamaño = 18;
                CrearGrid();
            }
        }

        private void Rellenar(object sender, RoutedEventArgs e)
        {
            foreach (Border celda in espacioDibujo.Children)
            {
                celda.Background = color;
            }  
        }
        private void Color_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton colorButton = (RadioButton)sender;
            if (colorButton.Tag.ToString() == "Blanco")
                color = Brushes.White;
            else if (colorButton.Tag.ToString() == "Personalizado")
                colorPersonalizadoTextBox.IsEnabled = true;
            else
                color = colorButton.Foreground;
        }        
    }
}
