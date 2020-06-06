using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;


namespace DataTrans
{
    class Server
    {
        public bool running = false; // Is it running?
        private int timeout = 8; // Time limit for data transfers.
        private Encoding charEncoder = Encoding.UTF8; // To encode string
        private Socket serverSocket; // Our server socket
        private string contentPath; // Root path of our contents

        // Content types that are supported by our server
        // You can add more...
        // To see other types: http://www.webmaster-toolkit.com/mime-types.shtml
        private Dictionary<string, string> extensions = new Dictionary<string, string>()
{ 
    //{ "extension", "content type" }
    { "htm", "text/html" },
    { "html", "text/html" },
    { "xml", "text/xml" },
    { "txt", "text/plain" },
    { "css", "text/css" },
    { "png", "image/png" },
    { "gif", "image/gif" },
    { "jpg", "image/jpg" },
    { "jpeg", "image/jpeg" },
    { "zip", "application/zip"}
            ,{ "log","text/html"}
};
        public FileStream fsw { get; set; }
        public Server(FileStream fsw)
        {
            this.fsw = fsw;
        }
        public bool start(IPAddress ipAddress, int port, int maxNOfCon, string contentPath)
        {
            if (running) return false; // If it is already running, exit.

            try
            {
                // A tcp/ip socket (ipv4)
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                               ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(maxNOfCon);
                serverSocket.ReceiveTimeout = timeout;
                serverSocket.SendTimeout = timeout;
                running = true;
                this.contentPath = contentPath;
            }
            catch { return false; }

            // Our thread that will listen connection requests
            // and create new threads to handle them.
            Thread requestListenerT = new Thread(() =>
            {
                while (running)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = serverSocket.Accept();
                        // Create new thread to handle the request and continue to listen the socket.
                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = timeout;
                            clientSocket.SendTimeout = timeout;
                            try { handleTheRequest(clientSocket); }
                            catch
                            {
                                try { clientSocket.Close(); } catch { }
                            }
                        });
                        requestHandler.Start();
                    }
                    catch { }
                }
            });
            requestListenerT.Start();

            return true;
        }
        public void stop()
        {
            if (running)
            {
                running = false;
                try { serverSocket.Close(); }
                catch { }
                serverSocket = null;
            }
        }
        private void handleTheRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[10240]; // 10 kb, just in case
            int receivedBCount = clientSocket.Receive(buffer); // Receive the request
            string strReceived = charEncoder.GetString(buffer, 0, receivedBCount);
            string path=Environment.CurrentDirectory+"/logs";
            DirectoryInfo directory = new DirectoryInfo(path);
            string list= "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"><title>"+Properties.Settings.Default.MachineName+"传输日志</title><style>"+
            "</style></head><body><div><h1 text-align:center>日志文件列表</h1>";
            foreach (FileInfo fileInfo in directory.GetFiles("*.log"))
            {
                list += "<a href='../logs/" + fileInfo.Name + "' text-align:center>" + fileInfo.Name.Split('.')[0] + "</a><br/>";
            }
            list += "</div></body></html>";
            // Parse method of the request
            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));
            int start = strReceived.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = strReceived.LastIndexOf("HTTP") - start - 1;
            string requestedUrl = strReceived.Substring(start, length);
            string requestedFile;
            if (httpMethod.Equals("GET") || httpMethod.Equals("POST"))
                requestedFile = requestedUrl.Split('?')[0];
            else // You can implement other methods...
            {
                notImplemented(clientSocket);
                return;
            }
            requestedFile = requestedFile.Replace("/", @"\").Replace("\\..", "");
            start = requestedFile.LastIndexOf('.') + 1;
            if (start > 0)
            {
                length = requestedFile.Length - start;
                string extension = requestedFile.Substring(start, length);
                if (!requestedFile.Contains(DateTime.Now.ToString("yyyyMMdd")))
                {

                    if (extensions.ContainsKey(extension))
                    {// Do we support this extension?
                        if (File.Exists(contentPath + requestedFile)) //If yes check existence of the file
                                                                      // Everything is OK, send requested file with correct content type:
                        {
                            if (Properties.Settings.Default.LogEncode == "Default")
                            { sendOkResponse(clientSocket, Encoding.Default.GetBytes((File.ReadAllText(contentPath + requestedFile).Replace("\r\n", "<br/>"))), extensions[extension]); }
                            else {
                                Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.LogEncode);
                                sendOkResponse(clientSocket, encode.GetBytes((File.ReadAllText(contentPath + requestedFile).Replace("\r\n", "<br/>"))), extensions[extension]);
                            }
                        }
                        else
                            notFound(clientSocket); // We don't support this extension.
                    }
                }
                else
                {

                    byte[] byteArrayRead = new byte[1024 * 1024]; //  1字节*1024 = 1k 1k*1024 = 1M内存
                    fsw.Seek(0, SeekOrigin.Begin);
                    //通过死缓存去读文本中的内容
                    while (true)
                    {
                        //readCount  这个是保存真正读取到的字节数
                        int readCount = fsw.Read(byteArrayRead, 0, byteArrayRead.Length);
                        //既然是死循环 那么什么时候我们停止读取文本内容 我们知道文本最后一行的大小肯定是小于缓存内存大小的
                        if (readCount < byteArrayRead.Length)
                        {
                            break;  //结束循环
                        }
                    }
                    if (Properties.Settings.Default.LogEncode == "Default")
                    {
                        string todaylog = Encoding.Default.GetString(byteArrayRead);
                        sendOkResponse(clientSocket, Encoding.Default.GetBytes(todaylog.Replace("\r\n", "<br/>")), extensions[extension]);
                    }
                    else {
                        Encoding encode = Encoding.GetEncoding(Properties.Settings.Default.LogEncode);
                        string todaylog = encode.GetString(byteArrayRead);
                        sendOkResponse(clientSocket, encode.GetBytes(todaylog.Replace("\r\n", "<br/>")), extensions[extension]);
                    }
                }
                // We are assuming that it doesn't exist.
            }
            else
            {
                // If file is not specified try to send index.htm or index.html
                // You can add more (default.htm, default.html)
                //if (requestedFile.Substring(length - 1, 1) != @"\")
                //    requestedFile += @"\";
                //if (File.Exists(contentPath + requestedFile + "index.htm"))
                //    sendOkResponse(clientSocket,Encoding.Default.GetBytes(File.ReadAllText(contentPath + requestedFile)), "text/html");
                //else if (File.Exists(contentPath + requestedFile + "index.html"))
                //    sendOkResponse(clientSocket, Encoding.Default.GetBytes(File.ReadAllText(contentPath + requestedFile)), "text/html");
                //else
                //    notFound(clientSocket);
                sendOkResponse(clientSocket, Encoding.UTF8.GetBytes(list), "text/html");
            }
        }
        private void notImplemented(Socket clientSocket)
        {

            sendResponse(clientSocket, "<html><head><meta http - equiv =\"Content-Type\" content=\"text/html;charset = utf - 8\"></ head >< body >< h2 > Atasoy Simple Web Server </ h2 >< div > 501 - Method Not Implemented </ div ></ body ></ html > ", "501 Not Implemented", "text/html");

        }

        private void notFound(Socket clientSocket)
        {

            sendResponse(clientSocket, "<html><head><meta http - equiv =\"Content-Type\" content=\"text/html; charset = utf - 8\"></head><body><h2>Atasoy Simple Web  Server </ h2 >< div > 404 - Not Found </ div ></ body ></ html > ", "404 Not Found", "text/html");
        }

        private void sendOkResponse(Socket clientSocket, byte[] bContent, string contentType)
        {
            sendResponse(clientSocket, bContent, "200 OK", contentType);
        }
        private void sendResponse(Socket clientSocket, string strContent, string responseCode,
                          string contentType)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            sendResponse(clientSocket, bContent, responseCode, contentType);
        }

        // For byte arrays
        private void sendResponse(Socket clientSocket, byte[] bContent, string responseCode,string contentType)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Atasoy Simple Web Server\r\n"
                                  + "Content-Length: " + bContent.Length.ToString() + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch { }
        }
    }
}
