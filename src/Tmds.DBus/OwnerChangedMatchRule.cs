﻿// Copyright 2016 Tom Deseyn <tom.deseyn@gmail.com>
// This software is made available under the MIT License
// See COPYING for details

using System.Text;

namespace Tmds.DBus
{
    internal class OwnerChangedMatchRule : SignalMatchRule
    {
        public OwnerChangedMatchRule(string serviceName)
        {
            ServiceName = serviceName;
            Interface = DBusConnection.DBusInterface;
            Member = "NameOwnerChanged";
            Path = DBusConnection.DBusObjectPath;
        }

        public string ServiceName { get; set; }

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();
            hash = hash * 23 + (ServiceName == null ? 0 : ServiceName.GetHashCode());
            return hash;
        }

        public override bool Equals(object o)
        {
            OwnerChangedMatchRule r = o as OwnerChangedMatchRule;
            if (o == null)
                return false;

            return Interface == r.Interface &&
                Member == r.Member &&
                Path == r.Path &&
                ServiceName == r.ServiceName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            Append(sb, "type", "signal");

            if (Interface != null)
            {
                Append(sb, "interface", Interface);
            }
            if (Member != null)
            {
                Append(sb, "member", Member);
            }
            if (Member != null)
            {
                Append(sb, "path", Path.Value);
            }
            if (ServiceName != null)
            {
                Append(sb, "arg0", ServiceName);
            }

            return sb.ToString();
        }
    }
}
