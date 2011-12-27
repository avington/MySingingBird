using System;
using System.Collections.Generic;
using MySingingBird.Entities;

namespace MySingingBird.Core.Entities
{
    public class TwitterUser
    {
        public bool IsTranslator { get; set; }
        public bool IsDefaultProfile { get; set; }
        public bool IsGeoEnabled { get; set; }
        public string ProfileBackgroundColor { get; set; }
        public bool IsProtected { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string ProfileBackImageUrl { get; set; }
        public string ProfileSideBackgroundColor { get; set; }
        public int ListedCount { get; set; }
        public string Notifications { get; set; }
        public long UtcOffset { get; set; }
        public int ProfileFriendCount { get; set; }
        public string Description { get; set; }
        public int Following { get; set; }
        public bool IsVerified { get; set; }
        public string ProfileSidebarBorderColor { get; set; }
        public int ProfileFollowerCount { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool IsContributorsEnabled { get; set; }
        public string ProfileImageUrlHttps { get; set; }
        public ProfileStatus Status { get; set; }
        public bool IsProfileUsingBackgroundImage { get; set; }
        public int FavoritedCount { get; set; }
        public string Location { get; set; }
        public string IdString { get; set; }
        public bool IsProfileDefaultImage { get; set; }
        public bool ShowAllInlineMedia { get; set; }
        public string ProfileTextColor { get; set; }
        public string ProfileUrl { get; set; }
        public string TimeZone { get; set; }
        public string PublicLinkColor { get; set; }
        public string Id { get; set; }
        public string  Language { get; set; }
        public string ScreenName { get; set; }

        public List<string> Indices { get; set; }
    }
}