using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class NotesBox : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;
    [SerializeField] private GameObject newNotePrefab;
    [SerializeField] private Button btnAddNewNote;

    private List<NoteItem> allNotes = new List<NoteItem>();


    void Start()
    {
        btnAddNewNote.onClick.AddListener(AddNewNote);
        LoadNotes();
    }

    void AddNewNote()
    {
        allNotes.Add(Instantiate(newNotePrefab, _verticalLayoutGroup.transform).GetComponent<NoteItem>());
    }

    public void SaveNotes(string note)
    {
        
    }

    void LoadNotes()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/Notes.txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach (var item in fileLines)
        {
            var noteItem = Instantiate(newNotePrefab, _verticalLayoutGroup.transform).GetComponent<NoteItem>();
            allNotes.Add(noteItem);
            noteItem.LoadNote(item);
        }
        
    }
}