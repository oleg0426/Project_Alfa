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
    public int Priority; // ������ ��� �� int ��� ��������� �������� �����
    public GameObject[] MonyObj;
    public Renderer[] RenderMony;
    public Color[] Coloring;
    public bool[] IsBool;
    float TimerDestroi=0.125f;
    public float lastChange = 0;
    bool IsTrues = true;
    float TimerDestoy = 1f;
    int fors = 0;
    bool foundMatch = false; // ��������� ��� ��������� ����
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
                    continue; // ���������� ������ ��������
                }

                for (int j = y - 1; j >= 0; j--)
                {
                    if (destinationList[j] == 0 || sourceList[i] == 0)
                    {
                        continue; // ���������� ������ ��������
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
                                foundMatch = true; // ������������ ���������, �� �������� ���
                                break; // �������� � �����, ���� �������� ���
                            }
                        }
                    }

                }

                if (foundMatch) // ���� �������� ���������, ���������� ������� ����
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
        // ��������� �������
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
                    print("���� �������");
                }
            }
            TimerDestroi -= Time.deltaTime;
        }


        // ��������, �� ��������� ����������� ��������
        if (transferCompleted)
        {
            CheckNumbers();
            ZeroOutNumbers(10);// ������ ������ CheckNumbers() ���� ���������� ����������� ��������
            transferCompleted = false; // �������� �������� ���� ������� ������
        }

        if (Mony[0] == 0)
        {
            IsTrue = false;
            ZeroOutNumbers(30);
            Priority = 5; // ������� ��������, ���� �� ����� ��������
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
                // �������� �� ������ ����� � ����� ���������� �������� �������
                if (Mony[i] <= Coloring.Length)
                {
                    RenderMony[i].material.SetColor("_Color", Coloring[Mony[i]]); // �������� ������ � 0
                }
                else
                {
                    Debug.LogWarning("���� ���� ��� ������� ����� " + Mony[i]);
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
                    Priority = 1; // ������������ �������� ��� ������� ������� �����

                    foreach (var coll in Coll)
                    {
                        coll.Priority++; // ������ �������� ��� �� ��������� ������� ��'����
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
                        Debug.Log("�������� 10 � ����� ��������� ���������� ����� �����!");
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
    // ��������� �����, �� ������� �� �����������
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
