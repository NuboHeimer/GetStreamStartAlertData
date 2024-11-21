///----------------------------------------------------------------------------
///   Module:       Get stream annonce data
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      personal
///----------------------------------------------------------------------------
using System;
using System.IO;
using Newtonsoft.Json;

public class CPHInline
{
    public bool SetAnnounceDataVariable()
    {
        if ((CPH.GetGlobalVar<string>("stringAnnounceData") == null) || ((CPH.GetGlobalVar<string>("stringAnnounceData") == "")))
        {
            try
            {
                string pathToAnnounceData = args["pathToAnnounceData"].ToString();
                string stringAnnounceData = File.ReadAllText(pathToAnnounceData);
                CPH.SetGlobalVar("stringAnnounceData", stringAnnounceData, true);
                CPH.LogInfo("Данные анонса загружены в стримербот.");
            }
            catch (Exception e)
            {
                CPH.LogError("Не удалось получить аргумент pathToAnnounceData. " + e.Message);
                CPH.ShowToastNotification("Не удалось получить аргумент pathToAnnounceData", e.Message);
            }
        }

        return true;
    }

    public bool UnsetAnnounceDataToVariable()
    {
        CPH.UnsetGlobalVar("stringAnnounceData", true);
        CPH.LogInfo("Данные анонса выгружены из стримербота.");
        return true;
    }

    public AnnounceData ParseAnnounceData()
    {
        string stringAnnounceData = CPH.GetGlobalVar<string>("stringAnnounceData").ToString();
        return JsonConvert.DeserializeObject<AnnounceData>(stringAnnounceData);
    }

    public bool GetAnnonceText()
    {
        SetAnnounceDataVariable();
        string announce = ParseAnnounceData().Annonce;
        if (announce == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле Annonce", "Провертье файл с анонсом");
            CPH.SetArgument("annonceText", "Заглушка");
        }
        else
        {
            CPH.SetArgument("annonceText", announce);
        }

        return true;
    }

    public bool GetGame()
    {
        SetAnnounceDataVariable();
        string game = ParseAnnounceData().Game;
        if (game == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле Game", "Провертье файл с анонсом");
            CPH.SetArgument("game", "Заглушка");
        }
        else
        {
            CPH.SetArgument("game", game);
        }

        return true;
    }

    public bool GetTranslationTitle()
    {
        SetAnnounceDataVariable();
        string translationTitle = ParseAnnounceData().TranslationTitle;
        if (translationTitle == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле TranslationTitle", "Провертье файл с анонсом");
            CPH.SetArgument("translationTitle", "Заглушка");
        }
        else
        {
            CPH.SetArgument("translationTitle", translationTitle);
        }

        return true;
    }

    public class AnnounceData
    {
        public string Annonce { get; set; }
        public string Game { get; set; }
        public string TranslationTitle { get; set; }
    }
}