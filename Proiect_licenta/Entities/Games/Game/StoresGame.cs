namespace Disertatie_backend.Entities.Games.Game
{
    public class StoresGame
    {
#nullable enable
        public int? Id { get; set; }
        public string? Url { get; set; }
        public StoreGame? Store { get; set; }
    }
}
