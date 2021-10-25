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
    string readFromFilePath = Application.streamingAssetsPath + "/Notes.txt";
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

    public void SaveNote(string note)
    {
        File.AppendAllText(readFromFilePath,note + "\n");
    }

    void LoadNotes()
    {
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach (var item in fileLines)
        {
            var noteItem = Instantiate(newNotePrefab, _verticalLayoutGroup.transform).GetComponent<NoteItem>();
            allNotes.Add(noteItem);
            noteItem.LoadNote(item);
        }
        
    }

   public void DeleteNote(string note)
    {
        var tempFile = Path.GetTempFileName();
        var linesToKeep = File.ReadLines(readFromFilePath).Where(l => l != note);

        File.WriteAllLines(tempFile, linesToKeep);

        File.Delete(readFromFilePath);
        File.Move(tempFile, readFromFilePath);
    }

   
}