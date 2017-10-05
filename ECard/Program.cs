using System;
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
			var b = new BaseService.BaseService();
			b.Url = "https://10.196.4.114/base/15";

			var readers = b.getCardReaders();
			var reader = readers[0];

			var prodInfo = new produktInfo();
			prodInfo.produktId = 900101;
			prodInfo.produktVersion = "0.0.1";
			prodInfo.produktIdSpecified = true;

			var dialog = b.createDialog(reader.id, prodInfo, "", true, true);
			
			var vp = b.authenticateDialog(dialog, "", "1122", reader.id);
			var tb = vp.ordination[0].taetigkeitsBereich;

			b.setDialogAddress(dialog, vp.ordination[0].ordinationId, tb[0].id, "700",  new gdaMa(), "");

			b.closeDialog(dialog);
			Console.WriteLine("Alles super.");
			Console.ReadKey();
		}
	}
}
