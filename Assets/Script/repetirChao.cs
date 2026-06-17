using System.Security.Cryptography;
using UnityEngine;

public class repetirChao : MonoBehaviour
{
    private GameController _gameController;

    private bool _chaoInstanciado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      _gameController = FindAnyObjectByType(typeof(GameController)) as GameController;   
    }

    // Update is called once per frame
    void Update()
    {
        if (_chaoInstanciado == false)
        {
            if (transform.position.x <= 0)
            {
                _chaoInstanciado = true;
                GameObject ObjetoTemporarioChao = Instantiate(_gameController._ChaoPrefab);
                ObjetoTemporarioChao.transform.position = new Vector3(transform.position.x + _gameController._ChaoTamanho, transform.position.y, 0);
                Debug.Log("O chão foi instanciado!");
            }
        }

        if (transform.position.x < _gameController._ChaoDestruido) //-38
        {
            Destroy(this.gameObject);
        }
    }   
    private void FixedUpdate()
    {
        moveChao();
    }
    void moveChao()
    {
        transform.Translate(Vector3.left * _gameController._ChaoVelocidade * Time.deltaTime);
    }
}
