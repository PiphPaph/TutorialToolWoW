using UnityEngine;

public class ThirdPersonLookCamera : MonoBehaviour
{
    [SerializeField] private Transform character; // Объект персонажа
    [SerializeField] private Transform cameraTransform; // Объект камеры
    public float sensitivity = 2f; // Чувствительность мыши
    public float smoothing = 5f; // Гладкость движения
    public float distanceFromCharacter = 5f; // Расстояние от персонажа до камеры
    public float heightOffset = 1.5f; // Высота камеры над персонажем
    public float rotationSmoothTime = 0.1f; // Время сглаживания поворота персонажа

    private float rotationY; // Вертикальный угол
    private float rotationX; // Горизонтальный угол
    private float currentCharacterYRotation; // Текущий угол поворота персонажа
    private float rotationVelocity; // Скорость поворота персонажа

    // void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked; // Закрепляем курсор в центре экрана
    // }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)) // Проверяем, зажата ли ПКМ
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            // Обновляем углы вращения
            rotationX += mouseDelta.x * sensitivity; // Горизонтальное вращение
            rotationY -= mouseDelta.y * sensitivity; // Вертикальное вращение
            rotationY = Mathf.Clamp(rotationY, -40, 85); // Ограничиваем вертикальное вращение
        }

        UpdateCameraPosition();
        UpdateCharacterRotation(); // Обновляем вращение персонажа
    }

    private void UpdateCameraPosition()
    {
        // Определяем направление, в котором должна смотреть камера
        Quaternion cameraRotation = Quaternion.Euler(rotationY, rotationX, 0);
        Vector3 desiredPosition = character.position - cameraRotation * Vector3.forward * distanceFromCharacter + Vector3.up * heightOffset;

        // Плавное перемещение камеры
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, Time.deltaTime * smoothing);
        cameraTransform.rotation = cameraRotation; // Устанавливаем вращение камеры
    }

    private void UpdateCharacterRotation()
    {
        // Плавное вращение персонажа в сторону камеры
        float targetYRotation = rotationX; // Целевой угол
        currentCharacterYRotation = Mathf.SmoothDamp(currentCharacterYRotation, targetYRotation, ref rotationVelocity, rotationSmoothTime);
        character.rotation = Quaternion.Euler(0, currentCharacterYRotation, 0);
    }
}
