﻿namespace ProjektWeb.Models
{

    public class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; } = "";

        public string Artist { get; set; } = "";

        public DateTime Released { get; set; }

    }
}
