///----------------------------------------------------------------------------
///   Module:       Get stream annonce data
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      personal
///----------------------------------------------------------------------------
using System;
using System.IO;

public class CPHInline
{
    public bool SetAnnouncementTextVariable()
    {
        try
        {
            string pathToAnnouncementText = args["pathToAnnouncementText"].ToString();
            string stringAnnouncementText = File.ReadAllText(pathToAnnouncementText);
            CPH.SetGlobalVar("stringAnnouncementText", stringAnnouncementText, true);
            CPH.LogInfo("Данные анонса загружены в стримербот.");
        }
        catch (Exception e)
        {
            CPH.LogError("Не удалось получить аргумент pathToAnnouncementText. " + e.Message);
            CPH.ShowToastNotification("Не удалось получить аргумент pathToAnnouncementText", e.Message);
        }

        return true;
    }

    public bool UnsetAnnounceDataToVariable()
    {
        CPH.UnsetGlobalVar("stringAnnouncementText", true);
        CPH.LogInfo("Данные анонса выгружены из стримербота.");
        return true;
    }
}