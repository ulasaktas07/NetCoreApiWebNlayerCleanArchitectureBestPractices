﻿namespace App.Repositories.Connection
{
	public class ConnectionStringOption
	{
		public const string Key = "ConnectionStrings";
		public string SqlServer { get; set; } = default!;
	}
}
