using UnityEngine;
using Random = UnityEngine.Random;

//в этом скрипте настраиваем сценарии столкновения куба с другими объектами
public class CubeCollider : MonoBehaviour
{
    //сериализуем поля с ГеймМенеджером и кубом
    [SerializeField] private GManager _gManager;

    [SerializeField] private Rigidbody _cube;
    
    //так же, как и ранее, создаем массив цветов, для удобного рандомайзера
    public Color[] colors = { Color.blue, Color.red, Color.green };

   //метод вызывается, когда куб задевает объект
    public void OnCollisionEnter(Collision collision)
    {
        //если бук сталкивается с объектом типа "цилиндер" и имеет один с ним цвет,
        //то разрушает его и перадет об этом сведения в ГеймМенеджер
        if (collision.gameObject.CompareTag("cylinder"))
        {
            var color = collision.gameObject.GetComponent<Renderer>();
            if (color.material.color == _cube.GetComponent<Renderer>().material.color)
            {
                UIManager.CilindresCount rgb = new UIManager.CilindresCount();
                Destroy(collision.gameObject);
                if (color.material.color == Color.red)
                {
                    rgb.red++;
                }
                if (color.material.color == Color.green)
                {
                    rgb.green++;
                }
                if (color.material.color == Color.blue)
                {
                    rgb.blue++;
                }
                _gManager.RGBCompression(rgb);
            }
        }

        //если же с объектом типа "сфера", то так же разрушает ее, то берет ее цвет
        if (collision.gameObject.CompareTag("sphere"))
        {
            _cube.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
            Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("sphere"))
            {
                var sphere = Instantiate(collision.gameObject);
                sphere.transform.position = new Vector3(Random.Range(-40, 10), 2, Random.Range(-40, 40));
                sphere.GetComponent<Renderer>().material.color = colors[Random.Range(0, 3)];
            }
        }

    }

}