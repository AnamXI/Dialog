using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private DialogueContainer _dialogueContainer = new DialogueContainer();
    private List<DialogueLine> dialogueLines;
    private int currentIndex = 0;

    private String jsonPath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        jsonPath = Path.Combine(Application.dataPath, "Dialogue Stuff/Lines/testdialogue.json");
        dialogueLines = new List<DialogueLine>();

        LoadDialogue();
        DisplayDialogue();
    }


    void LoadDialogue()
    {
        if (File.Exists(jsonPath))
        {

            string jsonText = File.ReadAllText(jsonPath);
            
            DialogueData data = JsonUtility.FromJson<DialogueData>(jsonText);
            
            
            dialogueLines.Clear();

            foreach (var entry in data.dialogues){
                DialogueCharacter character = new DialogueCharacter { name = entry.character };
                DialogueLine line = new DialogueLine { character = character, line = entry.text};
                dialogueLines.Add(line);

            }
        }
        else{
            Debug.LogError("Dialogue JSON file not found");
        }
    }

    public void DisplayDialogue(){
        if (currentIndex < dialogueLines.Count)
        {
            DialogueLine line = dialogueLines[currentIndex];
            _dialogueContainer.nameText.text = line.character.name;
            _dialogueContainer.dialogueText.text = line.line;
            currentIndex++;
        }else{
            Debug.Log("End of Dialogue");
        }
    }

    public void OnNextButtonPressed(){
        DisplayDialogue();
    }
}

