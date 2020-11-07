﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace Fhi.Smittestopp.Verification.Server.Credentials
{
    public class CertificateVersion
    {
        public X509Certificate2 Certificate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}