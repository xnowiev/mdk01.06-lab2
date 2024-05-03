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

namespace zinovievLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a, b, c, d;
            if (int.TryParse(textBoxA.Text, out a) && int.TryParse(textBoxB.Text, out b) && int.TryParse(textBoxC.Text, out c) && int.TryParse(textBoxD.Text, out d))
            {
                List<string> results = CalculateCutting(a, b, c, d);
                listBoxResults.ItemsSource = results;
            }
            else
            {
                MessageBox.Show("Введенное сообщение говно");
            }
        }

        private List<string> CalculateCutting(int a, int b, int c, int d)
        {
            List<string> results = new List<string>();

            // Оптимизация по горизонтали
            int horizontalCuts = a / c;
            int remainingWidth = a % c;
            int verticalCuts = b / d;
            int remainingHeight = b % d;

            int maxCuts = horizontalCuts * verticalCuts;
            results.Add($"Горизонтальные разрезы: {horizontalCuts}, Вертикальные разрезы: {verticalCuts}, Всего разрезов: {maxCuts}");

            // Оптимизация по вертикали
            horizontalCuts = b / c;
            remainingWidth = b % c;
            verticalCuts = a / d;
            remainingHeight = a % d;

            maxCuts = horizontalCuts * verticalCuts;
            results.Add($"Горизонтальные разрезы: {horizontalCuts}, Вертикальные разрезы: {verticalCuts}, Всего разрезов: {maxCuts}");

            // Если остались обрезки, пытаемся использовать их
            if (remainingWidth >= c && remainingHeight >= d)
            {
                int additionalCuts = remainingWidth / c * remainingHeight / d;
                maxCuts += additionalCuts;
                results.Add($"Дополнительный разрез: {additionalCuts}, Всего разрезов: {maxCuts}");
            }

            return results;
        }
    }
}
