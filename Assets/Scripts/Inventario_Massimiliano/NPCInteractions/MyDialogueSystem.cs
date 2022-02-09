using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialogueSystem : MonoBehaviour
{
    public static MyDialogueSystem Instance { get; set; }

    public GameObject dialoguePanel;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText;
    int dialogueIndex;

    public static bool dialogueON;

    // Start is called before the first frame update
    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (!InventoryUI.InventarioON && !Diary.DiarioON && !ShowMouse.isLaying)
        {
            Cursor.visible = dialogueON;

            if (dialogueON)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    public void AddNewDialogue(string[] lines)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLines[dialogueIndex];
        dialogueON = true;
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            dialogueON = false;
        }
    }

    
}
