using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class PolynomeEntry : MonoBehaviour
{
    public TMP_InputField inputField;

    public string monome;
    public List<string> monomes = new();
    
    public LinkedList polynomeList = new();
    public List<LinkedList> polynomes = new();

    void OnEnable()
    {
        inputField.contentType = TMP_InputField.ContentType.Custom;
    }

    public void FieldToList()
    {
        char[] _input = inputField.text.Trim().ToCharArray();
        inputField.text = "";

        for (int i = 0; i < _input.Length; i++)
        {
            if (i == 0)
            {
                CheckMonome(i, _input);
            }
            else
            {
                if (_input[i].Equals('+') || _input[i].Equals('-'))
                {
                    CheckMonome(i, _input);
                }
            }
        }
    }

    private void CheckMonome(int _i, char[] _input)
    {
        if (char.IsDigit(_input[_i]) || char.IsLetter(_input[_i]))
            monome += "+";
        
        monome += _input[_i];
        int _index = _i + 1;
        bool _didTakeUnite = false;
        while ( _index < _input.Length && _input[_index] != '+' && _input[_index] != '-')
        {
            if (!_didTakeUnite && char.IsLetter(_input[_index]))
            {
                monome += ".";
                _didTakeUnite = true;
            }
                
            monome += _input[_index];
            _index++;
        }
        MonomeToList(monome);
        //MonomeToNode(monome);
    }

    public void MonomeToList(string _monome)
    {
        monomes.Add(_monome);
        monome = "";
    }

    public void MonomeToNode(string _monome)
    {
        Node _monomeNode = new Node();
        _monomeNode.value = float.Parse(_monome);
        Debug.Log(_monomeNode.value);
    }
}
