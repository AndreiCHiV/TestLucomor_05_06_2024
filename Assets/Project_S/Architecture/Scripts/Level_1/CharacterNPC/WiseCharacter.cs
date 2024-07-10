using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class WiseCharacter : MonoBehaviour
    {
        [SerializeField] private TextAsset _inkJSON_101000;
        [SerializeField] private TextAsset _inkJSON_101001;
        [SerializeField] private TextAsset _inkJSON_101002;
        [SerializeField] private TextAsset _inkJSON_101003;
        [SerializeField] private TextAsset _inkJSON_101004;
        [SerializeField] private TextAsset _inkJSON_101005;

        private const string WISE = "Wise";

        private QuestMessageData _questMessageDataWise_0 = new QuestMessageData()
        {
            messageID = 0,
            message = "Виз не сидится на попе и она опять сходит с ума! Ей нужно две монеты для её безумных экспериментов." +
            "Одна монета находится у девчёнки, что стоит рядом, вторую она пролюбила где-то поблизости.",
            messageChangeDialogueID = new int[] { 101002, 102001, 103001 }

        };
        private QuestMessageData _questMessageDataWise_1 = new QuestMessageData()
        {
            messageID = 1,
            message = "Одну из монет я выпросила у мерзкой девчёнки, как её там... Ааа, не важно, вобщем она теперь у меня!",
            messageChangeDialogueID = new int[] { 102002 }

        };
        private QuestMessageData _questMessageDataWise_2 = new QuestMessageData()
        {
            messageID = 2,
            message = "Волчара сказал что одна монетка валяется где-то неподалёку, чтож надо порыться в траве.",
            messageChangeDialogueID = new int[] { 103002, 500001 }
        };
        private QuestMessageData _questMessageDataWise_3 = new QuestMessageData()
        {
            messageID = 3,
            message = "Я пошарилась неподалёку и нашла одну монету.",
            messageChangeDialogueID = new int[] { 101003, 500000 }
        };
        private QuestMessageData _questMessageDataWise_4 = new QuestMessageData()
        {
            messageID = 4,
            message = "Задание выполнено, я молодец, награда - говно! Ну вобщем всё как обычно.",
            messageChangeDialogueID = new int[] { 101004 },
            completedQuest = true
        };

        public string GetName()
        {
            return WISE;
        }

        public DialogueData[] InitializationDialogueData()
        {
            DialogueData dialogueDataWise_0 = new DialogueData()
            {
                inkJSON = _inkJSON_101000,
                dataDialogueID = 101000
            };
            DialogueData dialogueDataWise_1 = new DialogueData()
            {
                inkJSON = _inkJSON_101001,
                dataDialogueID = 101001
            };
            DialogueData dialogueDataWise_2 = new DialogueData()
            {
                inkJSON = _inkJSON_101002,
                dataDialogueID = 101002
            };
            DialogueData dialogueDataWise_3 = new DialogueData()
            {
                inkJSON = _inkJSON_101003,
                dataDialogueID = 101003
            };
            DialogueData dialogueDataWise_4 = new DialogueData()
            {
                inkJSON = _inkJSON_101004,
                dataDialogueID = 101004
            };
            DialogueData dialogueDataWise_5 = new DialogueData()
            {
                inkJSON = _inkJSON_101005,
                dataDialogueID = 101005
            };

            return new DialogueData[]
            {
                dialogueDataWise_0,
                dialogueDataWise_1,
                dialogueDataWise_2,
                dialogueDataWise_3,
                dialogueDataWise_4,
                dialogueDataWise_5
            };
        }

        public DialogueCharacterData InitializationDialogueCharacter()
        {
            return new DialogueCharacterData()
            {
                owner = WISE
            };
        }

        public QuestListData InitializationQuests()
        {
            List<QuestMessageData> questMessageWise_101 = new List<QuestMessageData>()
            {
                _questMessageDataWise_0,
                _questMessageDataWise_1,
                _questMessageDataWise_2,
                _questMessageDataWise_3,
                _questMessageDataWise_4,
            };
            QuestData questDataWise_101 = new QuestData()
            {
                questID = 101,
                nameQuest = "Виз опять чё-то надо!",
                questMessage = questMessageWise_101
            };

            return new QuestListData()
            {
                owner = "Wise",
                questDatas = new List<QuestData>()
                {
                    questDataWise_101
                }
            };

        }

    }
}
