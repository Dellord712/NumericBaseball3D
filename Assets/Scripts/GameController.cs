using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private NumberAllocator _numberAllocator;
    [SerializeField] private ElectronicBoard _electronicBoard;
    [SerializeField] private BeforeNumber _beforeNumber;
    [SerializeField] private CurrentRound _currentRound;
    [SerializeField] private Result _result;

    private int[] _solution;
    private int[] _question;
    private int[] _beforeQuestion;

    private int _attempts;

    private void Start()
    {
        GameManager.Instance.GameController = this;
        GameReset(3);
    }

    public void SetQuestion(int index, int number)
    {
        _question[index] = number;
        _currentRound.SetBases(index, _question);
    }

    public void CheckSolution()
    {
        for(int i = 0; i<_question.Length;i++)
        {
            if (_question[i] == -1)
            {
                Debug.Log("모두채워져있지않음");
                return;
            } 
        }
        if (CheckAttempts())
        {
            _electronicBoard.SetInfo(_attempts, GetCount().x, GetCount().y,_question);
            _beforeNumber.SetInfo(_question, GetCount().x == 3 ? 2: GetCount().x, GetCount().y);
            _currentRound.SetRound(_attempts + 1);
            Debug.Log($"{_attempts}번째 시도 : {GetCount().x}스트라이크 {GetCount().y}볼");
            if (GetCount().x == _question.Length) _result.Open(_question, _attempts);
        }
        else
        {
            Debug.Log("바로 전에 같은 시도를 했습니다.");
        }
    }

    public void GameReset(int count)
    {
        _numberAllocator.SetCubeNumbers();
        _solution = CustomMath.Combination(count, 0, 9);
        _question = new int[count];
        _beforeQuestion = null;
        for (int i = 0; i < count; i++) _question[i] = -1;
        _attempts = 0;
    }

    private bool CheckAttempts()
    {
        if(_beforeQuestion == null)
        {
            _beforeQuestion = new int[_question.Length];
            return ChangeBeforeQuestion();
        }
        else
        {
            for(int i=0; i< _question.Length;i++)
            {
                if (_question[i] != _beforeQuestion[i]) return ChangeBeforeQuestion();
            }
        }
        return false;
    }

    private bool ChangeBeforeQuestion()
    {
        for (int i = 0; i < _question.Length; i++) _beforeQuestion[i] = _question[i];
        _attempts++;
        return true;
    }

    private Vector2Int GetCount()
    {
        int strike = 0;
        int ball = 0;
        for(int i=0;i<_solution.Length;i++)
        {
            for(int j=0;j<_solution.Length;j++)
            {
                if (i == j && _solution[i] == _question[j]) strike++;
                else if (_solution[i] == _question[j]) ball++;
            }
        }
        return new Vector2Int(strike, ball);
    }
}
