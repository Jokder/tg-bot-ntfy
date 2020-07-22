## Telegram bot 傳訊息工具

一個可以通過控制台界面和http訪問通過telegram的bot傳送訊息的小工具。

## 準備工作

* 通過[BotFather](https://t.me/botfather 'BotFather')請求一個bot.
* 通過[useridbot](https://telegram.me/userinfobot 'useridbot')得到自己telegram帳號的id
* 配置文件範本（config.ini）
[config.ini](https://github.com/Jokder/tg-bot-ntfy/blob/master/Main/config.ini 'config file sample')
``` ini
[global]
;是否使用代理
use_proxy=no

[bot]
;通過BotFather獲得的token.
token=<通過BotFather獲得的token>

[web_api]
;以web服務方式啟動時，監聽位址
listen=0.0.0.0
;以web服務偵聽埠
port=8080
;可以給web調用設置一個簡單的令牌
key=<令牌>

[proxy]
;使用代理的類型（http/socks5）
type=http
;代理的伺服器位址
host=127.0.0.1
;代理埠
port=8082
;是否需要認證
auth=no
;代理認證用戶名
username=
;代理認證密碼
password=
```


## 啟動

``` shell
tgntf
    --help #幫助
    [cli|serve] #cli作為控制台界面使用，serve以web服務方式啟動
        -c --config #配置文件路徑
        -m --message #傳送訊息的內容
        -b --debug #顯示調試信息
        -o --to #傳送訊息的對象（目前只支援到用戶的id）
```

## 開源許可

MIT License: http://adampritchard.mit-license.org/ or see the [LICENSE](https://github.com/Jokder/tg-bot-ntfy/blob/master/LICENSE 'LICENSE') file.