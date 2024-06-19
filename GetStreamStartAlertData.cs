///----------------------------------------------------------------------------
///   Module:       Stream start annonce to discord
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      0.1.0
///----------------------------------------------------------------------------
using System;
using System.IO;
using Newtonsoft.Json;

public class CPHInline
{
    public AlertData GetAllStreamStartAlertData()
    {
        string pathToAlertText = args["pathToAlertText"].ToString();
        string alertData = File.ReadAllText(pathToAlertText);
        var data = JsonConvert.DeserializeObject<AlertData>(alertData);
        return data;
    }

    public bool GetAnnonceText()
    {
        CPH.SetArgument("annonceText", GetAllStreamStartAlertData().Annonce);
        return true;
    }
    public bool GetGame()
    {
        CPH.SetArgument("game", GetAllStreamStartAlertData().Game);
        return true;
    }
    public bool GetTranslationTitle()
    {
        CPH.SetArgument("translationTitle", GetAllStreamStartAlertData().TranslationTitle);
        return true;
    }
    public bool GetVkPlayLiveLink()
    {
        CPH.SetArgument("vkplLink", GetAllStreamStartAlertData().VKPlayLive.Link);
        return true;
    }
    public bool GetVkPlayLiveOnlineGoal()
    {
        CPH.SetArgument("vkplOnilne", GetAllStreamStartAlertData().VKPlayLive.Goals.Online);
        return true;
    }
    public bool GetTwitchFollowersGoal()
    {
        CPH.SetArgument("twitchFollowers", GetAllStreamStartAlertData().Twitch.Goals.Followers);
        return true;
    }
    public bool GetYouTubeFollowersGoal()
    {
        CPH.SetArgument("youTubeFollowers", GetAllStreamStartAlertData().YouTube.Goals.Followers);
        return true;
    }

    public class AlertData
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