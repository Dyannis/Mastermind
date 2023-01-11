using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MasterMindRow : MasterMindManager
{
    //[SerializeField] private GameObject[] _ballsColor;
    [SerializeField] private GameObject Row;
    [SerializeField] private GameObject BallsLine;
    [SerializeField] private GameObject HintBall;
    [SerializeField] private GameObject _spawnBalls;
    [SerializeField] private GameObject _spawnHint;
    [SerializeField] private Camera _camera;
    [SerializeField] private Image _reticle;

    private Vector3 mosPos;

    protected int hint;
    private int _veritas = 0;
    private bool[] _truth = new bool[4];

    //[SerializeField] private int _reticleSpeed = 7;
    //[SerializeField] private GameObject NewLine;

    private int _incrementMaterial = -1;
    private GameObject _actualLine;
    private bool cancel;
    
    void Start()
    {
        cancel = false;
        _actualLine = Instantiate<GameObject>(BallsLine,_spawnBalls.transform.position,_spawnBalls.transform.rotation);
    }
    void Update()
    {
        RaycastHit hit;
        mosPos = Input.mousePosition;
        Ray _cam = _camera.ScreenPointToRay(mosPos);
        Debug.DrawRay(_cam.origin, _cam.direction * 20);

        if (Physics.Raycast(_cam.origin, _cam.direction, out hit))
        {
            _reticle.rectTransform.anchoredPosition = mosPos;
      
            if (hit.collider.gameObject.CompareTag("Ball"))
            {
                _reticle.color = Color.green;
                if (Input.GetMouseButtonDown(0) && cancel == false)
                {
                    ChangeColor(hit);
                }
            } else
                {
                    _reticle.color = Color.white;
                }
        }

        if (Input.GetKeyDown("enter") && _countTurn < 12){

            for (int i = 0; i < 4; i++)
            {
                _checkLine[i] = _actualLine.transform.GetChild(i).GetComponent<MeshRenderer>().sharedMaterial; // <==
                Debug.Log(_checkLine[i].name);
            }

            cancel = true;
            NewLineOrVictory(ValidLine());
        }
    }
    private void ChangeColor(RaycastHit hit)
    {
        if (hit.collider.GetComponent<MeshRenderer>().material == hit.collider.GetComponent<MeshRenderer>().material)
        {
            _incrementMaterial++;

            hit.collider.GetComponent<MeshRenderer>().material = _materials[_incrementMaterial];

            if (_incrementMaterial >= _materials.Length -1)
            {
                _incrementMaterial = -1;
            }
        }
    }
    protected bool ValidLine()
    {
        Debug.Log("ValidLine");
        _countTurn++;

        if (_countTurn == 12)
        {
            Debug.Log("U LOOSE !!!");
            //_scoreText.text = "U LOOSE !!";
        }

        for (int i = 0; i < 4; i++)
        {
            if (_checkLine[i] == _mastermind[i])
            {
                _truth[i] = true;
            }
            else
            {
                _truth[i] = false;
            }
        }

        for (int i = 0; i < _truth.Length; i++)
        {
            if (_truth[i] == true)
            {
                _veritas++;
            }
        }

        if (_veritas == 4)
        {
            Debug.Log("U win !");
            return true;
        }

        Debug.Log(_veritas + "/4 est juste");

        hint = _veritas;

        return false;
    }
    private void NewLineOrVictory(bool victory)
    {
        Debug.Log(hint);
        if (victory != true)
        {
            float count = 0f;
            for(int i = 0; i < hint; i++)
            {
                Instantiate<GameObject>(HintBall, new Vector3(_spawnHint.transform.position.x, _spawnHint.transform.position.y, _spawnHint.transform.position.z + count), _spawnHint.transform.rotation);
                count += 0.3f;
            }
            
            _actualLine = Instantiate<GameObject>(Row, new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z), transform.rotation);
        } else
        {
            //_scoreText.text = "U WIN !!";
            Debug.Log("U WIN !");
        }
    }
}
