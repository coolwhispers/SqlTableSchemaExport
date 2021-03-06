﻿using System;

namespace DbSchemaExporter.Core
{
    public class DatabaseSettingModel
    {
        public bool HasConnectionString
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ConnectionString);
            }
        }
        public string ConnectionString { get; set; }
        public string DbType { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public string HostString
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                var temp = value.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                Host = temp[0];
                Port = 0;
                if (temp.Length > 1)
                {
                    Port = int.Parse(temp[1]);
                }
            }
        }

        public void SetDefaultPort(int port)
        {
            if (Port > 0)
            {
                return;
            }
            Port = port;
        }
    }
}
