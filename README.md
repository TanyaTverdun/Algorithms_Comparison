# Algorithm Comparison (Desktop Application in WPF)

Algorithm Comparison is a desktop application developed using WPF and C# for analyzing and visualizing the performance of various sorting algorithms. Users can select array sizes, run sorting algorithms, measure execution time, and compare results through a dynamic bar chart. All results are saved to text files for further analysis.

## How to Run

1. Clone the repository to your local machine:
   ```bash
   https://github.com/TanyaTverdun/Algorithms_Comparison.git
   ```
2. Open the solution file (`Algorithms_Comparison.sln`) in **Visual Studio**.
3. Install the **LiveCharts.Wpf** package via NuGet:
   ```bash
   Install-Package LiveCharts.Wpf
   ```
4. Build and run the project.
5. Select an array size, click Start, and view the results in the text fields, chart, and output file.

## Key Features

- **Supported Algorithms**  
  Includes implementations of Selection Sort, Shell Sort, Quick Sort, Merge Sort, and Counting Sort.

- **Array Size Selection**  
  Users can choose the array size (e.g., 512, 1024, etc.) from a dropdown menu.

- **Performance Measurement**  
  Execution time of each algorithm is measured and displayed in milliseconds.

- **Visualization**  
  Utilizes the LiveCharts library to display a bar chart comparing algorithm execution times.

- **Result Saving**  
  Sorted arrays and performance metrics are saved to text files (e.g., `file_1024.txt`).

## Technologies Used

- **C#** and **WPF** (.NET)
- **XAML** for UI design
- **LiveCharts.Wpf** for charting
- Object-oriented programming (encapsulation, modularity)
- File operations (read/write)
- Exception handling
- Implementation of sorting algorithms

## Project Structure

- `MainWindow.xaml` — the main application window containing the user interface (dropdown menu, start button, text fields, chart).
- `MainWindow.xaml.cs` — handles user interaction logic, algorithm execution, chart updates, and file operations.
- `Algorithms.cs` — contains sorting algorithm implementations and utility methods for array generation, file I/O, and result validation.

## Screenshot

### Main Window

![Main Window](img_readme/main_window.png)

## Author

**Tetyana Tverdun**  
Student of Software Engineering, Group PZ-22 
Lviv Polytechnic National University

## Notes

- The application uses a temporary file (`temp`) to store the original array, ensuring that all algorithms process the same input.
- Execution time may vary depending on system performance and array size.
