//創建型、建立型
namespace DesignPatternNet6.Creational;

// 数据库类会对`getInstance（获取实例）`方法进行定义以让客户端在程序各处
// 都能访问相同的数据库连接实例。
public class Database
{
    // 保存单例实例的成员变量必须被声明为静态类型。
    private static Database instance;
    // 单例的构造函数必须永远是私有类型，以防止使用`new`运算符直接调用构
    // 造方法。
    private Database()
    {
        // 部分初始化代码（例如到数据库服务器的实际连接）。
        // ……
    }

    // 用于控制对单例实例的访问权限的静态方法。
    public static Database GetDatabase()
    {
        if (instance == null)
        {
            if (instance == null)
            {
                // 确保在该线程等待解锁时，其他线程没有初始化该实例。
                instance = new Database();
            }
        }
        return instance;
    }


    // 最后，任何单例都必须定义一些可在其实例上执行的业务逻辑。
    public void Query(string sql)
    {
        // 比如应用的所有数据库查询请求都需要通过该方法进行。因此，你可以
        // 在这里添加限流或缓冲逻辑。
        // ……
    }
}

class Application
{
    public void main()
    {
        Database foo = Database.GetDatabase();
        foo.Query("SELECT ……");
        // ……
        Database bar = Database.GetDatabase();
        bar.Query("SELECT ……");
        // 变量 `bar` 和 `foo` 中将包含同一个对象。
    }
}



