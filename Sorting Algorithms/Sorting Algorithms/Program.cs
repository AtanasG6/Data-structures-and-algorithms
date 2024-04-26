namespace Sorting_Algorithms
{
	public class Program
	{
		public static void Main()
		{
			var nums = new int[] { -4,-5,3,3,6};
			var sortedNums = new int[] { 1, 2, 3, 4, 5, 6 };
			//Console.WriteLine("Index of 4: " + BinarySearch(sortedNums, 4));
			//BubbleSort(nums);
			//InsertionSort(nums);
			//SelectionSort(nums);
			//ShellSort(nums);
			//MergeSort(nums);
			QuickSort(nums, 0, nums.Length - 1);
			Console.WriteLine(string.Join(", ", nums));
		}


		public static void BubbleSort(int[] arr)
		{
			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = 0; j < arr.Length - i - 1; j++)
				{
					if (arr[j] > arr[j+1])
					{
						int temp = arr[j];
						arr[j] = arr[j+1];
						arr[j+1] = temp;
					}
				}
			}
		}

		public static void InsertionSort(int[] arr)
		{
			for (int i = 1; i < arr.Length; i++)
			{
				int temp = arr[i];
				int j = i - 1;

				while (j>=0 && arr[j] > temp)
				{
					arr[j] = arr[j+1];
					j--;
				}

				arr[j + 1] = temp;
			}
		}

		public static int BinarySearch(int[] array, int target)
		{
			int low = 0;
			int high = array.Length - 1;

			while (low <= high)
			{
				int middle = (low + high) / 2;
				int value = array[middle];

				if (value < target)
				{
					low = middle + 1;
				}
				else if (value > target)
				{
					high = middle - 1;
				}
				else
				{
					return middle; //target found
				}
			}

			return -1; //target not found
		}

		public static void ShellSort(int[] arr)
		{
			int n = arr.Length;
			for (int gap = n / 2; gap >= 1; gap/=2)
			{
				for (int j = gap; j < n; j++)
				{
					for (int i = j - gap; i >= 0; i-=gap)
					{
						if (arr[i] < arr[i+gap])
						{
							break;
						}
						else
						{
							int temp = arr[i];
							arr[i] = arr[i+gap];
							arr[i+gap] = temp;
						}
					}
				}
			}
		}

		public static void SelectionSort(int[] arr)
		{
			for (int i = 0; i < arr.Length - 1; i++)
			{
				int min = i;
				for (int j = i+1; j < arr.Length; j++)
				{
					if (arr[j] < arr[min])
					{
						min = j;
					}
				}

				if (i != min)
				{
					int temp = arr[i];
					arr[i] = arr[min];
					arr[min] = temp;
				}
			}
		}

		public static void Merge(int[] left, int[] right, int[] array)
		{
			int nL = left.Length;
			int nR = right.Length;
			int i = 0, j = 0, k = 0;

			while (i < nL && j < nR)
			{
				if (left[i] <= right[j])
				{
					array[k] = left[i];
					i++;
					k++;
				}
				else
				{
					array[k] = right[j];
					j++;
					k++;
				}
			}

			while (i < nL)
			{
				array[k] = left[i];
				i++;
				k++;
			}

			while (j < nR)
			{
				array[k] = right[j];
				j++;
				k++;
			}
		}

		public static void MergeSort(int[] array)
		{
			int n = array.Length;

			if (n < 2) return;

			int middle = n / 2;

			int[] left = new int[middle];
			int[] right = new int[n - middle];

			for (int i = 0; i < middle; i++)
			{
				left[i] = array[i];
			}

			for (int i = middle; i < n; i++)
			{
				right[i - middle] = array[i];
			}

			MergeSort(left);
			MergeSort(right);
			Merge(left, right, array);
		}

		static void QuickSort(int[] array, int start, int end)
		{
			if (end <= start) return; // base case

			int pivot = Partition(array, start, end);
			QuickSort(array, start, pivot - 1);
			QuickSort(array, pivot + 1, end);
		}

		static int Partition(int[] array, int start, int end)
		{
			int pivot = array[end];
			int i = start - 1;

			for (int j = start; j <= end; j++)
			{
				if (array[j] < pivot)
				{
					i++;
					int temp = array[i];
					array[i] = array[j];
					array[j] = temp;
				}
			}

			i++;
			int temp2 = array[i];
			array[i] = array[end];
			array[end] = temp2;

			return i;
		}
	}
}

