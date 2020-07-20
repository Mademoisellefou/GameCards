using System.Collections;
using UnityEngine;

public class CreatorCrads : MonoBehaviour
{
    public static CreatorCrads instance;
    public int score=0;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject Card;
    public Transform initio;
    public float inc = 1f;
    int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
    //This is a function we will create in a minute!
    public Sprite[] _faces;
    void Start()
    {
       
        numbers = ShuffleArray(numbers);
        for (int i = 0; i <4; i++)
        {
            int nroid = numbers[i];
            GameObject l = Instantiate(Card);
            Card a = l.GetComponent<Card>();
            a.setid( nroid);
            Sprite tmp = asignarle(nroid) ;
            a.setface(tmp);
            l.transform.position = new Vector3(initio.position.x * inc, initio.position.y, initio.position.z);
            inc += 2;
        }
        var pos = initio.position;
        pos.y = pos.y / 2;
        initio.position =pos;
        inc = 1f;
        for (int i = 4; i < 8; i++)
        {
            Debug.Log("hola "+i);
            int nroid = numbers[i];
            GameObject l = Instantiate(Card);
            Card a = l.GetComponent<Card>();
            a.setid(nroid);
            Sprite tmp = asignarle(nroid);
            a.setface(tmp);
            l.transform.position = new Vector3(initio.position.x * inc, initio.position.y, initio.position.z);
            inc += 2;
        }
    }

    // Update is called once per frame
    public Sprite asignarle(int _i) {
        Sprite rt = null;
        switch (_i) {
            case 0:  //cuad
                rt = _faces[0];
                break;
            case 1://cir
                rt = _faces[1];
                break;
            case 2:  //cuad
                rt = _faces[2];
                break;
            case 3://cir
                rt = _faces[3];
                break;
            default:
                break;

        }

        return  rt ;
    }
    private Card _firstRevealed=null;
    private Card _secondRevealed=null;
    public void fillup(Card  uno) {
        if (_firstRevealed == null)
        {
            _firstRevealed = uno;
        }
        else {
            _secondRevealed = uno;
            if (_firstRevealed != null&& _secondRevealed != null ) {
            StartCoroutine(CheckMatch());
        }
        }

    }

    
    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.getid() == _secondRevealed.getid())
        {
            print("Good");
            score++;
        }
        else {
            yield return new WaitForSeconds(0.5f);
            _firstRevealed.unreveld();
            _secondRevealed.unreveld();

            print("Bad");
        }
        _firstRevealed = null;
        _secondRevealed = null;
        
    }
    public int [] ShuffleArray(int[] numbers) {
        
            int[] newArray = numbers.Clone() as int[];
            for (int i = 0; i < newArray.Length; i++)
            {
                int tmp = newArray[i];
                int r = Random.Range(i, newArray.Length);
                newArray[i] = newArray[r];
                newArray[r] = tmp;
            }
            return newArray;
    }
    public bool youcanreveal {
        get { return _secondRevealed == null; }
    }
}
