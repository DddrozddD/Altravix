namespace Altavix.Domain;

public class ProductEntity
{
    public Guid Id {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public int Price {get; set;}
    public int PriceCoin {get; set;}
    public Guid UserCreatorId {get; set;}
    public UserEntity UserCreator {get; set;}
    public List<CategoryEntity> Categories{get; set;}
}