## Telegram bot 发消息工具

一个可以通过控制台和http接口（暂不支持）使用telegram的bot推送消息的小工具。

## 准备工作

* 通过[BotFather](https://t.me/botfather 'BotFather')申请一个bot.
* 通过[useridbot](https://telegram.me/userinfobot 'useridbot')得到自己telegram帐号的id
* 配置文件范例（config.ini）
[config.ini](https://github.com/Jokder/tg-bot-ntfy/blob/master/Main/config.ini 'config file sample')
``` ini
[global]
;是否使用代理
use_proxy=yes

[bot]
;通过BotFather获得的token.
token=<通过BotFather获得的token>

[web_api]
;以web服务方式启动时，监听的地址
listen=0.0.0.0
;以web服务方式启动时，监听的端口
port=8080
;可以给web调用设置一个简单的令牌
key=<令牌>

[proxy]
;使用代理的类型（http/socks5）
type=http
;代理的服务器
host=127.0.0.1
;代理服务的端口
port=8082
;是否需要认证
auth=no
;代理认证用户名
username=
;代理认证密码
password=
```


## 启动

``` shell
tgntf 
    --help              #帮助
    [cli|web]           #cli作为控制台工具使用，web以web服务方式启动
        -c --config     #配置文件路径
        -m --message    #发送消息的内容
        -b --debug      #显示调试信息
        -o --to         #发送消息的对象（目前只支持id）
```

## 开源许可

MIT License: http://adampritchard.mit-license.org/ or see the [LICENSE](https://github.com/Jokder/tg-bot-ntfy/blob/master/LICENSE 'LICENSE') file.