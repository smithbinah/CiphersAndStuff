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
using CodesAndCiphers.Ciphers;

namespace CodesAndCiphers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cipher ciphers;

        public MainWindow()
        {
            InitializeComponent();
            ciphers = new Cipher();
            setContext();
        }

        public void setContext()
        {
            InputText.DataContext = ciphers;
            AnswerBox.DataContext = ciphers;
            Groupings.DataContext = ciphers;
        }

        private void InputText_TextInput(object sender, TextCompositionEventArgs e)
        {
            ciphers.EncryptedInput = InputText.Text;
        }

        private void IncreaseRowButton_Click(object sender, RoutedEventArgs e)
        {
            ciphers.IndexMax++;
            ciphers.EncryptedInput += "";
            
            
        }

        private void DecreaseRowButton_Click(object sender, RoutedEventArgs e)
        {
            ciphers.IndexMax--;
            ciphers.EncryptedInput += "";
            
        }
    }
}
