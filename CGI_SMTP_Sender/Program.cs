using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CGI_SMTP_Sender
{
    class Program
    {
        [DllImport("kernel32", SetLastError = true)]
        static extern int SetConsoleMode(int hConsoleHandle, int dwMode);

        private static string PostData;
        private static int PostLength;

        public static string Sanitize(string Raw)
        {
            string Clean = "";
            int Walk;
            char[] ByCharacter;
            if (Raw == null) return Clean;
            Raw = Raw.Replace("%22", "\"");
            Raw = Raw.Replace("%27", "'");
            Raw = Raw.Replace("&#44;", ","); Raw = Raw.Replace("%2C", ",");
            Raw = Raw.Replace("&#34;", "\""); Raw = Raw.Replace("&quot;", "\""); Raw = Raw.Replace("%5C", "\\");
            Raw = Raw.Replace("&#60;", "<"); Raw = Raw.Replace("&lt;", "<"); Raw = Raw.Replace("+", " "); Raw = Raw.Replace("%3C", "<");
            Raw = Raw.Replace("&#62;", ">"); Raw = Raw.Replace("&gt;", ">"); Raw = Raw.Replace("3E", ">");
            Raw = Raw.Replace("&#160;", " "); Raw = Raw.Replace("&nbsp;", " ");
            Raw = Raw.Replace("%21", "!"); Raw = Raw.Replace("%40", "@"); Raw = Raw.Replace("%23", "#");
            Raw = Raw.Replace("%24", "$"); Raw = Raw.Replace("%5E", "^"); Raw = Raw.Replace("%28", "(");
            Raw = Raw.Replace("%29", ")"); Raw = Raw.Replace("%25", "%"); Raw = Raw.Replace("%2F", "/");
            Raw = Raw.Replace("%3F", "?"); Raw = Raw.Replace("%3B", ";"); Raw = Raw.Replace("%3A", ":");
            Raw = Raw.Replace("%5D", "]"); Raw = Raw.Replace("%5B", "["); Raw = Raw.Replace("%7D", "}");
            Raw = Raw.Replace("%7B", "{"); Raw = Raw.Replace("%7C", "|"); Raw = Raw.Replace("%3D", "=");
            Raw = Raw.Replace("%2B", "+"); Raw = Raw.Replace("%7E", "~"); Raw = Raw.Replace("%60", "`");
            Raw = Raw.Replace("&amp;", "&"); Raw = Raw.Replace("&#38;", "&"); Raw = Raw.Replace("%26", "^");

            ByCharacter = Raw.ToCharArray();
            for (Walk = 0; Walk < Raw.Length; Walk++)
            {
                if (ByCharacter[Walk] == '\'') Clean += "'";
                else if (ByCharacter[Walk] == '"') Clean += "\"";
                else if (ByCharacter[Walk] == ' ') Clean += "&nbsp;";
                else if (ByCharacter[Walk] == '&') Clean += "<br />";
                else if (ByCharacter[Walk] >= 'A' && ByCharacter[Walk] <= 'z' ||
                        ByCharacter[Walk] >= '0' && ByCharacter[Walk] <= '9' ||
                        ByCharacter[Walk] == '=' || ByCharacter[Walk] == ',' ||
                        ByCharacter[Walk] == '.' || ByCharacter[Walk] == '@' ||
                        ByCharacter[Walk] == '#')
                    Clean += ByCharacter[Walk].ToString();
                else Clean += "^";
            }

            return Clean;
        }  // End of sanitize() method.

        private static void GatherPostThread()
        {
            if (PostLength > 2048) PostLength = 2048;  // Max length for POST data for security.
            for (; PostLength > 0; PostLength--)
                PostData += Convert.ToChar(Console.Read()).ToString();
        }

        [STAThread]
        static void Main(string[] args)
        {
            ThreadStart ThreadDelegate = new ThreadStart(GatherPostThread);
            Thread PostThread = new Thread(ThreadDelegate);
            PostLength = Convert.ToInt32(System.Environment.GetEnvironmentVariable("CONTENT_LENGTH"));
            int LengthCompare = PostLength;

            if (PostLength > 0) PostThread.Start();


            SetConsoleMode(3, 0);
            Console.Write("Content-Type: text/html\n\n");
//            Console.Write("<html><head><title>CGI in C#</title></head><body>CGI Environment:<br />");

//            Console.Write("<table border = \"1\"><tbody><tr><td>The Common Gateway Interface revision on the server:</td><td>" + System.Environment.GetEnvironmentVariable("GATEWAY_INTERFACE") + "</td></tr>");
            //            Console.Write("<tr><td>The serevr's hostname or IP address:</td><td>" + System.Environment.GetEnvironmentVariable("SERVER_NAME") + "</td></tr>");
            //            Console.Write("<tr><td>The name and version of the server software that is answering the client request:</td><td>" + System.Environment.GetEnvironmentVariable("SERVER_SOFTWARE") + "</td></tr>");
            //            Console.Write("<tr><td>The name and revision of the information protocol the request came in with:</td><td>" + System.Environment.GetEnvironmentVariable("SERVER_PROTOCOL") + "</td></tr>");
            //            Console.Write("<tr><td>The port number of the host on which the server is running:</td><td>" + System.Environment.GetEnvironmentVariable("SERVER_PORT") + "</td></tr>");
 //           Console.Write("<tr><td>The method with which the information request was issued:</td><td>" + System.Environment.GetEnvironmentVariable("REQUEST_METHOD") + "</td></tr>");
 //           Console.Write("<tr><td>Extra path information passed to a CGI program:</td><td>" + System.Environment.GetEnvironmentVariable("PATH_INFO") + "</td></tr>");
            //            Console.Write("<tr><td>The translated version of the path given by the variable PATH_INFO:</td><td>" + System.Environment.GetEnvironmentVariable("PATH_TRANSLATED") + "</td></tr>");
            //            Console.Write("<tr><td>The virtual path (e.g. \\cgi-bin\\program.com) of the script being executed:</td><td>" + System.Environment.GetEnvironmentVariable("SCRIPT_NAME") + "</td></tr>");
            //            Console.Write("<tr><td>The directory from which Web documents are served:</td><td>" + System.Environment.GetEnvironmentVariable("DOCUMENT_ROOT") + "</td></tr>");
//            Console.Write("<tr><td>The GET information passed to the program. It is appended to the URL with a \"?\":</td><td>" + Sanitize(System.Environment.GetEnvironmentVariable("QUERY_STRING")) + "</td></tr>");
            //            Console.Write("<tr><td>The remote hostname of the user making the request:</td><td>" + System.Environment.GetEnvironmentVariable("REMOTE_HOST") + "</td></tr>");
            //            Console.Write("<tr><td>The remote IP address of the user making the request:</td><td>" + System.Environment.GetEnvironmentVariable("REMOTE_ADDR") + "</td></tr>");
            //            Console.Write("<tr><td>The authentication method used to validate a user:</td><td>" + System.Environment.GetEnvironmentVariable("AUTH_TYPE") + "</td></tr>");
            //            Console.Write("<tr><td>The authenticated name of the user:</td><td>" + System.Environment.GetEnvironmentVariable("REMOTE_USER") + "</td></tr>");
            //            Console.Write("<tr><td>The user making the request. Only be set if NCSA IdentityCheck flag's enabled, and client machine supports RFC 931 ID scheme (ident daemon):</td><td>" + System.Environment.GetEnvironmentVariable("REMOTE_IDENT") + "</td></tr>");
            //            Console.Write("<tr><td>The MIME type of the query data, such as \"text/html\":</td><td>" + System.Environment.GetEnvironmentVariable("CONTENT_TYPE") + "</td></tr>");
            //            Console.Write("<tr><td>The length of the data in bytes passed to the CGI program through standard input (POST):</td><td>" + LengthCompare.ToString() + "</td></tr>");
            //            Console.Write("<tr><td>The email address of the user making the request. Most browsers do not support this variable:</td><td>" + System.Environment.GetEnvironmentVariable("HTTP_FROM") + "</td></tr>");
            //            Console.Write("<tr><td>A list of the MIME types that the client can accept:</td><td>" + System.Environment.GetEnvironmentVariable("HTTP_ACCEPT") + "</td></tr>");
            //            Console.Write("<tr><td>The browser the client is using to issue the request:</td><td>" + System.Environment.GetEnvironmentVariable("HTTP_USER_AGENT") + "</td></tr>");
            //            Console.Write("<tr><td>The URL of the document that the client points to before accessing the CGI program:</td><td>" + System.Environment.GetEnvironmentVariable("HTTP_REFERER") + "</td></tr>");


            while (PostLength > 0)
            {
                Thread.Sleep(100);
                if (PostLength < LengthCompare)
                    LengthCompare = PostLength;
                else
                {
                    PostData += "Error with POST data or connection problem.";
                    break;
                }
            }

//            Console.Write("<tr><td>The POST data passed to the program through standard input:</td><td>" + Sanitize(PostData) + "</td></tr>");

//            Console.Write("</tbody></table></body></html>");

            if (System.Environment.GetEnvironmentVariable("PATH_INFO") == "" || System.Environment.GetEnvironmentVariable("PATH_INFO") == "/")
            {
                Console.WriteLine("<form action=\" /1/CGI_SMTP_Sender.exe/send\">");
                Console.WriteLine("	<label for=\"address\">Адрес получателя</label><br>");
                Console.WriteLine("	<input type=\"text\" id=\"address\" name=\"address\" value=\"linkin94lp@yandex.ru\"><br>");
                Console.WriteLine("	<label for=\"subject\">Тема сообщения</label><br>");
                Console.WriteLine("	<input type=\"text\" id=\"subject\" name=\"subject\" value=\"Тема сообщения\"><br>");
                Console.WriteLine("	<label for=\"body\">Текст сообщения</label>");
                Console.WriteLine("<br/>");
                Console.WriteLine("	<textarea id=\"body\" name=\"body\" rows=\"4\" cols=\"50\">");
                Console.WriteLine("At w3schools.com you will learn how to make a website. They offer free tutorials in all web development technologies.");
                Console.WriteLine("	</textarea>");
                Console.WriteLine("<br/>");
                Console.WriteLine("	<input type=\"submit\" value=\"Submit\">");
                Console.WriteLine("</form>");
            }

            if(System.Environment.GetEnvironmentVariable("PATH_INFO") == "/send")
            {
                var request = System.Environment.GetEnvironmentVariable("QUERY_STRING");
                string param1 = HttpUtility.ParseQueryString(request).Get("address");
                string param2 = HttpUtility.ParseQueryString(request).Get("subject");
                string param3 = HttpUtility.ParseQueryString(request).Get("body");

                var settings = new EmailSettings
                {
                    EmailServer = "smtp.yandex.ru",
                    UserName = "groupsib701o@yandex.ru",
                    UserPassword = "sxfdoxpgizcxzmse"
                };

                var message = new EmailMessage
                {
                    EmailAddressTo = param1,
                    EmailAddressFrom = "groupsib701o@yandex.ru",
                    EmailSubject = param2,
                    EmailText = param3
                };

                message.From = $"From: Dmitry <{message.EmailAddressFrom}>";
                message.Date = GetDateTime();
                message.To = $"To: Dmitry {message.EmailAddressTo}";

                var messageSender = new MessageSender(settings, message);
                        messageSender.Send();
                    }

            Environment.Exit(0);
        }

        public static string GetDateTime()
        {
            DateTime localDate = DateTime.Now;
            return $"Date: {localDate:ddd, dd MMM yyyy H:mm:ss zzz}";
        }
    }
}
