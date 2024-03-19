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
  -  还是在Unity Package Manager中，