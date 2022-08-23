namespace Core.Persistence.Repositories;

public class Entity
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public long CreatorUserId { get; set; }
    public DateTime ModificationDate  { get; set; }
    public long ModificatorUserId { get; set; }
    public Entity()
    {
        CreationDate = DateTime.UtcNow;

    }

    public Entity(long id) : this()
    {
        Id = id;
        //CreationDate = DateTime.UtcNow;
    }
    public Entity(long id,long modificatorUserId) : this()
    {
        Id = id;
        ModificatorUserId = modificatorUserId;
        //ModificationDate= DateTime.UtcNow;
       
    }
}