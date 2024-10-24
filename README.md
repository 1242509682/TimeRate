# TimeRate 时间加速插件

- 作者: 羽学
- 出处: 无
- 这是一个Tshock服务器插件，主要用于:使用指令修改时间加速

## 更新日志

```
v1.0.0
给修改时间流速加入了指令控制配置项的功能
```

## 指令

| 语法                             | 别名  |       权限       |                   说明                   |
| -------------------------------- | :---: | :--------------: | :--------------------------------------: |
| /times  | /时间加速 |   times.admin    |    时间加速指令菜单    |
| /times on | /时间加速 on |   times.admin    |    开启时间加速    |
| /times off  | /时间加速 off |   times.admin    |    关闭时间加速    |
| /times set | /times s |   times.admin    |    设置加速速率    |

---
配置注意事项
---
1.`开关`可以用`/times on`和`/times off`来控制 
  
2.`速率`默认加速为60`附魔日晷的速度` 

## 配置

```json
{
  "开关": false,
  "速率": 60
}
```
## 反馈
- 优先发issued -> 共同维护的插件库：https://github.com/Controllerdestiny/TShockPlugin
- 次优先：TShock官方群：816771079
- 大概率看不到但是也可以：国内社区trhub.cn ，bbstr.net , tr.monika.love