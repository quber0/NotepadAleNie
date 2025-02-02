using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace notepadAleNie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FileName { get; set; } = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (Title.Contains('*'))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text file (*.txt) | *.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    //zapis do pliku
                    FileName = saveFileDialog.FileName;
                    File.WriteAllText(saveFileDialog.FileName, FileText.Text);
                }
            }
            else File.WriteAllText(FileName, FileText.Text);
            Title = FileName;
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            saveFileQuestion(sender, e);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt) | *.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                //zapis do pliku
                FileName = openFileDialog.FileName;
                FileText.Text = File.ReadAllText(openFileDialog.FileName);
                Title = FileName;
            }
        }


        private void NewFile(object sender, RoutedEventArgs e)
        {
            saveFileQuestion(sender, e);
            FileName = "Unnamed";
            FileText.Text = "";
            Title = FileName;
        }
        private void saveFileQuestion(object sender, RoutedEventArgs e)
        {
            if (Title.Contains('*'))
            {
                MessageBoxResult result = MessageBox.Show("Czy chcesz wcześniej zapisać?", "Beka z cb",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes) SaveFile(sender, e);
                else if (result == MessageBoxResult.Cancel) return;
            }
        }

        private void TitleUpdate(object sender, TextChangedEventArgs e)
        {
            if (Title.Length == 0) Title = "*Unnamed";
            if (!Title.Contains('*')) Title = "*" + Title;
        }

        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            saveFileQuestion(sender, e);
            Close();
        }

        private void RedText_Btn(object sender, RoutedEventArgs e)
        {
            FileText.Foreground = Brushes.Red;
        }
        private void AboutApplication_Btn(object sender, RoutedEventArgs e)
        {
            AboutApplication aboutApplication = new();
            aboutApplication.Show();//Można działać w tle
        }

        private void AboutAuthor_Btn(object sender, RoutedEventArgs e)
        {
            AboutAuthor aboutAuthor = new();
            aboutAuthor.Show(); //nie można działać w tle
        }
        private void DarkMode_BG(object sender, RoutedEventArgs e)
        {
            if (FileText != null)
            {
                FileText.Foreground = Brushes.White;
                FileText.Background = Brushes.Black;
            }
        }
        private void LightMode_BG(object sender, RoutedEventArgs e)
        {
            if (FileText != null)
            {
                FileText.Foreground = Brushes.Black;
                FileText.Background = Brushes.White;
            }
        }

        private void BlackText_Btn(object sender, RoutedEventArgs e)
        {
            FileText.Foreground = Brushes.Black;
        }

        private void WhiteText_Btn(object sender, RoutedEventArgs e)
        {
            FileText.Foreground = Brushes.White;
        }

        private void CustomColorText_Button(object sender, RoutedEventArgs e)
        {
            CustomColor customColor = new();
            customColor.ShowDialog();
            byte r = customColor.R;
            byte g = customColor.G;
            byte b = customColor.B;

            Color color = Color.FromRgb(r, g, b);
            FileText.Background = new SolidColorBrush(color);
        }

        private void LimeText_Btn(object sender, RoutedEventArgs e)
        {
            Color lime = new();
            lime = Color.FromRgb(127, 255, 0);
            FileText.Foreground = new SolidColorBrush(lime);
        }

        private void FormatText_Btn(object sender, RoutedEventArgs e)
        {
            FormatText formatText = new();
            formatText.ShowDialog();
            FileText.FontSize = formatText.size;
            FileText.FontStyle = formatText.Style;
            FileText.FontWeight = formatText.Weight;
        }

        private void WordWrapOn(object sender, RoutedEventArgs e)
        {
            if (FileText != null) FileText.TextWrapping = TextWrapping.Wrap; 
        }

        private void WordWrapOff(object sender, RoutedEventArgs e)
        {
            if (FileText != null) FileText.TextWrapping = TextWrapping.NoWrap;
        }
    }
}
