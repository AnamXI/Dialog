using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueEntry{
    public int id;
    public string character;
    public string text;
}

[System.Serializable]
public class DialogueData
{
    public List<DialogueEntry> dialogues;
}
