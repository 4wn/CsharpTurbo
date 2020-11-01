using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SirSaddamTubro
{
    class MainClass
    {
        public static void Main(string[] args)
        {
 
            Console.WriteLine(@"
      _____  ____           
     / ___/_/ / /_          
    / /__/_  . __/          
    \___/_    __/           
     ____/_/_/      __      
    /_  __/_ ______/ /  ___ 
     / / / // / __/ _ \/ _ \
    /_/  \_,_/_/ /_.__/\___/
                        
");
            Console.WriteLine("Turbo is made by @Sir.Saddam, Turbo is free and open src can't be for sell!!");
            Turbo();
        }
        static void Turbo()
        {
            Console.WriteLine("[!] Enter Username:");
            String username = Console.ReadLine();
            Console.WriteLine("[!] Enter Password:");
            String password = Console.ReadLine();
            try
            {
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create("https://i.instagram.com/api/v1/accounts/login/");
                String Uuid = Guid.NewGuid().ToString();
                String Data = "password=" + password + "&username=" + username + "&device_id=" + Uuid + "&_csrftoken=missing";
                byte[] PostData = Encoding.UTF8.GetBytes(Data);
                req.Method = "POST";
                req.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                req.Host = "i.instagram.com";
                req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                req.Headers.Add("Accept-Language", "en-US");
                req.ContentLength = (long)PostData.Length;
                req.CookieContainer = new CookieContainer();
                Stream stream = req.GetRequestStream();
                stream.Write(PostData, 0, PostData.Length);
                stream.Close();
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)req.GetResponse();
                }
                catch (WebException ep)
                {
                    response = (HttpWebResponse)ep.Response;
                }
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    String Respon = streamReader.ReadToEnd();
                    if (Respon.Contains("logged_in_user"))
                    {
                        Console.WriteLine($"[-] Done Login With >> {username}");
                        Console.WriteLine("Add Bio? [Yes-No]:");
                        String addBio = Console.ReadLine();
                        if (addBio == "Yes")
                        {
                            try
                            {
                                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                rq.Method = "GET";
                                rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                rq.Host = "i.instagram.com";
                                rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                rq.Headers.Add("Accept-Language", "en-US");
                                rq.CookieContainer = req.CookieContainer;
                                HttpWebResponse respons;
                                try
                                {
                                    respons = (HttpWebResponse)rq.GetResponse();
                                }
                                catch (WebException ep2)
                                {
                                    respons = (HttpWebResponse)ep2.Response;
                                }
                                using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                {
                                    string r = streamReader2.ReadToEnd();
                                    Console.WriteLine("[-] Enter Bio:");
                                    String Bio = Console.ReadLine();
                                    String Email = "";
                                    string Phone = "";
                                    string full_name = "";
                                    string external_url = "";
                                    if (r.Contains("email"))
                                    {
                                        Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    if (r.Contains("phone_number"))
                                    {
                                        Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    if (r.Contains("full_name"))
                                    {
                                        full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    if (r.Contains("external_url"))
                                    {
                                        external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    Console.WriteLine("[!] Enter Target: ");
                                    string target = Console.ReadLine();
                                    bool start = true;
                                    int thread;
                                    Console.WriteLine("[!] Enter Thread:");
                                    thread = Convert.ToInt32(Console.ReadLine());
                                    while (start == true)
                                    {
                                        Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                        {
                                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                            String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + Bio + "&external_url=" + external_url + "&chaining_enabled=on";
                                            byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                            request.Method = "POST";
                                            request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                            request.Host = "i.instagram.com";
                                            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                            request.Headers.Add("Accept-Language", "en-US");
                                            request.ContentLength = (long)PostSwap.Length;
                                            request.CookieContainer = req.CookieContainer;
                                            Stream stream3 = request.GetRequestStream();
                                            stream3.Write(PostSwap, 0, PostSwap.Length);
                                            stream3.Close();
                                            HttpWebResponse response1;
                                            try
                                            {
                                                response1 = (HttpWebResponse)request.GetResponse();
                                            }
                                            catch (WebException ep3)
                                            {
                                                response1 = (HttpWebResponse)ep3.Response;
                                            }
                                            using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                            {
                                                String res = text.ReadToEnd();
                                                if (res.Contains("pk"))
                                                {
                                                    Console.WriteLine($"[!] Done Swap >> {target}");
                                                    start = false;
                                                    stat.Break();
                                                }
                                                else if (res.Contains("This username isn't available. Please try another."))
                                                {
                                                    Console.WriteLine("[!] Trying");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("[!] Spam");
                                                    start = false;
                                                    stat.Break(); ;

                                                }
                                            }
                                        });
                                    }
                                }
                            }
                            catch (Exception et)
                            {

                            }
                        }
                        else if (addBio == "No")
                        {
                            try
                            {
                                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                rq.Method = "GET";
                                rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                rq.Host = "i.instagram.com";
                                rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                rq.Headers.Add("Accept-Language", "en-US");
                                rq.CookieContainer = req.CookieContainer;
                                HttpWebResponse respons;
                                try
                                {
                                    respons = (HttpWebResponse)rq.GetResponse();
                                }
                                catch (WebException ep2)
                                {
                                    respons = (HttpWebResponse)ep2.Response;
                                }
                                using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                {
                                    string r = streamReader2.ReadToEnd();
                                    String Email = "";
                                    string Phone = "";
                                    string full_name = "";
                                    String biography = "";
                                    string external_url = "";
                                    if (r.Contains("email"))
                                    {
                                        Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    if (r.Contains("phone_number"))
                                    {
                                        Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    if (r.Contains("full_name"))
                                    {
                                        full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    if (r.Contains("biography"))
                                    {
                                        biography = Regex.Match(r, "\"biography\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    if (r.Contains("external_url"))
                                    {
                                        external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                    }
                                    try
                                    {
                                        Console.WriteLine("[!] Enter Target: ");
                                        string target = Console.ReadLine();
                                        bool start = true;
                                        int thread;
                                        Console.WriteLine("[!] Enter Thread:");
                                        thread = Convert.ToInt32(Console.ReadLine());
                                        while (start == true)
                                        {
                                            Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                            {
                                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + biography + "&external_url=" + external_url + "&chaining_enabled=on";
                                                byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                request.Method = "POST";
                                                request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                request.Host = "i.instagram.com";
                                                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                request.Headers.Add("Accept-Language", "en-US");
                                                request.ContentLength = (long)PostSwap.Length;
                                                request.CookieContainer = req.CookieContainer;
                                                Stream stream3 = request.GetRequestStream();
                                                stream3.Write(PostSwap, 0, PostSwap.Length);
                                                stream3.Close();
                                                HttpWebResponse response1;
                                                try
                                                {
                                                    response1 = (HttpWebResponse)request.GetResponse();
                                                }
                                                catch (WebException ep3)
                                                {
                                                    response1 = (HttpWebResponse)ep3.Response;
                                                }
                                                using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                {
                                                    String res = text.ReadToEnd();
                                                    if (res.Contains("pk"))
                                                    {
                                                        Console.WriteLine($"[!] Done Swap >> {target}");
                                                        start = false;
                                                        stat.Break();
                                                    }
                                                    else if (res.Contains("This username isn't available. Please try another."))
                                                    {
                                                        Console.WriteLine("[!] Trying");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("[!] Spam");
                                                        start = false;
                                                        stat.Break();

                                                    }
                                                }
                                            });
                                        }
                                    }
                                    catch (Exception etp)
                                    {

                                    }
                                }
                            }
                            catch (Exception et)
                            {

                            }
                        }
                        else
                        {
                            Console.WriteLine("Write Only [Yes-No]");
                        }
                    }
                    else if (Respon.Contains("The password you entered is incorrect. Please try again."))
                    {
                        Console.WriteLine($"[-] Wrong Password >> {password}");
                    }
                    else if (Respon.Contains("The username you entered doesn't appear to belong to an account"))
                    {
                        Console.WriteLine($"[-] Wrong Username >> {username}");
                    }
                    else if (Respon.Contains("challenge"))
                    {
                        Console.WriteLine($"[-] Secure >> {username}");
                        try
                        {
                            string path = Regex.Match(Respon, "\"api_path\": \"(.*?)\"").Groups[1].Value;
                            string SecUrl = "https://i.instagram.com/api/v1" + path;
                            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(SecUrl);
                            req2.Method = "GET";
                            req2.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                            req2.Host = "i.instagram.com";
                            req2.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                            req2.Headers.Add("Accept-Language", "en-US");
                            req2.CookieContainer = req.CookieContainer;
                            HttpWebResponse response12;
                            try
                            {
                                response12 = (HttpWebResponse)req2.GetResponse();
                            }
                            catch (WebException epa2)
                            {
                                response12 = (HttpWebResponse)epa2.Response;
                            }
                            using (StreamReader streamRead = new StreamReader(response12.GetResponseStream()))
                            {
                                string rr = streamRead.ReadToEnd();
                                bool EmaliTrue = false;
                                bool PhoneTrue = false;
                                if (rr.Contains("email"))
                                {
                                    EmaliTrue = true;
                                }if (rr.Contains("phone_number"))
                                {
                                    PhoneTrue = true;
                                }
                                if (PhoneTrue == true && EmaliTrue == true)
                                {
                                    Console.WriteLine("[1]-Email, [0]-Phone");
                                    int Mode = Convert.ToInt32(Console.ReadLine());
                                    if (Mode == 1)
                                    {
                                        HttpWebRequest req5 = (HttpWebRequest)WebRequest.Create(SecUrl);
                                        String SecData = "choice=" + Mode + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                        byte[] SecPost = Encoding.UTF8.GetBytes(SecData);
                                        req5.Method = "POST";
                                        req5.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                        req5.Host = "i.instagram.com";
                                        req5.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                        req5.Headers.Add("Accept-Language", "en-US");
                                        req5.ContentLength = (long)SecPost.Length;
                                        req5.CookieContainer = req.CookieContainer;
                                        Stream stream7 = req5.GetRequestStream();
                                        stream7.Write(SecPost, 0, SecPost.Length);
                                        stream7.Close();
                                        HttpWebResponse response22;
                                        try
                                        {
                                            response22 = (HttpWebResponse)req5.GetResponse();
                                        }
                                        catch (WebException epa2a)
                                        {
                                            response22 = (HttpWebResponse)epa2a.Response;
                                        }
                                        using (StreamReader streamReadeing = new StreamReader(response22.GetResponseStream()))
                                        {
                                            string ress2 = streamReadeing.ReadToEnd();
                                            string Contact = Regex.Match(ress2, "\"contact_point\": \"(.*?)\"").Groups[1].Value;
                                            Console.WriteLine($"Done Sending Code to Email >> {Contact}");
                                            Console.WriteLine("[!] Enter Code:");
                                            int Code = Convert.ToInt32(Console.ReadLine());
                                            HttpWebRequest reqCode = (HttpWebRequest)WebRequest.Create(SecUrl);
                                            String CodeData = "security_code=" + Code + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                            byte[] PostCode = Encoding.UTF8.GetBytes(CodeData);
                                            reqCode.Method = "POST";
                                            reqCode.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                            reqCode.Host = "i.instagram.com";
                                            reqCode.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                            reqCode.Headers.Add("Accept-Language", "en-US");
                                            reqCode.ContentLength = (long)PostCode.Length;
                                            reqCode.CookieContainer = req.CookieContainer;
                                            Stream stream8 = reqCode.GetRequestStream();
                                            stream8.Write(PostCode, 0, PostCode.Length);
                                            stream8.Close();
                                            HttpWebResponse response23;
                                            try
                                            {
                                                response23 = (HttpWebResponse)reqCode.GetResponse();
                                            }
                                            catch (WebException epa2aa)
                                            {
                                                response23 = (HttpWebResponse)epa2aa.Response;
                                            }
                                            using (StreamReader streamReadeing1 = new StreamReader(response23.GetResponseStream()))
                                            {
                                                string LastSec = streamReadeing1.ReadToEnd();
                                                if (LastSec.Contains("logged_in_user"))
                                                {
                                                    Console.WriteLine("Add Bio? [Yes-No]:");
                                                    String addBio = Console.ReadLine();
                                                    if (addBio == "Yes")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                Console.WriteLine("[-] Enter Bio:");
                                                                String Bio = Console.ReadLine();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                Console.WriteLine("[!] Enter Target: ");
                                                                string target = Console.ReadLine();
                                                                bool start = true;
                                                                int thread;
                                                                Console.WriteLine("[!] Enter Thread:");
                                                                thread = Convert.ToInt32(Console.ReadLine());
                                                                while (start == true)
                                                                {
                                                                    Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                    {
                                                                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                        String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + Bio + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                        byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                        request.Method = "POST";
                                                                        request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                        request.Host = "i.instagram.com";
                                                                        request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                        request.Headers.Add("Accept-Language", "en-US");
                                                                        request.ContentLength = (long)PostSwap.Length;
                                                                        request.CookieContainer = req.CookieContainer;
                                                                        Stream stream3 = request.GetRequestStream();
                                                                        stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                        stream3.Close();
                                                                        HttpWebResponse response1;
                                                                        try
                                                                        {
                                                                            response1 = (HttpWebResponse)request.GetResponse();
                                                                        }
                                                                        catch (WebException ep3)
                                                                        {
                                                                            response1 = (HttpWebResponse)ep3.Response;
                                                                        }
                                                                        using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                        {
                                                                            String res = text.ReadToEnd();
                                                                            if (res.Contains("pk"))
                                                                            {
                                                                                Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                start = false;
                                                                                stat.Break();
                                                                            }
                                                                            else if (res.Contains("This username isn't available. Please try another."))
                                                                            {
                                                                                Console.WriteLine("[!] Trying");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("[!] Spam");
                                                                                start = false;
                                                                                stat.Break(); ;

                                                                            }
                                                                        }
                                                                    });
                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else if (addBio == "No")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                String biography = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("biography"))
                                                                {
                                                                    biography = Regex.Match(r, "\"biography\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                try
                                                                {
                                                                    Console.WriteLine("[!] Enter Target: ");
                                                                    string target = Console.ReadLine();
                                                                    bool start = true;
                                                                    int thread;
                                                                    Console.WriteLine("[!] Enter Thread:");
                                                                    thread = Convert.ToInt32(Console.ReadLine());
                                                                    while (start == true)
                                                                    {
                                                                        Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                        {
                                                                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                            String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + biography + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                            byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                            request.Method = "POST";
                                                                            request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                            request.Host = "i.instagram.com";
                                                                            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                            request.Headers.Add("Accept-Language", "en-US");
                                                                            request.ContentLength = (long)PostSwap.Length;
                                                                            request.CookieContainer = req.CookieContainer;
                                                                            Stream stream3 = request.GetRequestStream();
                                                                            stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                            stream3.Close();
                                                                            HttpWebResponse response1;
                                                                            try
                                                                            {
                                                                                response1 = (HttpWebResponse)request.GetResponse();
                                                                            }
                                                                            catch (WebException ep3)
                                                                            {
                                                                                response1 = (HttpWebResponse)ep3.Response;
                                                                            }
                                                                            using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                            {
                                                                                String res = text.ReadToEnd();
                                                                                if (res.Contains("pk"))
                                                                                {
                                                                                    Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                    start = false;
                                                                                    stat.Break();
                                                                                }
                                                                                else if (res.Contains("This username isn't available. Please try another."))
                                                                                {
                                                                                    Console.WriteLine("[!] Trying");
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("[!] Spam");
                                                                                    start = false;
                                                                                    stat.Break();

                                                                                }
                                                                            }
                                                                        });
                                                                    }
                                                                }
                                                                catch (Exception etp)
                                                                {

                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Write Only [Yes-No]");
                                                    }
                                                }
                                                if (LastSec.Contains("Please check the code we sent you and try again."))
                                                {
                                                    Console.WriteLine("[!] Wrong Code");
                                                }
                                            }
                                        }
                                    }if (Mode==0)
                                    {
                                        HttpWebRequest req5 = (HttpWebRequest)WebRequest.Create(SecUrl);
                                        String SecData = "choice=" + Mode + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                        byte[] SecPost = Encoding.UTF8.GetBytes(SecData);
                                        req5.Method = "POST";
                                        req5.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                        req5.Host = "i.instagram.com";
                                        req5.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                        req5.Headers.Add("Accept-Language", "en-US");
                                        req5.ContentLength = (long)SecPost.Length;
                                        req5.CookieContainer = req.CookieContainer;
                                        Stream stream7 = req5.GetRequestStream();
                                        stream7.Write(SecPost, 0, SecPost.Length);
                                        stream7.Close();
                                        HttpWebResponse response22;
                                        try
                                        {
                                            response22 = (HttpWebResponse)req5.GetResponse();
                                        }
                                        catch (WebException epa2a)
                                        {
                                            response22 = (HttpWebResponse)epa2a.Response;
                                        }
                                        using (StreamReader streamReadeing = new StreamReader(response22.GetResponseStream()))
                                        {
                                            string ress2 = streamReadeing.ReadToEnd();
                                            string Contact = Regex.Match(ress2, "\"contact_point\": \"(.*?)\"").Groups[1].Value;
                                            Console.WriteLine($"Done Sending Code to Email >> {Contact}");
                                            Console.WriteLine("[!] Enter Code:");
                                            int Code = Convert.ToInt32(Console.ReadLine());
                                            HttpWebRequest reqCode = (HttpWebRequest)WebRequest.Create(SecUrl);
                                            String CodeData = "security_code=" + Code + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                            byte[] PostCode = Encoding.UTF8.GetBytes(CodeData);
                                            reqCode.Method = "POST";
                                            reqCode.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                            reqCode.Host = "i.instagram.com";
                                            reqCode.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                            reqCode.Headers.Add("Accept-Language", "en-US");
                                            reqCode.ContentLength = (long)PostCode.Length;
                                            reqCode.CookieContainer = req.CookieContainer;
                                            Stream stream8 = reqCode.GetRequestStream();
                                            stream8.Write(PostCode, 0, PostCode.Length);
                                            stream8.Close();
                                            HttpWebResponse response23;
                                            try
                                            {
                                                response23 = (HttpWebResponse)reqCode.GetResponse();
                                            }
                                            catch (WebException epa2aa)
                                            {
                                                response23 = (HttpWebResponse)epa2aa.Response;
                                            }
                                            using (StreamReader streamReadeing1 = new StreamReader(response23.GetResponseStream()))
                                            {
                                                string LastSec = streamReadeing1.ReadToEnd();
                                                if (LastSec.Contains("logged_in_user"))
                                                {
                                                    Console.WriteLine("Add Bio? [Yes-No]:");
                                                    String addBio = Console.ReadLine();
                                                    if (addBio == "Yes")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                Console.WriteLine("[-] Enter Bio:");
                                                                String Bio = Console.ReadLine();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                Console.WriteLine("[!] Enter Target: ");
                                                                string target = Console.ReadLine();
                                                                bool start = true;
                                                                int thread;
                                                                Console.WriteLine("[!] Enter Thread:");
                                                                thread = Convert.ToInt32(Console.ReadLine());
                                                                while (start == true)
                                                                {
                                                                    Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                    {
                                                                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                        String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + Bio + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                        byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                        request.Method = "POST";
                                                                        request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                        request.Host = "i.instagram.com";
                                                                        request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                        request.Headers.Add("Accept-Language", "en-US");
                                                                        request.ContentLength = (long)PostSwap.Length;
                                                                        request.CookieContainer = req.CookieContainer;
                                                                        Stream stream3 = request.GetRequestStream();
                                                                        stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                        stream3.Close();
                                                                        HttpWebResponse response1;
                                                                        try
                                                                        {
                                                                            response1 = (HttpWebResponse)request.GetResponse();
                                                                        }
                                                                        catch (WebException ep3)
                                                                        {
                                                                            response1 = (HttpWebResponse)ep3.Response;
                                                                        }
                                                                        using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                        {
                                                                            String res = text.ReadToEnd();
                                                                            if (res.Contains("pk"))
                                                                            {
                                                                                Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                start = false;
                                                                                stat.Break();
                                                                            }
                                                                            else if (res.Contains("This username isn't available. Please try another."))
                                                                            {
                                                                                Console.WriteLine("[!] Trying");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("[!] Spam");
                                                                                start = false;
                                                                                stat.Break(); ;

                                                                            }
                                                                        }
                                                                    });
                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else if (addBio == "No")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                String biography = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("biography"))
                                                                {
                                                                    biography = Regex.Match(r, "\"biography\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                try
                                                                {
                                                                    Console.WriteLine("[!] Enter Target: ");
                                                                    string target = Console.ReadLine();
                                                                    bool start = true;
                                                                    int thread;
                                                                    Console.WriteLine("[!] Enter Thread:");
                                                                    thread = Convert.ToInt32(Console.ReadLine());
                                                                    while (start == true)
                                                                    {
                                                                        Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                        {
                                                                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                            String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + biography + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                            byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                            request.Method = "POST";
                                                                            request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                            request.Host = "i.instagram.com";
                                                                            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                            request.Headers.Add("Accept-Language", "en-US");
                                                                            request.ContentLength = (long)PostSwap.Length;
                                                                            request.CookieContainer = req.CookieContainer;
                                                                            Stream stream3 = request.GetRequestStream();
                                                                            stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                            stream3.Close();
                                                                            HttpWebResponse response1;
                                                                            try
                                                                            {
                                                                                response1 = (HttpWebResponse)request.GetResponse();
                                                                            }
                                                                            catch (WebException ep3)
                                                                            {
                                                                                response1 = (HttpWebResponse)ep3.Response;
                                                                            }
                                                                            using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                            {
                                                                                String res = text.ReadToEnd();
                                                                                if (res.Contains("pk"))
                                                                                {
                                                                                    Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                    start = false;
                                                                                    stat.Break();
                                                                                }
                                                                                else if (res.Contains("This username isn't available. Please try another."))
                                                                                {
                                                                                    Console.WriteLine("[!] Trying");
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("[!] Spam");
                                                                                    start = false;
                                                                                    stat.Break();

                                                                                }
                                                                            }
                                                                        });
                                                                    }
                                                                }
                                                                catch (Exception etp)
                                                                {

                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Write Only [Yes-No]");
                                                    }
                                                }
                                                if (LastSec.Contains("Please check the code we sent you and try again."))
                                                {
                                                    Console.WriteLine("[!] Wrong Code");
                                                }
                                            }
                                        }
                                    }
                                }if (PhoneTrue == true && EmaliTrue == false)
                                {
                                    Console.WriteLine("[0]-Phone");
                                    int Mode = Convert.ToInt32(Console.ReadLine());
                                    if (Mode == 0)
                                    {
                                        HttpWebRequest req5 = (HttpWebRequest)WebRequest.Create(SecUrl);
                                        String SecData = "choice=" + Mode + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                        byte[] SecPost = Encoding.UTF8.GetBytes(SecData);
                                        req5.Method = "POST";
                                        req5.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                        req5.Host = "i.instagram.com";
                                        req5.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                        req5.Headers.Add("Accept-Language", "en-US");
                                        req5.ContentLength = (long)SecPost.Length;
                                        req5.CookieContainer = req.CookieContainer;
                                        Stream stream7 = req5.GetRequestStream();
                                        stream7.Write(SecPost, 0, SecPost.Length);
                                        stream7.Close();
                                        HttpWebResponse response22;
                                        try
                                        {
                                            response22 = (HttpWebResponse)req5.GetResponse();
                                        }
                                        catch (WebException epa2a)
                                        {
                                            response22 = (HttpWebResponse)epa2a.Response;
                                        }
                                        using (StreamReader streamReadeing = new StreamReader(response22.GetResponseStream()))
                                        {
                                            string ress2 = streamReadeing.ReadToEnd();
                                            string Contact = Regex.Match(ress2, "\"contact_point\": \"(.*?)\"").Groups[1].Value;
                                            Console.WriteLine($"Done Sending Code to Email >> {Contact}");
                                            Console.WriteLine("[!] Enter Code:");
                                            int Code = Convert.ToInt32(Console.ReadLine());
                                            HttpWebRequest reqCode = (HttpWebRequest)WebRequest.Create(SecUrl);
                                            String CodeData = "security_code=" + Code + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                            byte[] PostCode = Encoding.UTF8.GetBytes(CodeData);
                                            reqCode.Method = "POST";
                                            reqCode.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                            reqCode.Host = "i.instagram.com";
                                            reqCode.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                            reqCode.Headers.Add("Accept-Language", "en-US");
                                            reqCode.ContentLength = (long)PostCode.Length;
                                            reqCode.CookieContainer = req.CookieContainer;
                                            Stream stream8 = reqCode.GetRequestStream();
                                            stream8.Write(PostCode, 0, PostCode.Length);
                                            stream8.Close();
                                            HttpWebResponse response23;
                                            try
                                            {
                                                response23 = (HttpWebResponse)reqCode.GetResponse();
                                            }
                                            catch (WebException epa2aa)
                                            {
                                                response23 = (HttpWebResponse)epa2aa.Response;
                                            }
                                            using (StreamReader streamReadeing1 = new StreamReader(response23.GetResponseStream()))
                                            {
                                                string LastSec = streamReadeing1.ReadToEnd();
                                                Console.WriteLine(LastSec);
                                                if (LastSec.Contains("logged_in_user"))
                                                {
                                                    Console.WriteLine("Add Bio? [Yes-No]:");
                                                    String addBio = Console.ReadLine();
                                                    if (addBio == "Yes")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                Console.WriteLine("[-] Enter Bio:");
                                                                String Bio = Console.ReadLine();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                Console.WriteLine("[!] Enter Target: ");
                                                                string target = Console.ReadLine();
                                                                bool start = true;
                                                                int thread;
                                                                Console.WriteLine("[!] Enter Thread:");
                                                                thread = Convert.ToInt32(Console.ReadLine());
                                                                while (start == true)
                                                                {
                                                                    Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                    {
                                                                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                        String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + Bio + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                        byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                        request.Method = "POST";
                                                                        request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                        request.Host = "i.instagram.com";
                                                                        request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                        request.Headers.Add("Accept-Language", "en-US");
                                                                        request.ContentLength = (long)PostSwap.Length;
                                                                        request.CookieContainer = req.CookieContainer;
                                                                        Stream stream3 = request.GetRequestStream();
                                                                        stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                        stream3.Close();
                                                                        HttpWebResponse response1;
                                                                        try
                                                                        {
                                                                            response1 = (HttpWebResponse)request.GetResponse();
                                                                        }
                                                                        catch (WebException ep3)
                                                                        {
                                                                            response1 = (HttpWebResponse)ep3.Response;
                                                                        }
                                                                        using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                        {
                                                                            String res = text.ReadToEnd();
                                                                            if (res.Contains("pk"))
                                                                            {
                                                                                Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                start = false;
                                                                                stat.Break();
                                                                            }
                                                                            else if (res.Contains("This username isn't available. Please try another."))
                                                                            {
                                                                                Console.WriteLine("[!] Trying");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("[!] Spam");
                                                                                start = false;
                                                                                stat.Break(); ;

                                                                            }
                                                                        }
                                                                    });
                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else if (addBio == "No")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                String biography = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("biography"))
                                                                {
                                                                    biography = Regex.Match(r, "\"biography\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                try
                                                                {
                                                                    Console.WriteLine("[!] Enter Target: ");
                                                                    string target = Console.ReadLine();
                                                                    bool start = true;
                                                                    int thread;
                                                                    Console.WriteLine("[!] Enter Thread:");
                                                                    thread = Convert.ToInt32(Console.ReadLine());
                                                                    while (start == true)
                                                                    {
                                                                        Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                        {
                                                                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                            String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + biography + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                            byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                            request.Method = "POST";
                                                                            request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                            request.Host = "i.instagram.com";
                                                                            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                            request.Headers.Add("Accept-Language", "en-US");
                                                                            request.ContentLength = (long)PostSwap.Length;
                                                                            request.CookieContainer = req.CookieContainer;
                                                                            Stream stream3 = request.GetRequestStream();
                                                                            stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                            stream3.Close();
                                                                            HttpWebResponse response1;
                                                                            try
                                                                            {
                                                                                response1 = (HttpWebResponse)request.GetResponse();
                                                                            }
                                                                            catch (WebException ep3)
                                                                            {
                                                                                response1 = (HttpWebResponse)ep3.Response;
                                                                            }
                                                                            using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                            {
                                                                                String res = text.ReadToEnd();
                                                                                if (res.Contains("pk"))
                                                                                {
                                                                                    Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                    start = false;
                                                                                    stat.Break();
                                                                                }
                                                                                else if (res.Contains("This username isn't available. Please try another."))
                                                                                {
                                                                                    Console.WriteLine("[!] Trying");
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("[!] Spam");
                                                                                    start = false;
                                                                                    stat.Break();

                                                                                }
                                                                            }
                                                                        });
                                                                    }
                                                                }
                                                                catch (Exception etp)
                                                                {

                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Write Only [Yes-No]");
                                                    }
                                                }
                                                if (LastSec.Contains("Please check the code we sent you and try again."))
                                                {
                                                    Console.WriteLine("[!] Wrong Code");
                                                }
                                            }
                                        }
                                    }    
                                }if (PhoneTrue == false && EmaliTrue == true)
                                {
                                    Console.WriteLine("[1]-Email");
                                    int Mode = Convert.ToInt32(Console.ReadLine());
                                    if (Mode ==1)
                                    {
                                        HttpWebRequest req5 = (HttpWebRequest)WebRequest.Create(SecUrl);
                                        String SecData = "choice=" + Mode + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                        byte[] SecPost = Encoding.UTF8.GetBytes(SecData);
                                        req5.Method = "POST";
                                        req5.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                        req5.Host = "i.instagram.com";
                                        req5.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                        req5.Headers.Add("Accept-Language", "en-US");
                                        req5.ContentLength = (long)SecPost.Length;
                                        req5.CookieContainer = req.CookieContainer;
                                        Stream stream7 = req5.GetRequestStream();
                                        stream7.Write(SecPost, 0, SecPost.Length);
                                        stream7.Close();
                                        HttpWebResponse response22;
                                        try
                                        {
                                            response22 = (HttpWebResponse)req5.GetResponse();
                                        }
                                        catch (WebException epa2a)
                                        {
                                            response22 = (HttpWebResponse)epa2a.Response;
                                        }
                                        using (StreamReader streamReadeing = new StreamReader(response22.GetResponseStream()))
                                        {
                                            string ress2 = streamReadeing.ReadToEnd();
                                            string Contact = Regex.Match(ress2, "\"contact_point\": \"(.*?)\"").Groups[1].Value;
                                            Console.WriteLine($"Done Sending Code to Email >> {Contact}");
                                            Console.WriteLine("[!] Enter Code:");
                                            int Code = Convert.ToInt32(Console.ReadLine());
                                            HttpWebRequest reqCode = (HttpWebRequest)WebRequest.Create(SecUrl);
                                            String CodeData = "security_code=" + Code + "&_uuid=" + Uuid + "&_uid=" + Uuid + "&_csrftoken=missing";
                                            byte[] PostCode = Encoding.UTF8.GetBytes(CodeData);
                                            reqCode.Method = "POST";
                                            reqCode.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                            reqCode.Host = "i.instagram.com";
                                            reqCode.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                            reqCode.Headers.Add("Accept-Language", "en-US");
                                            reqCode.ContentLength = (long)PostCode.Length;
                                            reqCode.CookieContainer = req.CookieContainer;
                                            Stream stream8 = reqCode.GetRequestStream();
                                            stream8.Write(PostCode, 0, PostCode.Length);
                                            stream8.Close();
                                            HttpWebResponse response23;
                                            try
                                            {
                                                response23 = (HttpWebResponse)reqCode.GetResponse();
                                            }
                                            catch (WebException epa2aa)
                                            {
                                                response23 = (HttpWebResponse)epa2aa.Response;
                                            }
                                            using (StreamReader streamReadeing1 = new StreamReader(response23.GetResponseStream()))
                                            {
                                                string LastSec = streamReadeing1.ReadToEnd();
                                                if (LastSec.Contains("logged_in_user"))
                                                {
                                                    Console.WriteLine("Add Bio? [Yes-No]:");
                                                    String addBio = Console.ReadLine();
                                                    if (addBio == "Yes")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                Console.WriteLine("[-] Enter Bio:");
                                                                String Bio = Console.ReadLine();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                Console.WriteLine("[!] Enter Target: ");
                                                                string target = Console.ReadLine();
                                                                bool start = true;
                                                                int thread;
                                                                Console.WriteLine("[!] Enter Thread:");
                                                                thread = Convert.ToInt32(Console.ReadLine());
                                                                while (start == true)
                                                                {
                                                                    Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                    {
                                                                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                        String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + Bio + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                        byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                        request.Method = "POST";
                                                                        request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                        request.Host = "i.instagram.com";
                                                                        request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                        request.Headers.Add("Accept-Language", "en-US");
                                                                        request.ContentLength = (long)PostSwap.Length;
                                                                        request.CookieContainer = req.CookieContainer;
                                                                        Stream stream3 = request.GetRequestStream();
                                                                        stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                        stream3.Close();
                                                                        HttpWebResponse response1;
                                                                        try
                                                                        {
                                                                            response1 = (HttpWebResponse)request.GetResponse();
                                                                        }
                                                                        catch (WebException ep3)
                                                                        {
                                                                            response1 = (HttpWebResponse)ep3.Response;
                                                                        }
                                                                        using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                        {
                                                                            String res = text.ReadToEnd();
                                                                            if (res.Contains("pk"))
                                                                            {
                                                                                Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                start = false;
                                                                                stat.Break();
                                                                            }
                                                                            else if (res.Contains("This username isn't available. Please try another."))
                                                                            {
                                                                                Console.WriteLine("[!] Trying");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("[!] Spam");
                                                                                start = false;
                                                                                stat.Break(); ;

                                                                            }
                                                                        }
                                                                    });
                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else if (addBio == "No")
                                                    {
                                                        try
                                                        {
                                                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true");
                                                            rq.Method = "GET";
                                                            rq.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                            rq.Host = "i.instagram.com";
                                                            rq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                            rq.Headers.Add("Accept-Language", "en-US");
                                                            rq.CookieContainer = req.CookieContainer;
                                                            HttpWebResponse respons;
                                                            try
                                                            {
                                                                respons = (HttpWebResponse)rq.GetResponse();
                                                            }
                                                            catch (WebException ep2)
                                                            {
                                                                respons = (HttpWebResponse)ep2.Response;
                                                            }
                                                            using (StreamReader streamReader2 = new StreamReader(respons.GetResponseStream()))
                                                            {
                                                                string r = streamReader2.ReadToEnd();
                                                                String Email = "";
                                                                string Phone = "";
                                                                string full_name = "";
                                                                String biography = "";
                                                                string external_url = "";
                                                                if (r.Contains("email"))
                                                                {
                                                                    Email = Regex.Match(r, "\"email\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("phone_number"))
                                                                {
                                                                    Phone = Regex.Match(r, "\"phone_number\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("full_name"))
                                                                {
                                                                    full_name = Regex.Match(r, "\"full_name\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("biography"))
                                                                {
                                                                    biography = Regex.Match(r, "\"biography\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                if (r.Contains("external_url"))
                                                                {
                                                                    external_url = Regex.Match(r, "\"external_url\": \"(.*?)\"").Groups[1].Value;
                                                                }
                                                                try
                                                                {
                                                                    Console.WriteLine("[!] Enter Target: ");
                                                                    string target = Console.ReadLine();
                                                                    bool start = true;
                                                                    int thread;
                                                                    Console.WriteLine("[!] Enter Thread:");
                                                                    thread = Convert.ToInt32(Console.ReadLine());
                                                                    while (start == true)
                                                                    {
                                                                        Parallel.For(0, thread, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i, stat) =>
                                                                        {
                                                                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                                                                            String Swap = "first_name=" + full_name + "&email=" + Email + "&username=" + target + "&phone_number=" + Phone + "&biography=" + biography + "&external_url=" + external_url + "&chaining_enabled=on";
                                                                            byte[] PostSwap = Encoding.UTF8.GetBytes(Swap);
                                                                            request.Method = "POST";
                                                                            request.UserAgent = "Instagram 35.0.0.20.96 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Li0N; vbox86p; vbox86; en_US; 95414347)";
                                                                            request.Host = "i.instagram.com";
                                                                            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                                                                            request.Headers.Add("Accept-Language", "en-US");
                                                                            request.ContentLength = (long)PostSwap.Length;
                                                                            request.CookieContainer = req.CookieContainer;
                                                                            Stream stream3 = request.GetRequestStream();
                                                                            stream3.Write(PostSwap, 0, PostSwap.Length);
                                                                            stream3.Close();
                                                                            HttpWebResponse response1;
                                                                            try
                                                                            {
                                                                                response1 = (HttpWebResponse)request.GetResponse();
                                                                            }
                                                                            catch (WebException ep3)
                                                                            {
                                                                                response1 = (HttpWebResponse)ep3.Response;
                                                                            }
                                                                            using (StreamReader text = new StreamReader(response1.GetResponseStream()))
                                                                            {
                                                                                String res = text.ReadToEnd();
                                                                                if (res.Contains("pk"))
                                                                                {
                                                                                    Console.WriteLine($"[!] Done Swap >> {target}");
                                                                                    start = false;
                                                                                    stat.Break();
                                                                                }
                                                                                else if (res.Contains("This username isn't available. Please try another."))
                                                                                {
                                                                                    Console.WriteLine("[!] Trying");
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("[!] Spam");
                                                                                    start = false;
                                                                                    stat.Break();

                                                                                }
                                                                            }
                                                                        });
                                                                    }
                                                                }
                                                                catch (Exception etp)
                                                                {

                                                                }
                                                            }
                                                        }
                                                        catch (Exception et)
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Write Only [Yes-No]");
                                                    }
                                                }
                                                if (LastSec.Contains("Please check the code we sent you and try again."))
                                                {
                                                    Console.WriteLine("[!] Wrong Code");
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        catch (Exception eepq)
                        {
                            
                        }
                    }
                }
            }       
            catch (Exception e)
            {

            }  
        }
    }
}