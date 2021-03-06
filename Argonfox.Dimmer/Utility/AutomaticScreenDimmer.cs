﻿/*
    ArgonFox Dimmer
    Copyright (C) 2017 ArgonFox

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Windows;

namespace Argonfox.Dimmer.Utility
{
    internal static class AutomaticScreenDimmer
    {
        public static void Initialize()
        {
            ProcessWatchdog.OnProcessStarted += ProcessWatchdog_OnProcessStarted;
            ProcessWatchdog.OnProcessClosed += ProcessWatchdog_OnProcessClosed;
            ProcessWatchdog.Initialize();
        }

        private static void ProcessWatchdog_OnProcessClosed(int screenId)
        {
            Application.Current.Dispatcher.Invoke(() => Dimmer.ClearScreen(screenId));
        }

        private static void ProcessWatchdog_OnProcessStarted(int screenId)
        {
            Application.Current.Dispatcher.Invoke(() => Dimmer.DimScreen(screenId));
        }
    }
}