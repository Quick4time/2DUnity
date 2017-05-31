using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : SingletoneAsComponent<ConversationManager> {

    public static ConversationManager Instance
    {
        get { return ((ConversationManager)_Instance); }
        set { _Instance = value; }
    }
    // Is there a Conversations going on.
    // Запускает наш разговор.
    bool talking = false;

    // The current line of text being displayed.
    // Текущая линия будет показана.
    ConversationEntry currentConversationLine;

    // Estimated width of characters in the font.
    // Оценочная ширина шрифта.
    int fontSpacing = 7;

    // How wide does the dialog window need to be .
    // Какой ширины будет диалоговое окно.
    int conversationTextWidith;

    // How high does the dialog window need to be.
    // Какой высоты будет диалоговое окно.
    int dialogHeight = 70;

    // Offset space needed for character image.
    public int displayTextureOffset = 70;

    // Scaled image rectangle for displaying character image.
    // Размер изображения.
    Rect scaledTextureRect;

    public void StartConversation(Conversation conversation)
    {
        if (!talking)
        {
            StartCoroutine(DisplayConversation(conversation));
        }
    }

    IEnumerator DisplayConversation (Conversation conversation)
    {
        talking = true;
        foreach(var conversationLine in conversation.ConversationLines)
        {
            currentConversationLine = conversationLine;
            conversationTextWidith = currentConversationLine.ConversationText.Length * fontSpacing;
            scaledTextureRect = new Rect(
                currentConversationLine.DisplayPic.textureRect.x / currentConversationLine.DisplayPic.texture.width,
                currentConversationLine.DisplayPic.textureRect.y / currentConversationLine.DisplayPic.texture.height,
                currentConversationLine.DisplayPic.textureRect.width / currentConversationLine.DisplayPic.texture.width,
                currentConversationLine.DisplayPic.textureRect.height / currentConversationLine.DisplayPic.texture.height);
            yield return new WaitForSeconds(3);
        }
        talking = false;
    }

    private void OnGUI()
    {
        if(talking)
        {
            //layout start
            GUI.BeginGroup(new Rect(Screen.width / 2 - conversationTextWidith / 2, 50, conversationTextWidith + displayTextureOffset + 10, dialogHeight));

            //the background box
            GUI.Box(new Rect(0, 0, conversationTextWidith + displayTextureOffset + 10, dialogHeight), "");

            //the character name
            GUI.Label(new Rect(displayTextureOffset, 10, conversationTextWidith + 30, 20), currentConversationLine.SpeakingCharacterName);

            //the Conversations text
            GUI.Label(new Rect(displayTextureOffset, 30, conversationTextWidith + 30, 20), currentConversationLine.ConversationText);

            //the character image
            GUI.DrawTextureWithTexCoords(new Rect(10, 10, 50, 50), currentConversationLine.DisplayPic.texture, scaledTextureRect);

            //layout end
            GUI.EndGroup();
        }
    }
}

