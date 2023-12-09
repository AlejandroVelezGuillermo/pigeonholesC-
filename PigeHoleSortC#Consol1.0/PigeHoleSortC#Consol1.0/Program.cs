using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese números separados por comas:");
        string input = Console.ReadLine();

        // Obtener los valores de entrada del usuario
        string[] inputValues = input.Split(',');
        int[] numbers = new int[inputValues.Length];

        for (int i = 0; i < inputValues.Length; i++)
        {
            if (int.TryParse(inputValues[i], out int num))
            {
                numbers[i] = num;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese enteros separados por comas.");
                return;
            }
        }

        // Realizar el ordenamiento por Pigeonhole Sort
        PigeonholeSort(numbers);

        // Mostrar el arreglo ordenado en la consola
        Console.WriteLine("Arreglo ordenado: " + string.Join(", ", numbers));
    }

    // Algoritmo Pigeonhole Sort
    static void PigeonholeSort(int[] arr)
    {
        int min = arr[0], max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
                min = arr[i];
            if (arr[i] > max)
                max = arr[i];
        }

        int range = max - min + 1;
        int[] pigeonholes = new int[range];

        for (int i = 0; i < range; i++)
        {
            pigeonholes[i] = 0;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            pigeonholes[arr[i] - min]++;
        }

        int index = 0;
        for (int i = 0; i < range; i++)
        {
            while (pigeonholes[i]-- > 0)
            {
                arr[index++] = i + min;
                // Mostrar el estado actual del arreglo en cada paso
                Console.WriteLine("Paso " + (index) + ": " + string.Join(", ", arr));
            }
        }
    }
}

