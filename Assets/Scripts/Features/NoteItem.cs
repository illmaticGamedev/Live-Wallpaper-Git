using System;
using UnityEngine;
using UnityEngine.UI;

public class NoteItem : MonoBehaviour
{
    public Button deleteButton;
    public Button editButton;

    private void OnEnable()
    {
        deleteButton.onClick.AddListener(DeleteNote);
    }

    void DeleteNote()
    {
        Destroy(this.gameObject);
    }

    void EditNote()
    {
        // might add something here later
    }
}