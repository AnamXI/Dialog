using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using NUnit.Framework.Internal;
using System.Runtime.CompilerServices;
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private DialogueContainer _dialogueContainer = new DialogueContainer();
    private List<DialogueLine> dialogueLines;
    private int currentIndex = 0;

    //private string jsonPath;
    [SerializeField] private TextAsset jsonText; //Set dialogue json per trigger

    void Start()
    {

        //jsonPath = Path.Combine(Application.dataPath, "Dialog Stuff/Lines/td.json");
        dialogueLines = new List<DialogueLine>();

        LoadDialogue(jsonText.text);
        DisplayDialogue();
    }


    void LoadDialogue(string text)
    {
        if (jsonText!=null)
        {

            //string jsonText = File.ReadAllText(jsonPath);
            
            DialogueData data = JsonUtility.FromJson<DialogueData>(text);
            
            
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
            //_dialogueContainer.chSprite.sprite = ;
            currentIndex++;
        }else{
            Debug.Log("End of Dialogue");
        }
    }

    public void OnNextButtonPressed(){
        DisplayDialogue();
    }
}

