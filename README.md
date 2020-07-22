[中文说明](https://github.com/Jokder/tg-bot-ntfy/blob/master/README-ZHCN.md '中文说明')

## Telegram bot notify message tool

a simple tool for sending message to specify user via bot.

## First

* chat with [BotFather](https://t.me/botfather 'BotFather') to create a bot.
* chat with [useridbot](https://telegram.me/userinfobot 'useridbot') to get yourself telegram account id
* config file sample（config.ini）
[config.ini](https://github.com/Jokder/tg-bot-ntfy/blob/master/Main/config.ini 'config file sample')
``` ini
[global]
;enable proxy
use_proxy=yes

[bot]
;bot token the BotFather told you.
token=<token from botfather>

[web_api]
;run as a web service,listening address
listen=0.0.0.0
;listening port
port=8080
;a simple api token
key=<token>

[proxy]
;global proxy type（http/socks5）
type=http
;proxy server address
host=127.0.0.1
;proxy service port
port=8082
;need auth
auth=no
;proxy auth username
username=
;proxy auth password
password=
```


## usage

``` sh
tgntf 
    --help              #help
    [cli|web]           #cli:run as cli tool，web:run as web service
        -c --config     #config file path
        -m --message    #message to sending
        -b --debug      #show debug info
        -o --to         #telegram user id for sending to
```

## license

MIT License: http://adampritchard.mit-license.org/ or see the [LICENSE](https://github.com/Jokder/tg-bot-ntfy/blob/master/LICENSE 'LICENSE') file.