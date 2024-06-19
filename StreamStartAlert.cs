///----------------------------------------------------------------------------
///   Module:       Stream start annonce to discord
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      1.0.2
///----------------------------------------------------------------------------
using System;
using System.IO;
using Newtonsoft.Json;

public class CPHInline
{
    public bool Execute()
    {
        string message = "";
        string roleForPing = args["roleForPing"].ToString();
        string pathToAlertText = args["pathToAlertText"].ToString();
        string twitchFollowerCount = args["followerCount"].ToString();
        string youTubeFollowerCount = args["youTubeFollowerCount"].ToString();
        string alertData = File.ReadAllText(pathToAlertText);
        var data = JsonConvert.DeserializeObject<AlertData>(alertData);
        message = message + roleForPing + "\n\n" + data.Annonce + "\n\n**Игра —" + data.Game + "**\n\n_" + data.TranslationName + "_\n\n" + data.VKPlayLive.Link + "\n```\nЦели:\n  ● Средний онлайн — " + data.VKPlayLive.Goals.Online + "\n```\n\n" + data.Twitch.Link + "\n```\nЦели:\n  ● Фолловеры — " + data.Twitch.Goals.Followers.Replace("twitchFollowerCount", twitchFollowerCount) + "\n```\n\n" + data.YouTube.Link + "\n```\nЦели:\n  ● Фолловеры — " + data.YouTube.Goals.Followers.Replace("youTubeFollowerCount", youTubeFollowerCount) + "\n```\n\n";
        message = message.Replace("followerCount", args["followerCount"].ToString());
        CPH.LogInfo(message);
        CPH.SetArgument("message", message);
        return true;
    }

    public class AlertData
    {
        public string Annonce { get; set; }
        public string Game { get; set; }
        public string TranslationName { get; set; }
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