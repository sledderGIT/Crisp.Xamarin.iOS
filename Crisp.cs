using System;
using System.Collections.Generic;
using Foundation;
using Newtonsoft.Json;

namespace Crisp.iOS
{
    public static class Crisp
    {
        public static readonly CrispMain Instance = new CrispMain();
    }
    
    public class CrispMain: NSObject
    {
        public string WebsiteId { get; set; }
        public string TokenId { get; set; }
        public string Locale { get; set; }

        public SessionInterface Session { get; set; }

        public UserInterface User { get; set; }

        public void Initialize(string websiteId)
        {
            Session = new SessionInterface();
            User = new UserInterface();
            WebsiteId = websiteId;

            if (string.IsNullOrEmpty(WebsiteId))
            {
                WebsiteId = websiteId;
            }

            if (TokenId == null)
            {
                TokenId = "";
            }
        
            if (Locale == null)
            {
                Locale = "";
            }
        }
    }
    
    
    public class SessionInterface : NSObject {
        
        private string _segment;

        public string Segment
        {
            get => _segment;
            set
            {
                _segment = value; 
                CrispView.Execute("window.$crisp.push([\"set\", \"session:segments\", [[\"" + value + "\"]]])");
            }
        }

        private Dictionary<string, object> _data;

        public Dictionary<string, object> Data
        {
            get => _data;
            set
            {
                _data = value;
                var pendingData = "";
                var index = 0;
                foreach (var (key, o) in value)
                {
                    pendingData = index == 0 ? $"['{key}','{o}']" : 
                        $"{pendingData},['{key}','{o}']";
                    index++;
                }
                CrispView.Execute("window.$crisp.push([\"set\", \"session:data\", [["+pendingData+"]]])");
            }
        }

        public void PushEvent(string name, Dictionary<string, object> data, string color = "blue")
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(data);
                CrispView.Execute($"window.$crisp.push([\"set\", \"session:event\", [[['{name}', {jsonData}, '{color}']]]])");
            }
            catch (Exception e)
            {
                
            }
        }

        public void Reset()
        {
            CrispView.Execute("window.$crisp.push([\"do\", \"session:reset\", [true]])");
            CrispView.IsLoaded = false;
            CrispView.Load();
        }
    }

    public class UserInterface : NSObject
    {
        private string _email;

        public string Email
        {
            get => _email;
            set
            {
                _email = value; 
                CrispView.Execute($"window.$crisp.push([\"set\", \"user:email\", [\"{value}\"]])");
            }
        }

        private string _avatar;

        public string Avatar
        {
            get => _avatar;
            set
            {
                _avatar = value; 
                CrispView.Execute($"window.$crisp.push([\"set\", \"user:avatar\", [\"{value}\"]])");
            }
        }

        private string _nickname;

        public string Nickname
        {
            get => _nickname;
            set
            {
                _nickname = value;
                CrispView.Execute(script: $"window.$crisp.push([\"set\", \"user:nickname\", [\"{value}\"]])");
            }
        }

        private string _phone;

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value; 
                CrispView.Execute(script: $"window.$crisp.push([\"set\", \"user:phone\", [\"{value}\"]])");
            }
        }
    }
}