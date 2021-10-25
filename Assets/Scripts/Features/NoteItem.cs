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
    private NotesBox noteBox;
    string readFromFilePath = Application.streamingAssetsPath + "/Notes.txt";
    private string lastString;
    private void OnEnable()
    {
        deleteButton.onClick.AddListener(DeleteNote);
        myInputField.onEndEdit.AddListener(AfterEditNote);
        myInputField.onSelect.AddListener(Editing);
        noteBox = GetComponentInParent<NotesBox>();
    }

    private void Editing(string arg0)
    {
        lastString = myInputField.text;
    }

    private void AfterEditNote(string arg0)
    {
        noteBox.DeleteNote(lastString);
        noteBox.SaveNote(arg0);
    }

    void DeleteNote()
    {
        noteBox.DeleteNote(myInputField.text);
        Destroy(this.gameObject);
    }

    public void LoadNote(string Note)
    {
        myInputField.text = Note;
    }
}