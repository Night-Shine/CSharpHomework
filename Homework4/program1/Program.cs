using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);

        public class AlarmEventArgs : EventArgs {
            public int a;
            public int b;
            public int c;
        }
        public class AlarmClock {
            public event AlarmEventHandler AlarmEvent;
            private AlarmEventArgs alarm;

            private int Hour;
            private int Minute;
            private int Second;

            public AlarmClock(){
                this.Hour = DateTime.Now.Hour;
                this.Minute = DateTime.Now.Minute;
                this.Second = DateTime.Now.Second;

                alarm = new AlarmEventArgs();
                AlarmEvent += Alarm;
            }

            public void SetAlarmClock() {
                try {
                    Console.WriteLine("请输入闹钟时间（时、分、秒）：");
                    int a = Int32.Parse(Console.ReadLine());
                    int b = Int32.Parse(Console.ReadLine());
                    int c = Int32.Parse(Console.ReadLine());
                    alarm.a = a;
                    alarm.b = b;
                    alarm.c = c;
                }
                catch {
                    Console.WriteLine("输入错误请重新输入：");
                    SetAlarmClock();
                }
            }

            public void Update(){
                do
                {
                    this.Hour = DateTime.Now.Hour;
                    this.Minute = DateTime.Now.Minute;
                    this.Second = DateTime.Now.Second;
                } while (!(this.Hour == alarm.a && this.Minute == alarm.b && this.Second == alarm.c));
                {
                    AlarmEvent(this, alarm);
                }
            }

            private void Alarm(object sender, AlarmEventArgs e)
            {
                Console.WriteLine("闹钟时间到了。。。。。。");
                Console.WriteLine("当前时间：" + this.Hour + ":" + this.Minute + ":" + this.Second);
            }
        }
        static void Main(string[] args)
        {
            AlarmClock AlarmClock = new AlarmClock();
            AlarmClock.SetAlarmClock();
            AlarmClock.Update();
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
