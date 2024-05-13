using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VoxelScr : MonoBehaviour
{
    public GameScr Games;
    public int[] Mony;
    public bool IsTrue;
    public VoxelScr[] Coll;
    public int Priority; // Змінено тип на int для пріоритету передачі чисел
    public GameObject[] MonyObj;
    public Renderer[] RenderMony;
    public Color[] Coloring;
    public bool[] IsBool;
    float TimerDestroi=0.125f;
    public float lastChange = 0;
    bool IsTrues = true;
    float TimerDestoy = 1f;
    int fors = 0;
    bool foundMatch = false; // Прапорець для виявлення збігів
    bool transferCompleted = false;
    void TransferElements(int[] sourceList, int[] destinationList)
    {
        int x = sourceList.Count(x => x != 0);
        int y = destinationList.Count(x => x != 0);
        if (IsTrues == true)
        {
            int a = 1;
            for (int i = x - 1; i >= 0; i--)
            {
                if (sourceList[i] == 0)
                {
                    continue; // Пропускаємо нульові значення
                }

                for (int j = y - 1; j >= 0; j--)
                {
                    if (destinationList[j] == 0 || sourceList[i] == 0)
                    {
                        continue; // Пропускаємо нульові значення
                    }
                    else
                    {
                        if (TimerDestroi<0)
                        {

                            if (sourceList[i] == destinationList[j])
                            {
                                destinationList[j + a] = sourceList[i];
                                sourceList[i] = 0;
                                a++;
                                TimerDestroi = 0.125f;
                                lastChange = 0;
                                continue;
                            }
                            else
                            {
                                a = 0;
                                foundMatch = true; // Встановлюємо прапорець, що знайдено збіг
                                break; // Виходимо з циклу, якщо знайдено збіг
                            }
                        }
                    }

                }

                if (foundMatch) // Якщо знайдено співпадіння, перериваємо зовнішній цикл
                {
                    break;
                }
            }
        }
        transferCompleted = true;
    }

    void Update()
    {
        while (fors < Mony.Length)
        {
            if (Mony[fors] != 0)
            {
                IsBool[fors] = true;
            }
            else
            {
                IsBool[fors] = false;
            }
            MonyObj[fors].SetActive(IsBool[fors]);
            fors++;
        }


        fors = 0;
        TimerDestoy -= Time.deltaTime;
        Debug.Log(TimerDestoy);
        // Оновлення кольорів
        UpdateColors();

        lastChange += Time.deltaTime;
        for (int a = 0; a < Coll.Length; a++)
        {
            if (Coll[a].Priority < Priority)
            {
                TransferElements(Mony, Coll[a].Mony);
            }
            else if (Coll[a].Priority == Priority)
            {
                if (Coll[a].lastChange < lastChange)
                {
                    Coll[a].Priority++;
                    print("Вони однакові");
                }
            }
            TimerDestroi -= Time.deltaTime;
        }


        // Перевірка, чи завершено перенесення елементів
        if (transferCompleted)
        {
            CheckNumbers();
            ZeroOutNumbers(10);// Виклик методу CheckNumbers() після завершення перенесення елементів
            transferCompleted = false; // Скидання прапорця після виклику методу
        }

        if (Mony[0] == 0)
        {
            IsTrue = false;
            ZeroOutNumbers(30);
            Priority = 5; // Скидаємо пріоритет, якщо всі гроші витрачені
        }
        else
        {
            IsTrue = true;
        }
    }

    void UpdateColors()
    {
        for (int i = 0; i < Mony.Length; i++)
        {
            if (Mony[i] != 0)
            {
                // Перевірте чи індекс числа в межах доступного діапазону кольорів
                if (Mony[i] <= Coloring.Length)
                {
                    RenderMony[i].material.SetColor("_Color", Coloring[Mony[i]]); // Вирахуємо індекс з 0
                }
                else
                {
                    Debug.LogWarning("Немає збігу для кольору числа " + Mony[i]);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsTrue == false)
        {
            if (other.gameObject.tag == "Mony")
            {
                if (other.gameObject.GetComponent<MonyScr>().isDragging == false)
                {
                    Mony = new int[other.gameObject.GetComponent<MonyScr>().MonyType.Length];
                    System.Array.Copy(other.gameObject.GetComponent<MonyScr>().MonyType, Mony, other.gameObject.GetComponent<MonyScr>().MonyType.Length);

                    Destroy(other.gameObject);
                    Priority = 1; // Встановлюємо пріоритет для початку обробки чисел

                    foreach (var coll in Coll)
                    {
                        coll.Priority++; // Додаємо бонусний бал до пріоритету кожному об'єкту
                    }
                }
            }
        }
    }
    public void CheckNumbers()
    {
        int count = 1;
        int prevNumber = 0;

        foreach (int number in Mony)
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
        for (int i = 0; i < Mony.Length; i++)
        {
            if (Mony[i] == number && TimerDestroi <= 0)
            {
                Games.Scory++;
                Mony[i] = 0;
            }
        }
    }
}
