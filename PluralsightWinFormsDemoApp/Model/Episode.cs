namespace PluralsightWinFormsDemoApp.Model
{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
        public string AudioFile { get; set; }
        public string Guid { get; set; }
        public bool IsNew { get; set; }
        public bool IsFavourite { get; set; }
        public string[] Tags { get; set; }
        public string Notes { get; set; }
        public int Rating { get; set; }
        public float[] Peaks { get; set; }
    }
}