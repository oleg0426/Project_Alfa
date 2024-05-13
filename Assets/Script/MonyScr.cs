using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonyScr : MonoBehaviour
{
    private Vector3 mouseStartPos;
    private Vector3 objectStartPos;
    private Vector2 touchStartPos;
    public Color[] Coloring;
    public GameObject[] MonyObj;
    public bool isDragging = false;
    private Camera mainCamera;
    public int[] MonyType;
    int fors = 0;
    public bool[] IsBool;
    int random;

    void Start()
    {
        random = Random.Range(0, 29);
        mainCamera = Camera.main;
        switch (random){
            case 0:
                MonyType[0] = 1;
                MonyType[1] = 1;
                MonyType[2] = 1;
                SetObjectColors(new int[] { 1, 1, 1, 0 });
                break;
            case 1:
                MonyType[0] = 2;
                MonyType[1] = 2;
                MonyType[2] = 1;
                MonyType[3] = 1;
                SetObjectColors(new int[] { 2, 2, 1, 1 });
                break;
            case 2:
                MonyType[0] = 1;
                MonyType[1] = 1;
                MonyType[2] = 2;
                MonyType[3] = 2;
                SetObjectColors(new int[] { 1, 1, 2, 2 });
                break;
            case 3:
                MonyType[0] = 2;
                MonyType[1] = 2;
                MonyType[2] = 1;
                MonyType[3] = 1;
                SetObjectColors(new int[] { 2, 2, 1, 1 });
                break;
            case 4:
                MonyType[0] = 2;
                MonyType[1] = 2;
                MonyType[2] = 2;
                SetObjectColors(new int[] { 2, 2, 2, 0 });
                break;
            case 5:
                MonyType[0] = 3;
                MonyType[1] = 3;
                MonyType[2] = 1;
                MonyType[3] = 1;
                SetObjectColors(new int[] { 3, 3, 1, 1});
                break;
            case 6:
                MonyType[0] = 2;
                MonyType[1] = 2;
                MonyType[2] = 3;
                MonyType[3] = 3;
                SetObjectColors(new int[] { 2, 2, 3, 3});
                break;
            case 7:
                MonyType[0] = 3;
                MonyType[1] = 3;
                MonyType[2] = 3;
                SetObjectColors(new int[] { 3, 3, 3, 0 });
                break;
            case 8:
                MonyType[0] = 1;
                MonyType[1] = 1;
                MonyType[2] = 3;
                MonyType[3] = 3;
                SetObjectColors(new int[] { 1, 1, 3, 3});
                break;
            case 9:
                MonyType[0] = 2;
                MonyType[1] = 3;
                MonyType[2] = 1;
                SetObjectColors(new int[] { 2, 3, 1, 0 });
                break;
            case 10:
                MonyType[0] = 4;
                MonyType[1] = 4;
                MonyType[2] = 3;
                MonyType[3] = 3;
                SetObjectColors(new int[] { 4, 4, 3, 3 });
                break;
            case 11:
                MonyType[0] = 4;
                MonyType[1] = 4;
                MonyType[2] = 4;
                SetObjectColors(new int[] { 4, 4, 4});
                break;
            case 12:
                MonyType[0] = 4;
                MonyType[1] = 4;
                MonyType[2] = 2;
                MonyType[3] = 2;
                SetObjectColors(new int[] { 4, 4, 2, 2 });
                break;
            case 13:
                MonyType[0] = 4;
                MonyType[1] = 4;
                MonyType[2] = 1;
                MonyType[3] = 1;
                SetObjectColors(new int[] { 4, 4, 1, 1 });
                break;
            case 14:
                MonyType[0] = 1;
                MonyType[1] = 1;
                MonyType[2] = 4;
                MonyType[3] = 4;
                SetObjectColors(new int[] { 1, 1, 4, 4 });
                break;
            case 15:
                MonyType[0] = 2;
                MonyType[1] = 2;
                MonyType[2] = 4;
                MonyType[3] = 4;
                SetObjectColors(new int[] { 2, 2, 4, 4 });
                break;
            case 16:
                MonyType[0] = 3;
                MonyType[1] = 3;
                MonyType[2] = 4;
                MonyType[3] = 4;
                SetObjectColors(new int[] { 3, 3, 4, 4 });
                break;
            case 17:
                MonyType[0] = 5;
                MonyType[1] = 5;
                MonyType[2] = 5;
                SetObjectColors(new int[] { 5, 5, 5 });
                break;
            case 18:
                MonyType[0] = 6;
                MonyType[1] = 6;
                MonyType[2] = 6;
                SetObjectColors(new int[] { 6, 6, 6});
                break;
            case 19:
                MonyType[0] = 6;
                MonyType[1] = 6;
                MonyType[2] = 5;
                MonyType[3] = 5;
                SetObjectColors(new int[] { 6, 6, 5, 5 });
                break;
            case 20:
                MonyType[0] = 6;
                MonyType[1] = 6;
                MonyType[2] = 4;
                MonyType[3] = 4;
                SetObjectColors(new int[] { 6, 6, 4, 4 });
                break;
            case 21:
                MonyType[0] = 5;
                MonyType[1] = 5;
                MonyType[2] = 1;
                MonyType[3] = 1;
                SetObjectColors(new int[] { 5, 5, 1, 1 });
                break;
            case 22:
                MonyType[0] = 5;
                MonyType[1] = 5;
                MonyType[2] = 6;
                MonyType[3] = 6;
                SetObjectColors(new int[] { 5, 5, 6, 6 });
                break;
            case 23:
                MonyType[0] = 5;
                MonyType[1] = 5;
                MonyType[2] = 4;
                MonyType[3] = 4;
                SetObjectColors(new int[] { 5, 5, 4, 4 });
                break;
            case 24:
                MonyType[0] = 6;
                MonyType[1] = 6;
                MonyType[2] = 1;
                MonyType[3] = 1;
                SetObjectColors(new int[] { 6, 6, 1, 1 });
                break;
            case 25:
                MonyType[0] = 6;
                MonyType[1] = 5;
                MonyType[2] = 5;
                MonyType[3] = 1;
                SetObjectColors(new int[] { 6, 5, 5, 1 });
                break;
            case 26:
                MonyType[0] = 5;
                MonyType[1] = 3;
                MonyType[2] = 3;
                MonyType[3] = 5;
                SetObjectColors(new int[] { 5, 3, 3, 5});
                break;
            case 27:
                MonyType[0] = 6;
                MonyType[1] = 2;
                MonyType[2] = 2;
                MonyType[3] = 6;
                SetObjectColors(new int[] { 6, 2, 2, 6});
                break;
            case 28:
                MonyType[0] = 4;
                MonyType[1] = 4;
                MonyType[2] = 5;
                MonyType[3] = 5;
                SetObjectColors(new int[] { 4, 4, 5, 5 });
                break;
            case 29:
                MonyType[0] = 4;
                MonyType[1] = 4;
                MonyType[2] = 6;
                MonyType[3] = 6;
                SetObjectColors(new int[] { 4, 4, 6, 6 });
                break;
        }
        while (fors < MonyType.Length)
        {
            if (MonyType[fors] != 0)
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
    }

    void Update()
    {
        // Якщо ми перетягуємо об'єкт
        if (isDragging)
        {
            // Обчислюємо зміщення миші
            Vector3 delta = Input.mousePosition - mouseStartPos;
            // Перетворюємо зміщення миші на площину камери (X та Z) у світові координати
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, objectStartPos);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 hitPoint = ray.GetPoint(distance);
                delta = hitPoint - objectStartPos;
            }
            // Задаємо нову позицію об'єкту з урахуванням зміщення на площині XZ
            transform.position = objectStartPos + new Vector3(delta.x, 0, delta.z);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Беремо перше торкання

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Запам'ятовуємо початкові позиції торкання та об'єкта
                    touchStartPos = touch.position;
                    objectStartPos = transform.position;
                    // Перевіряємо чи торкання потрапило на об'єкт
                    RaycastHit hit;
                    Ray ray = mainCamera.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject == gameObject)
                        {
                            isDragging = true;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // Обчислюємо зміщення пальця на тачпаді
                        Vector2 delta = touch.position - touchStartPos;
                        // Перетворюємо зміщення на площину камери (X та Z) у світові координати
                        Vector3 moveDirection = mainCamera.transform.TransformDirection(new Vector3(delta.x, 0, delta.y));
                        // Задаємо нову позицію об'єкту з урахуванням зміщення на площині XZ
                        transform.position = objectStartPos + new Vector3(moveDirection.x, 0, moveDirection.z);
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
    }

    void SetObjectColors(int[] colors)
    {
        // Присвоюємо кожному об'єкту колір відповідно до його числового значення
        for (int i = 0; i < colors.Length; i++)
        {
            // Перевіряємо, чи індекс кольору в межах доступного діапазону кольорів
            if (colors[i] <= Coloring.Length)
            {
                MonyType[i] = colors[i];
                // Вираховуємо індекс з 0, оскільки масиви в C# індексуються з 0
                MonyObj[i].GetComponent<Renderer>().material.SetColor("_Color", Coloring[colors[i]]);
            }
            else
            {
                Debug.LogWarning("Немає збігу для кольору числа " + colors[i]);
            }
        }
    }
}
