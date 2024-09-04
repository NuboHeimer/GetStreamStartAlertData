///----------------------------------------------------------------------------
///   Module:       Get stream annonce data
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      1.0.0
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
            //#TODO навесить try catch с виндовым алёртом в случае ошибки чтения пути до файла или чтения самого файла.
            string pathToAnnounceData = args["pathToAnnounceData"].ToString();
            string stringAnnounceData = File.ReadAllText(pathToAnnounceData);
            // announceData announceData = JsonConvert.DeserializeObject<announceData>(stringAnnounceData);
            CPH.SetGlobalVar("stringAnnounceData", stringAnnounceData, true);
            CPH.LogInfo("Данные анонса загружены в стримербот.");
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
        CPH.SetArgument("annonceText", ParseAnnounceData().Annonce);
        return true;
    }

    public bool GetGame()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("game", ParseAnnounceData().Game);
        return true;
    }

    public bool GetTranslationTitle()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("translationTitle", ParseAnnounceData().TranslationTitle);
        return true;
    }

    public bool GetVkPlayLiveLink()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("vkplLink", ParseAnnounceData().VKPlayLive.Link);
        return true;
    }

    public bool GetVkPlayLiveOnlineGoal()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("vkplOnilne", ParseAnnounceData().VKPlayLive.Goals.Online);
        return true;
    }

    public bool GetTwitchLink()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("twitchLink", ParseAnnounceData().Twitch.Link);
        return true;
    }

    public bool GetTwitchFollowersGoal()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("twitchFollowers", ParseAnnounceData().Twitch.Goals.Followers);
        return true;
    }

    public bool GetYouTubeLink()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("youTubeLink", ParseAnnounceData().YouTube.Link);
        return true;
    }

    public bool GetYouTubeFollowersGoal()
    {
        SetAnnounceDataVariable();
        CPH.SetArgument("youTubeFollowers", ParseAnnounceData().YouTube.Goals.Followers);
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