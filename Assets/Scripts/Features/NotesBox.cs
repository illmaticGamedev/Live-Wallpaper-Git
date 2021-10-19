using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesBox : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;
    [SerializeField] private GameObject newNotePrefab;
    [SerializeField] private Button btnAddNewNote;

    private List<NoteItem> allNotes = new List<NoteItem>();


    void Start()
    {
        btnAddNewNote.onClick.AddListener(AddNewNote);
    }

    void AddNewNote()
    {
        allNotes.Add(Instantiate(newNotePrefab, _verticalLayoutGroup.transform).GetComponent<NoteItem>());
    }
}