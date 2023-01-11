using UnityEngine;
public class MasterMindManager : MonoBehaviour
{ 
    [SerializeField] protected Material[] _materials = new Material[6];
    protected static Material[] _mastermind = new Material[4];
    protected Material[] _checkLine = new Material[4];

    protected static int _countTurn;

    private void Awake()
    {
        
        _countTurn = 1;
        Debug.Log(_countTurn);
        int index;
       
        for (int i = 0; i < 4; i++)
        {
            index = Random.Range(0, 6);
            _mastermind[i] = _materials[index];
            Debug.Log(_mastermind[i].name);
            //Debug.Log(BallsLine.transform.GetChild(i).GetComponent<Renderer>().sharedMaterial);
        }
    }
}
