//創建型、建立型
namespace DesignPatternNet6.Creational;

/// <summary>
/// 單例模式 線程安全
/// </summary>
/// sealed 避免被外部繼承
public sealed class Singleton
{
    public static readonly Singleton Instance = new Singleton();
    /// private 避免被外部建構
    private Singleton() { }
}

/// <summary>
/// 單例模式 多線程不安全
/// </summary>
/// sealed 避免被外部繼承
public sealed class SingletonLazy
{
    private static SingletonLazy _instance;

    /// private 避免被外部建構
    private SingletonLazy() { }

    public static SingletonLazy GetInstance()
    {
        if (_instance == null)//延遲初始化
        {
            _instance = new SingletonLazy();
        }
        return _instance;
    }
}

/// <summary>
/// 單例模式 線程安全
/// </summary>
/// sealed 避免被外部繼承
public sealed class DoubleLock
{
    /// volatile 避免多線程時編譯器調整實體化順序另 DoubleLock 多實體產生
    private static volatile DoubleLock _instance;
    private static readonly object lockHelper = new Object();

    /// private 避免被外部建構
    private DoubleLock() { }

    public static DoubleLock Instance
    {
        get
        {
            if (_instance == null)//避免不必要的同步
            {
                lock (lockHelper)//lock 檢查
                {
                    if (_instance == null)//延遲初始化
                        _instance = new DoubleLock();
                }
            }
            return _instance;
        }
    }
}
