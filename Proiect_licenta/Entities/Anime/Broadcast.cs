using System;

namespace Proiect_licenta.Entities.Anime;

public class Broadcast
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Day { get; set; }
    public string Time { get; set; }
    public string Timezone { get; set; }
    public string String { get; set; }
}
