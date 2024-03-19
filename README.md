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


## 5.创建UI

## 6.使用EX-GAS

## 7.