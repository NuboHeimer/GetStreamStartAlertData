///----------------------------------------------------------------------------
///   Module:       Stream start annonce to discord
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      0.1.1
///----------------------------------------------------------------------------
using System;
using System.IO;
using Newtonsoft.Json;

public class CPHInline
{
    public AlertData ParseAllStreamStartAlertData()
    {
        string pathToAlertText = args["pathToAlertText"].ToString();
        string alertData = File.ReadAllText(pathToAlertText);
        var data = JsonConvert.DeserializeObject<AlertData>(alertData);
        return data;
    }
    public bool GetAllStreamStartAlertData()
    {
        var data = ParseAllStreamStartAlertData();

        CPH.SetArgument("annonceText", data.Annonce);
        CPH.SetArgument("game", data.Game);
        CPH.SetArgument("translationTitle", data.TranslationTitle);
        CPH.SetArgument("vkplLink", data.VKPlayLive.Link);
        CPH.SetArgument("vkplOnilne", data.VKPlayLive.Goals.Online);
        CPH.SetArgument("twitchLink", data.Twitch.Link);
        CPH.SetArgument("twitchFollowers", data.Twitch.Goals.Followers);
        CPH.SetArgument("youTubeLink", data.YouTube.Link);
        CPH.SetArgument("youTubeFollowers", data.YouTube.Goals.Followers);
        return true;
    }
    public bool GetAnnonceText()
    {
        CPH.SetArgument("annonceText", ParseAllStreamStartAlertData().Annonce);
        return true;
    }
    public bool GetGame()
    {
        CPH.SetArgument("game", ParseAllStreamStartAlertData().Game);
        return true;
    }
    public bool GetTranslationTitle()
    {
        CPH.SetArgument("translationTitle", ParseAllStreamStartAlertData().TranslationTitle);
        return true;
    }
    public bool GetVkPlayLiveLink()
    {
        CPH.SetArgument("vkplLink", ParseAllStreamStartAlertData().VKPlayLive.Link);
        return true;
    }
    public bool GetVkPlayLiveOnlineGoal()
    {
        CPH.SetArgument("vkplOnilne", ParseAllStreamStartAlertData().VKPlayLive.Goals.Online);
        return true;
    }
        public bool GetTwitchLink()
    {
        CPH.SetArgument("twitchLink", ParseAllStreamStartAlertData().Twitch.Link);
        return true;
    }
    public bool GetTwitchFollowersGoal()
    {
        CPH.SetArgument("twitchFollowers", ParseAllStreamStartAlertData().Twitch.Goals.Followers);
        return true;
    }
            public bool GetYouTubeLink()
    {
        CPH.SetArgument("youTubeLink", ParseAllStreamStartAlertData().YouTube.Link);
        return true;
    }
    public bool GetYouTubeFollowersGoal()
    {
        CPH.SetArgument("youTubeFollowers", ParseAllStreamStartAlertData().YouTube.Goals.Followers);
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