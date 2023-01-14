
using UnityEngine;

//скрипт применяется на объект типа Cube, является скриптом управления игроком
public class CubeInput : MonoBehaviour
{
    //сериализуем поля с Rigidbody куба и ГеймМенеджера, также скорость движения куба
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private GManager _gManager;
    
    private int _speed = 100;
    
    void Update()
    {
        //если наэимаем ПКМ, то отправляем об этом информацию в ГеймМенеджер
        if (Input.GetMouseButtonDown(0))
        {
            _gManager.CubeIsMoving();
        }
    }
    
    //здесь от направления мыши, скорости и времени нажатия мыщи зависит движение куба
    public void FixedUpdate()
    {
        if (transform.position.y < 0)
        {
            transform.position =new Vector3(0, 3, 0);
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out var hitInfo,1000f))
        {
            if (Input.GetMouseButton(0))
            {
                var target = hitInfo.point;
                var result = (target - transform.position).normalized;
                _rigidbody.AddForce(new Vector3(result.x, 0, result.z) * _speed);
            }
        }
        
    }
}