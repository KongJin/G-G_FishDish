



public interface ILevelUpAble
{
    void LevelUp(int minPoint, int MaxPoint);
}
public class Spec : ILevelUpAble
{
    float _size;
    float _speed;

    public void LevelUp(int minPoint, int MaxPoint)
    {
        if (MaxPoint < minPoint)
            return;
        _size = UnityEngine.Random.Range(minPoint, MaxPoint);
        _speed = UnityEngine.Random.Range(minPoint, MaxPoint);
    }

    public Spec() { _size = 0; _speed = 0; }
}
