﻿using System;

using Test6_mod.ViewModels.Exceptions;

namespace Test6_mod.ViewModels.Event
{
    public class AddUrlEventArgs : EventArgs
    {
        public string URL { get; private set; }

        public AddUrlEventArgs(in string url)
        {
            if (testURL(url))
                URL = url;
            else
                throw new PathUrlExeption();
        }

        private bool testURL(string u)
        {
            u = u.Substring(0, u.LastIndexOf(":"));
            if (u == "http" || u == "https")
            {
                return true;
            }
            else return false;
        }
    }
}