using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}



//ʵ������2 Ա�����µ�������ϵͳ
//����һ��Ա�����µ�������ϵͳ, ��дӦ�ó������ϵͳ������
//1. ����������
//Ա���Ļ�����Ϣ��Ա����š�������Ա��״̬��1-��ְ��2-��ְ��3-���ã�4-��ְ��5-��Ƹ��6-���ݣ����������ڡ�������λ��ְ�����ڲ��ű�ŵȣ�
//���ű����ű�š��������Ƶȣ�
//������Ϣ����š�Ա����š��������ڡ����벿�š��������š�����ԭ��ȣ�
//2. ϵͳӦʵ��������Ҫ���ܣ�
//��1����¼��ѯ����
//     ϵͳ����Ա��¼�������Ϣ���鿴Ա��״̬��ĳ��Ա���ĵ�����Ϣ�ȣ�
//��2��������ϵͳ
//     Ҫ��ʵ�ֹ�����ϵ���������ܵ�����Ϣ��¼�룬�޸�Ա������������Ӧ��Ϣ��
//��3�������ݴ�����ϵͳ
//     Ҫ�󣺽�����������Ϣ��¼�룬�޸�Ա������������Ӧ��Ϣ��
//��4��ϵͳά��
//     Ҫ��ǰ̨�ṩԱ��������Ϣ�ı��ݹ��ܡ������Ѻã����ۣ��������㡣




