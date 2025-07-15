
public class Define
{
   public enum HeroRating
    {
        Common,
        Normal,
        Epic,
        Legend,
    }

    public enum HeroType
    {
        Close,
        Medium,
        Long,
    }
    public enum UIEvent
    {
        Click,
        Press,
    }
    public enum SceneType
    {
        Unknown,
        MainScene,
        GameScene,
        
    }
    public enum TileType
    {
        Wall,
        Path,
        Install,
        Final,
        Start
    }
    public enum Direction
    {
        None, 
        Up, 
        Down, 
        Left, 
        Right

    }
    public enum State
    {
        Idle,
        Attack,
    }
    public enum AtkArange
    {
        Aoe,
        Single,
    }
    public enum HeroAbility
    {
        Money,
        Atkker,
    }
    public enum ProductType
    {
        Card,
        Goods,
    }
    public enum PayType
    {
        Gold,
        Gem
    }
    public enum SkillType
    {
        Single,
        Plural
    }
    public const int HERO_COUNT = 10;
    public const int GAME_LIST_COUNT = 8;
}
