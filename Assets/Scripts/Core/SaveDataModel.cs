using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Herghys.Game.Quiz;
using Newtonsoft.Json;

namespace Herghys.Core
{
	[Serializable]
	public class SaveDataModel
	{
		[JsonProperty("Nama")]
		public string Name { get; set; }
		[JsonProperty("Score")]
		public int Score { get; set; }
		[JsonProperty("JumlahBenar")]
		public int JumlahBenar { get; set; }
		[JsonProperty("Jawaban")]
		public List<AnsweredQuestion> AnsweredQuestions { get; set; } = new List<AnsweredQuestion>();
	}
}
