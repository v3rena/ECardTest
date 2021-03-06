﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECard.BaseService;

namespace ECard
{
	class Program
	{
		static void Main(string[] args)
		{
			var b = new BaseService.BaseService
			{
				Url = "https://10.196.4.114/base/15"
			};

			AuthenticateCard(b);

			Console.WriteLine("Alles super."); Console.ReadKey();
		}

		public static void AuthenticateCard(BaseService.BaseService b)
		{
			var readers = b.getCardReaders();
			var reader = readers[0];

			var prodInfo = new produktInfo()
			{
				produktId = 900101,
				produktVersion = "0.0.1",
				produktIdSpecified = true
			};

			string dialog = b.createDialog(reader.id, prodInfo, "", true, true);

			var vp = b.authenticateDialog(dialog, "", "1122", reader.id);
			var tb = vp.ordination[0].taetigkeitsBereich;
			
			var gdaMa = new BaseServiceRef.gdaMa
			{
			    vorname = "Max",
			    nachname = "Mustermann",
			    zusatzinfo = "Zusatzinfo"
			};

			b.setDialogAddress(dialog, vp.ordination[0].ordinationId, tb[0].id, "700", gdaMa, "");
	
			b.closeDialog(dialog);
		}
	}
}
