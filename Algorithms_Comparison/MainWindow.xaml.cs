using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;

namespace Algorithms_Comparison
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Властивість для значень стовпців
        public ChartValues<double> ColumnValues { get; set; }
        // Властивість для міток осі X
        public List<string> Labels { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Labels = new List<string> { "Selection", "Shell", "Quick", "Merge", "Counting" };
            ColumnValues = new ChartValues<double> { 1, 1, 1, 1, 1 };
            DataContext = this;
            StartButton.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
        }
        // Властивість для міток Y
        public Func<double, string> FormatToHundredths => value => Math.Round(value, 3).ToString("F3");
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            columnChart.Update(true, true);
            ColumnValues.Clear();

            // Очистка всіх текстбоксів
            ClearAllTextBoxes();

            Algorithms my_algorithm = new Algorithms();
            string fTemp = "temp";
            string fName;

            try
            {
                string selectedValue = (ChooseSize.SelectedItem as ComboBoxItem)?.Content.ToString();
                int selectedNumber = int.Parse(selectedValue);

                fName = $"file_{selectedNumber}.txt";
                int[] baseArray = new int[selectedNumber];
                my_algorithm.CreatArr(baseArray, selectedNumber);

                File.WriteAllLines(fTemp, baseArray.Select(n => n.ToString()));

                // Підготовка масивів
                int[] arr_Selection = FileToArray(my_algorithm, fTemp, selectedNumber);
                int[] arr_Shell = FileToArray(my_algorithm, fTemp, selectedNumber);
                int[] arr_Quick = FileToArray(my_algorithm, fTemp, selectedNumber);
                int[] arr_Merge = FileToArray(my_algorithm, fTemp, selectedNumber);
                int[] arr_Counting = FileToArray(my_algorithm, fTemp, selectedNumber);

                // Запуск алгоритмів
                RunAndLogSort("Selection sort", arr_Selection, my_algorithm.SelectionSort, my_algorithm, Selection_text, fName);
                RunAndLogSort("Shell sort", arr_Shell, my_algorithm.ShellSort, my_algorithm, Shell_text, fName);
                RunAndLogSort("Quick sort", arr_Quick, arr => my_algorithm.QuickSort(arr, 0, arr.Length - 1), my_algorithm, Quick_text, fName);
                RunAndLogSort("Merge sort", arr_Merge, arr => my_algorithm.MergeSort(arr, 0, arr.Length - 1), my_algorithm, Merge_text, fName);
                RunAndLogSort("Counting sort", arr_Counting, my_algorithm.CountingSort, my_algorithm, Counting_text, fName);
            }
            catch (Exception)
            {
                MessageBox.Show("Виберіть значення!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RunAndLogSort(string name, int[] arr, Action<int[]> sortMethod, Algorithms alg, TextBox output, string fileName)
        {
            output.Text += $"> {name} --\n\n";

            var time = new System.Diagnostics.Stopwatch();
            time.Start();
            sortMethod(arr);
            time.Stop();

            long ticks = time.ElapsedTicks;
            double ms = Math.Round((double)ticks / System.Diagnostics.Stopwatch.Frequency * 1000, 3);

            bool sorted = alg.ifSorted(arr);
            output.Text += sorted ? "Array is sorted\n" : "Array is not sorted\n";
            output.Text += $"Time is: {ms} ms\n\n";

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"> {name}");
            }
            alg.WriteToFile(arr, fileName, true);
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"| Time is: {ms} ms");
            }

            ColumnValues.Add(ms);
        }

        private void ClearAllTextBoxes()
        {
            TextBox[] boxes = { Shell_text, Quick_text, Counting_text, Selection_text, Merge_text };
            foreach (var box in boxes)
            {
                box.Clear();
                box.ScrollToEnd();
            }
        }

        private int[] FileToArray(Algorithms alg, string file, int size)
        {
            int[] arr = new int[size];
            alg.ReadFromFile(arr, file);
            return arr;
        }

    }
}