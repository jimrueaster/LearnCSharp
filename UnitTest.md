
> 开发环境
* IDE: Rider
* .net 3.1

#### 安装依赖

```
dotnet add package NUnit --version 3.12.0
dotnet add package Microsoft.NET.Test.Sdk --version 16.4.0
dotnet add package NUnit3TestAdapter --version 3.15.1
```

#### 创建 Calculate.cs

```
namespace TodoApi
{
    public class Calculate
    {
        public static int Add(int a, int b) => a + b;

        public static int Sub(int a, int b) => a - b;

    }
}
```

#### 创建单元测试脚本 CalculateUnitTests.cs

##### CalculateUnitTests.cs 位置
```
...
├── Calculate.cs
├── Controllers
├── Tests
│   └── UnitTests
│       └── CalculateUnitTests.cs
...
```

##### CalculateUnitTests.cs 内容

```
using NUnit.Framework;

namespace TodoApi.Tests.UnitTests
{
    // 类名必须为 Tests，否则会认为无测试
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Test1()
        {
            Assert.AreEqual(4, Calculate.Add(2, 2));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(5, Calculate.Add(2, 2));
        }
    }
}
```

#### 执行测试

##### 所得的部分结果

```
TodoApi.Tests.UnitTests.Tests.Test2

  Expected: 5
  But was:  4
```
