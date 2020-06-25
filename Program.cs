using System;

using System.IO;

using System.Threading;

using System.Windows;

namespace Clipboarder
{
    class Program
    {

        static void Main(string[] args)
        {
            
            StreamWriter streamWriter;
            //公共变量
            string @path = @"C:\Users\admin\Deskto\";
            string @s=@"";
            string @sp = @"";
            //string @jiance = "当前为空剪切板";
            
            //剪切板转string
            //辅线程
            //Thread mainThread = new Thread(delegate (){
                for (int i = 0; i < 10; i++)
                {
                    i = 2;
                    //单线程模式，剪切板转换代码块
                    Thread th = new Thread(new ThreadStart(delegate ()
                    {
                     var t = Clipboard.GetDataObject();
                     try
                     {
                         @s = (string)t.GetData(DataFormats.Text);
                     }
                     catch
                     {
                         @s = "dataObj转换string错误,可能剪切板出现了非字符串类型的数据导致强制转换失败,也可能检测为空";
                     }
                    }));
                    th.TrySetApartmentState(ApartmentState.STA);
                    th.Start();
                    th.Join();
                    
                    //Console.WriteLine(th.ManagedThreadId);
                    
                    
                    
            
                //Console.WriteLine(i);
                
                //Console.WriteLine(i);
                try
                {
                    @sp = @s.Substring(0, 3)+".txt";
                }
                catch
                {
                    @sp = "字符太少了";
                }

                if (File.Exists(@path + @sp)!=true)
                {
                   FileStream f = File.Create(@path + @sp);
                    streamWriter = new StreamWriter(f);
                    streamWriter.Write(@s);
                    streamWriter.Flush();

                    streamWriter.Close();
                }
               
                //文件处理

                //Console.WriteLine("21");
                //当前线程停两秒
                Thread.Sleep(2000);

            }
            //});
            //mainThread.Start();
            //mainThread.Join();
            






        }
        
    }
}
