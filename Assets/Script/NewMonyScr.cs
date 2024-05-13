using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonyScr : MonoBehaviour
{
    public GameObject MonyObj;
    public Transform[] SpawnerPos;
    public int MonyObjrct;
    private int objectCount; // ������� ������� ��'����
    void Start()
    {
        // ��������� ��������� ������� ��'����
        for (int i = 0; i < MonyObjrct; i++)
        {
            CreateObject();
        }
    }

    private void Update()
    {
        ObjectChanged();
    }

    // ����� ��� ��������� ������ ��'����
    void CreateObject()
    {
        if (objectCount==0)
        {

            Instantiate(MonyObj, SpawnerPos[objectCount].position, Quaternion.identity);
        }
        else
        {
            Instantiate(MonyObj, SpawnerPos[objectCount].position, Quaternion.identity);
        }
        objectCount++;
    }

    public void ObjectChanged()
    {
        GameObject[] moneyObjects = GameObject.FindGameObjectsWithTag("Mony");
        objectCount = moneyObjects.Length;

        if (objectCount == 0)
        {
            // ���� ������� ��'���� ����, �������� ���
            for (int i = 0; i < MonyObjrct; i++)
            {
                CreateObject();
            }
        }
    }
}
