namespace ProjektWeb.Models
{
    public class Album
    {
    
            public int AlbumId { get; set; }
            public string Name { get; set; } = "";

            public string Artist { get; set; } = "";

            public DateTime Created { get; set; }

            public List<Song> Songs { get; set; }

}
}
