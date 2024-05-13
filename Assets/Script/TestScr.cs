using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TestScr : MonoBehaviour
{

    public int[] numbers;

    private void Start()
    {
        CheckNumbers();
        ZeroOutNumbers(10);
    }
    public void CheckNumbers()
    {
        int count = 1;
        int prevNumber = 0;

        foreach (int number in numbers)
        {
            if (number != 0)
            {
                if (number == prevNumber)
                {
                    count++;
                    if (count >= 10)
                    {
                        Debug.Log("Знайдено 10 і більше однакових ненульових чисел підряд!");
                        ZeroOutNumbers(number);
                        return;
                    }
                }
                else
                {
                    count = 1;
                }

                prevNumber = number;
            }
            else
            {
                count = 1;
            }
        }
    }
    // Обнулення чисел, які входять до послідовності
    private void ZeroOutNumbers(int number)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == number)
            {
                numbers[i] = 0;
            }
        }
    }
}