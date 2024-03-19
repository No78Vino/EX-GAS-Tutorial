# EX-GAS 案例教程
## 前言
本案例教程，将一步一步的教会大家如何使用EX-GAS来制作一个简单的俯视2D弹幕游戏。

> 选择俯视2D弹幕游戏作为教学案例，是为了尽可能避开第三方插件（如行为树插件）。
> 
> 本案例只会用到2个第三方插件: Odin Inspector 和 EX-GAS。（实际上只有一个EX-GAS，Odin Inspector是EX-GAS的依赖）

---

好的，没有废话，直接开始。

## 1.创建项目
建议使用Unity 2022.3+开发。

打开Unity Hub，新建2D项目。项目名称随意。
![QQ20240319104753.png](DocumentImage%2FQQ20240319104753.png)

## 2.导入使用的插件
- Input System
  - 打开Unity Package Manager，Package搜索范围改为Unity Registry，搜索‘Input System’，点击Install安装。
    安装完成后，会提示重启Unity。
  - ![QQ20240319105034.png](DocumentImage%2FQQ20240319105034.png)
  - >虽然教学案例的工程很小，但是Input System用起来确实很方便。
- Odin Inspector
  - Odin Inspector为收费插件。开源项目是不会提供的，请自行解决来源。 
- EX-GAS
  - 还是在Unity Package Manager中，点击左上角的‘+’，选择‘Add package from git URL’。
  - 输入EX-GAS的git地址：https://github.com/No78Vino/gameplay-ability-system-for-unity.git?path=Assets/GAS
  - >如果出现访问失败，可以试着把梯子开/关，或者直接使用【镜像】地址：https://gitee.com/exhard/gameplay-ability-system-for-unity.git?path=Assets/GAS
  -  ![EX-GAS-Tutorial - SampleScene - Windows, Mac, Linux - Unity 2022.3.21f1 _DX11_ 2024_3_19 11_07_59.png](DocumentImage%2FEX-GAS-Tutorial%20-%20SampleScene%20-%20Windows%2C%20Mac%2C%20Linux%20-%20Unity%202022.3.21f1%20_DX11_%202024_3_19%2011_07_59.png)

## 3.准备工作
- 初始化EX-GAS
  - 在菜单栏找到EX-GAS -> Settings，点击打开设置面板。
    - ![QQ20240319111702.png](DocumentImage%2FQQ20240319111702.png)
  - 然后配置好脚本生成路径和配置文件路径。 只要路径合理即可，本教学案例建议使用默认路径。
    配置完成后，点击下方的绿色按钮，检查子目录和基础配置文件。基础配置文件指的是Tag，Attribute，AttributeSet的配置文件。
    - ![QQ20240319112142.png](DocumentImage%2FQQ20240319112142.png)

- 配置Input System
  - 在合适的目录创建Input配置的子文件夹。这里我选择了路径Assets/Config/Input。
  - ![QQ20240319134801.png](DocumentImage%2FQQ20240319134801.png)
  - 双击进入Input文件夹内，右键选择：Create->Input Actions。 创建一个InputActionAsset文件，命名为PlayerInput。
  - ![QQ20240319135046.png](DocumentImage%2FQQ20240319135046.png)
  - 双击打开PlayerInput，点击右上角的‘+’，添加一个ActionMap，命名为Player。
  - ![QQ20240319135207.png](DocumentImage%2FQQ20240319135207.png)
  - 双击中间的New action，重命名为Move。并把Action Type改为Value，Control Type改为Vector2。
  - ![QQ20240319142006.png](DocumentImage%2FQQ20240319142006.png)
  - 点击Move右侧加号，选择Add Up/Down/Left/Right Composite。然后分别设置对应的键位:W,A,S,D。
  - ![QQ20240319142147.png](DocumentImage%2FQQ20240319142147.png)
  - 再点击中间栏上方Actions右侧的‘+’，添加一个新的Action，命名为Fire。并把Action Type改为Button，Control Type改为Button。
    然后把Fire的键位设置为Left Button。
  - ![QQ20240319142632.png](DocumentImage%2FQQ20240319142632.png)
  - 再点击中间栏上方Actions右侧的‘+’，添加一个新的Action，命名为Sweep。并把Action Type改为Button，Control Type改为Button。
    然后把Fire的键位设置为Right Button。
  - ![QQ20240319142854.png](DocumentImage%2FQQ20240319142854.png)
  - 最后，点击Save Asset。选中PlayerInput，勾选Generate C# Class，设置C#生成路径为Assets/Config/Input/PlayerInput， 点击Apply，生成C#文件。
  -  ![QQ20240319143346.png](DocumentImage%2FQQ20240319143346.png)
  
## 4.制作游戏场景
直接使用默认的SampleScene作为场景。
简单铺设一个封闭的场景，用于测试角色的移动和射击，添加5个Square拉伸成地板和墙面。
其中Background为地板，无碰撞；Wall元素持有碰撞盒。

![QQ20240319162512.png](DocumentImage%2FQQ20240319162512.png)

## 5.创建UI
UI从简，不使用图片资源。只使用Text，Image，Button制作UI。
UI只有两部分：游戏主界面的玩家状态栏， 结算界面。

排版如下：图中HP,Score,SweepCD为Text；StateBar,ResultWindow为纯色Image；ButtonRetry为Button

![QQ20240319170027.png](DocumentImage%2FQQ20240319170027.png)

![QQ20240319170111.png](DocumentImage%2FQQ20240319170111.png)
### 5.1 UI脚本的编写
> 因为案例的UI足够简单，所以UI的逻辑会很粗暴。

首先在Assets/Scripts目录下创建UIManager脚本。然后将其挂载到Scene的Canvas物体上。

![QQ20240319171312.png](DocumentImage%2FQQ20240319171312.png)

接下来编写UIManager逻辑。
- 把几个需要用到的UI组件进行序列化
  - > [SerializeField] private Text hp;
- UIManager为了方便调用，我们为他添加静态单例
  - ```
    private static UIManager _instance;
    public static UIManager Instance => _instance;
    private void Awake(){_instance = this;}
    ``` 
- 暴露有可能发生变化的UI组件的修改接口。
  - 比如： 
    > public void SetHp(int hpValue){ hp.text = $"HP: {hpValue}/100"; } 
- 【再来一局】的接口
  - > public void Retry(); //具体逻辑下文会实现

最后UIManager的脚本如下：
```
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text hp;
    [SerializeField] private Text score;
    [SerializeField] private Text sweepCd;
    
    [SerializeField] private GameObject resultWindow;
    [SerializeField] private Text resultWindowScore;

    private static UIManager _instance;
    public static UIManager Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void SetHp(int hpValue)
    {
        hp.text = $"HP: {hpValue}/100";
    }
    
    public void SetScore(int scoreValue)
    {
        score.text = $"Score: {scoreValue}";
        resultWindowScore.text = $"Score: {scoreValue}";
    }

    public void SetSweepCd(float cd)
    {
        sweepCd.text = $"横扫CD: {cd}";
    }

    public void ShowResultWindow()
    {
        resultWindow.SetActive(true);
    }
    
    public void HideResultWindow()
    {
        resultWindow.SetActive(false);
    }

    public void Retry()
    {
        // TODO 重置游戏状态，下文会继续实现
    }
}
```
编辑完后，记得把对应的UI组件拖到UIManager的对应字段上。
- ![QQ20240319174137.png](DocumentImage%2FQQ20240319174137.png)
- ![QQ20240319174201.png](DocumentImage%2FQQ20240319174201.png)

UI的内容先告一段落，后续还会沿着案例开发顺序对UIManager进行补充。

---
## 6.GameManager && Launcher
### 6.1 GameManager
GameManager是统筹游戏运行的管理类，一般会比较复杂。
但是鉴于本案例比较简单，所以GameManager的逻辑会比较直接，暴力。（OMO）

还是和UIManager一样在Assets/Scripts目录下创建脚本GameManager，但GameManager不继承MonoBehavior。
- GameManager也为了方便调用，我们为他添加静态单例。
  - ```
    private static GameManager _intance;
    public static GameManager Instance
    {
        get
        {
            if (_intance == null) _intance = new GameManager();
            return _intance;
        }
    }
    ```
- GameManager控制游戏的开始和结束。
  - ```
    public enum GameState
    {
        Prepare,
        Running,
        End
    }
    private GameState _gameState;
    ```

## 7.