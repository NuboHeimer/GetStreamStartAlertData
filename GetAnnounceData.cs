///----------------------------------------------------------------------------
///   Module:       Get stream annonce data
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      1.0.1
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

    public bool GetVkPlayLiveLink()
    {
        SetAnnounceDataVariable();
        string vkplLink = ParseAnnounceData().VKPlayLive.Link;
        if (vkplLink == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле VKPlayLive.Link", "Провертье файл с анонсом");
            CPH.SetArgument("vkplLink", "Заглушка");
        }
        else
        {
            CPH.SetArgument("vkplLink", vkplLink);
        }

        return true;
    }

    public bool GetVkPlayLiveOnlineGoal()
    {
        SetAnnounceDataVariable();
        string vkplOnilneGoal = ParseAnnounceData().VKPlayLive.Goals.Online;
        if (vkplOnilneGoal == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле VKPlayLive.Goals.Online", "Провертье файл с анонсом");
            CPH.SetArgument("vkplOnilneGoal", "Заглушка");
        }
        else
        {
            CPH.SetArgument("vkplOnilneGoal", vkplOnilneGoal);
        }

        return true;
    }

    public bool GetTwitchLink()
    {
        SetAnnounceDataVariable();
        string twitchLink = ParseAnnounceData().Twitch.Link;
        if (twitchLink == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле Twitch.Link", "Провертье файл с анонсом");
            CPH.SetArgument("twitchLink", "Заглушка");
        }
        else
        {
            CPH.SetArgument("twitchLink", twitchLink);
        }

        return true;
    }

    public bool GetTwitchFollowersGoal()
    {
        SetAnnounceDataVariable();
        string twitchFollowersGoal = ParseAnnounceData().Twitch.Goals.Followers;
        if (twitchFollowersGoal == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле Twitch.Goals.Followers", "Провертье файл с анонсом");
            CPH.SetArgument("twitchFollowersGoal", "Заглушка");
        }
        else
        {
            CPH.SetArgument("twitchFollowersGoal", twitchFollowersGoal);
        }

        return true;
    }

    public bool GetYouTubeLink()
    {
        SetAnnounceDataVariable();
        string youTubeLink = ParseAnnounceData().YouTube.Link;
        if (youTubeLink == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле YouTube.Link", "Провертье файл с анонсом");
            CPH.SetArgument("youTubeLink", "Заглушка");
        }
        else
        {
            CPH.SetArgument("youTubeLink", youTubeLink);
        }

        return true;
    }

    public bool GetYouTubeFollowersGoal()
    {
        SetAnnounceDataVariable();
        string youTubeFollowersGoal = ParseAnnounceData().YouTube.Goals.Followers;
        if (youTubeFollowersGoal == null)
        {
            CPH.ShowToastNotification("Не удалось найти поле YouTube.Goals.Followers", "Провертье файл с анонсом");
            CPH.SetArgument("youTubeFollowersGoal", "Заглушка");
        }
        else
        {
            CPH.SetArgument("youTubeFollowersGoal", youTubeFollowersGoal);
        }

        return true;
    }

    public class AnnounceData
    {
        public string Annonce { get; set; }
        public string Game { get; set; }
        public string TranslationTitle { get; set; }
        public VKPlayLiveData VKPlayLive { get; set; }
        public TwitchData Twitch { get; set; }
        public YouTubeData YouTube { get; set; }
    }

    public class VKPlayLiveData
    {
        public string Link { get; set; }
        public GoalsData Goals { get; set; }
    }

    public class TwitchData
    {
        public string Link { get; set; }
        public GoalsData Goals { get; set; }
    }

    public class YouTubeData
    {
        public string Link { get; set; }
        public GoalsData Goals { get; set; }
    }

    public class GoalsData
    {
        public string Online { get; set; }
        public string Followers { get; set; }
    }
}