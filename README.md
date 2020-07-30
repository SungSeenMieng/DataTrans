
 # DataTrans仪器通信中继程序说明文档
 # V3.6.0.0

 

功能介绍
DataTrans仪器通信中继程序提供仪器数据传输中继功能，在仪器与LIS服务器/串口服务器间作通信数据中继监控、处理功能。此外提供远程监控及调试功能。

程序基础使用
 
程序文件只有一个exe可执行文件，首次运行会在同目录下生成转换条目数据库文件与日志文件夹。
-Config.mdb
-logs
 

程序包含三个页面：
-主页面：数据监控以及连接状态监控
-设置页面：配置程序的各种设置
-数据处理页面：将中继的数据进行处理后中继转发

打开仪器数据转发程序，显示的是主页面：
 

点击【设置】，或者右下角图标右键点击【程序配置页面】打开设置页面：
 

点击【数据编辑器】或右下角图标右键点击【数据编辑器】打开数据处理页面：
 



 
主页面
主页面点击【实时日志】显示主页面的日志框：
 
【LIS日志】展示从LIS连接端发送的数据
【仪器日志】展示从仪器连接端发送的数据

 
当仪器连接/LIS连接成功建立后，波浪形指示器会变成绿色，并且连接地址显示仪器/LIS端连接地址。

 
程序设置页面
 
设置页面提供丰富的设置功能：

基础设置：
【仪器名称】-设置在仪器的显示界面的文字展示
【程序名称】-关联程序窗口名称
【快捷方式名称】-自动生成的桌面快捷方式名称
【LIS连接端口】-LIS连接启动的TCP服务端端口
【双击任务栏图标打开】-设置双击右下角任务栏图标显示的页面
【调试端口号】-远程调试TCP端口（远程调试功能见文档<远程调试功能介绍>）
【调试端口密码】-远程调试TCP密码（远程调试功能见文档<远程调试功能介绍>）
【清理缓存计时器】-程序自动清理内存占用计时时间
【数据编辑器变更响应计时器】-更改数据编辑器内容后应用更改的时间
【单次接收发送缓存区大小】-如果发现数据传输不全可调大
【日志保留天数】-logs文件夹下日志保留天数，超过的自动删除

*以上设置需要点击【保存】才可更改成功

【还原更改】-还原初始程序设置
【导出设置】-会把当前程序设置导出成文件
【导入设置】-可以把导出的设置文件导入恢复设置

仪器连接设置：
【网口客户端】-仪器以TCP客户端方式主动连接中继程序，程序所开TCP监听端口
【网口服务端】-仪器为TCP服务器，终极程序作为客户端主动连接仪器，设有重连计时器
【读文件-直连LIS设置】-可以填写.cls的M接口直接填写，填写仪器ID号，cache用户后点击保存用户，启动文件数据直接传输到LIS调用，仅供调试使用。
 
【读文件-文件路径/写文件路径】-设置读取、写入文件路径
【读文件-文件后缀/写文件后缀】-设置读取、写入文件后缀
【读文件-读取计时器】-读取文件计时
【读文件-是否保留文件】-打开后读取文件不会删除
*注意：不启用直接传输到LIS功能的时候读取的文件内容及文件名会使用TCP从LIS连接转发，写文件时，LIS使用TCP发送的内容将最后一行作为文件名写入文件。
【串口】-使用运行终极程序电脑的串口来连接仪器，即软件虚拟盒子
【波特率】-在下拉框找不到需要的波特率值时可手动输入后点击新增自定

*注意：仪器连接设置更改实时生效，确保设置无误后再退出，部分设置需要在主页面点击【重启服务】后生效。
 
数据处理页面
功能描述：
在此页面维护的生效的转换，会使中继程序遇到维护的内容时，自动替换成维护的新内容转发。分为LIS→仪器，仪器→LIS，仪器和LIS双向的选项，提供不同传输方向的数据内容替换功能。

 
表格显示当前程序的变更选项记录。
在下方的表单中，输入检测的被替换字符串在旧字符串中，新字符串中填写替换的新字符串。
点击仪器>>LIS按钮切换方向，说明为维护备注，不能为空。填写完毕后点击右侧【+】按钮即可新增条目。
   
三种方向

点击【+】后弹出确认窗口点击确定
 

 
如图显示激活，则接收到从LIS发过来的PB-RBC串会被替换成RBC后发送给仪器端。

选择项目后点击【-】可删除条目。
选择项目后点击【切换状态】后可以切换激活状态。
 
未激活条目会标记红色并且传输过程不生效。

 
任务栏图标右键菜单
 
【仪器名】-显示设置页面维护的仪器名称
【主界面/数据编辑器/程序配置页面】-打开对应窗口
【开机自启动】-左侧对应打勾为开关状态，有勾即为开机自启动，使用注册表实现
【打开日志目录】-显示logs文件夹
【添加桌面快捷方式】-自动添加一个桌面快捷方式，设置中可维护名称
【清空所有窗口日志】-清空实时日志框
【重启传输程序】-重启服务
【退出程序】-退出


