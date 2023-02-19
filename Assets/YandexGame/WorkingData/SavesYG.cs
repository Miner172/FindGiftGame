﻿
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool feedbackDone;
        public bool promptDone;

        // Ваши сохранения
        public int EasyModeRecord = 0;
        public int MediumModeRecord = 0;
        public int HardModeRecord = 0;
    }
}
