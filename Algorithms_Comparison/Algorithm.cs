using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Comparison
{
    internal class Algorithms
    {
        public void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int min = i, temp = arr[i];
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        // for Shell
        private void InsertionSort(int[] arr)
        {
            int k = 0, fix = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                fix = arr[i];
                k = i - 1;
                while (k > -1 && arr[k] > fix)
                {
                    arr[k + 1] = arr[k];
                    k--;
                }
                arr[k + 1] = fix;
            }
        }


        public void ShellSort(int[] arr)
        {
            int d = arr.Length / 2, count_elem = 0, elem = 0, max_index = 0;
            while (d > 0)
            {
                count_elem = arr.Length / d;
                max_index = count_elem * d;
                for (int i = 0; i < d; ++i)
                {
                    elem = count_elem;
                    if (max_index + i < arr.Length)
                        elem++;
                    int[] temp = new int[elem];
                    int y = 0;
                    for (int j = 0; j < elem; ++j)
                        temp[j] = arr[j * d + i];
                    InsertionSort(temp);
                    for (int j = 0; j < elem; j++)
                        arr[j * d + i] = temp[j];
                    if (d == 1)
                        break;
                }
                d /= 2;
            }
        }

        public void QuickSort(int[] arr, int start, int end)
        {
            int i = start, j = end, x = arr[(start + end) / 2];
            do
            {
                while (arr[i] < x)
                    ++i;
                while (arr[j] > x)
                    --j;
                if (i <= j)
                {
                    if (i < j)
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    ++i;
                    --j;
                }
            } while (i <= j);
            if (i < end)
                QuickSort(arr, i, end);
            if (start < j)
                QuickSort(arr, start, j);
        }

        // for Merge Sort
        private void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1, n2 = right - middle;
            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int c = 0; c < n1; ++c)
                leftArr[c] = arr[left + c];
            for (int g = 0; g < n2; ++g)
                rightArr[g] = arr[middle + 1 + g];

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    ++i;
                }
                else
                {
                    arr[k] = rightArr[j];
                    ++j;
                }
                ++k;
            }
            while (i < n1)
            {
                arr[k] = leftArr[i];
                ++i;
                ++k;
            }
            while (j < n2)
            {
                arr[k] = rightArr[j];
                ++j;
                ++k;
            }
        }

        public void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }

        public void CountingSort(int[] arr)
        {
            int min = arr[0], max = arr[0];
            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] < min)
                    min = arr[i];
                else if (arr[i] > max)
                    max = arr[i];
            }

            int[] temp = new int[max - min + 1];

            for (int i = 0; i < arr.Length; ++i)
                temp[arr[i] - min]++;

            for (int i = min, j = 0; i <= max; ++i)
            {
                while (temp[i - min]-- > 0)
                    arr[j++] = i;
            }
        }

        public void CreatArr(int[] arr, int count_num)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; ++i)
                arr[i] = rand.Next(2 * count_num) - count_num;
        }
        public void WriteToFile(int[] arr, string fName, bool w)
        {
            using (StreamWriter write = new StreamWriter(fName, w))
            {
                foreach (int num in arr)
                    write.Write(num + ", ");
                write.WriteLine();
            }
        }
        public void ReadFromFile(int[] arr, string fName)
        {
            using (StreamReader read = new StreamReader(fName))
            {
                string num;
                int i = 0;
                while ((num = read.ReadLine()) != null)
                    arr[i++] = int.Parse(num);
            }
        }
        public bool ifSorted(int[] arr)
        {
            bool rez = true;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                if (arr[i] > arr[i + 1])
                {
                    rez = false;
                    break;
                }
            }
            return rez;
        }

    }
}
