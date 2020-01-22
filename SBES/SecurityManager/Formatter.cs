﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityManager
{
    public class Formatter
    {
        /// <summary>
        /// Returns username based on the Windows Logon Name. 
        /// </summary>
        /// <param name="winLogonName"> Windows logon name can be formatted either as a UPN (<username>@<domain_name>) or a SPN (<domain_name>\<username>) </param>
        /// <returns> username </returns>
        public static string ParseName(string winLogonName)
        {
            string[] parts = new string[] { };

            if (winLogonName.Contains("@"))
            {
                ///UPN format
                parts = winLogonName.Split('@');
                return parts[0];
            }
            else if (winLogonName.Contains("\\"))
            {
                /// SPN format
                parts = winLogonName.Split('\\');
                return parts[1];
            }
            else
            {
                return winLogonName;
            }
        }

        public static string ParseSubjectName(string subjectName)
        {
            var subjName = subjectName.Split(' ')[0].Substring(4);
            return subjName;
        }

        public static string ParseClientSubjectName(string fullName)
        {
            string subjectName = fullName.Split(',')[0];

            // Mora se izbirsati CN=
            subjectName = subjectName.Remove(0, 3);

            return subjectName;
        }
    }
}
