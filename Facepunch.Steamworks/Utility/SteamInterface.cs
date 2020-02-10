﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	internal abstract class SteamInterface
	{
		public abstract IntPtr GetInterfacePointer();

		public IntPtr Self;

		public bool IsValid => Self != IntPtr.Zero;

		internal void SetupInterface()
		{
			Self = GetInterfacePointer();
		}

		internal void ShutdownInterface()
		{
			Self = IntPtr.Zero;
		}
	}

	public abstract class SteamClass
	{
		internal abstract void InitializeInterface();
		internal void DestroyInterface()
		{
			Interface.ShutdownInterface();
		}

		internal abstract SteamInterface Interface { get; }
	}

}