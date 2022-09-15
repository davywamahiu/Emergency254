using System;
namespace Emergency254.BurgainRoad
{
	public class User
	{
		private static string uid;

		public static string UserName
		{
			get {
				return uid;
			}
			set
			{
				uid = value;
			}
		}


		private User(){}

	}
}
