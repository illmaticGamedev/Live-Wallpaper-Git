using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NoteItem : MonoBehaviour
{
    public Button deleteButton;
    public Button editButton;
    public TMP_InputField myInputField;
    private void OnEnable()
    {
        deleteButton.onClick.AddListener(DeleteNote);
        //yInputField = GetComponent<TMP_InputField>();
        myInputField.onEndEdit.AddListener(AfterEditNote);
    }

    private void AfterEditNote(string arg0)
    {
       Debug.Log("SAVED STRING : " + arg0);
    }
    
    void DeleteNote()
    {
        Destroy(this.gameObject);
    }

    public void LoadNote(string Note)
    {
        myInputField.text = Note;
    }

  
}