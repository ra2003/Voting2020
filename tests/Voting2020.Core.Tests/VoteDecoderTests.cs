using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace Voting2020.Core.Tests
{
	[TestFixture]
	public class VoteDecoderTests
	{
		[Test]
		public void DecodeTest()
		{
			VoteDecoder decoder = new VoteDecoder("db77d62fc88726f1c5a6b79b003b3bca83349e334337de84bd17344ab601db74".ParseHexEncodedValue());
			// Голос номер 778136
			//"{""message"":""7a2baaff59b5f862cff20fc059af42d9110bb5f6"",""nonce"":""6fe1a5f2052c79252a01bcb1f1019c7a92fd8e45c9504171"",""public_key"":""69e7b55df3370efd381e5a6c5c86002f3194183c3559f48705401152b6304313""}";"2212294583";"#2697378";"17:24:58";"5328b24e0deef4c8e6e48ed5ddc486058c8f77931cafebfe6a8b04a048011f3e0000e90306000a4064613835666166383466616562306539306566333161326537323532343135316662616330653266366536633439383336303133643634353239343639383864104d1a560a147a2baaff59b5f862cff20fc059af42d9110bb5f6121a0a186fe1a5f2052c79252a01bcb1f1019c7a92fd8e45c95041711a220a2069e7b55df3370efd381e5a6c5c86002f3194183c3559f48705401152b630431382f14251ad28b9ff582e1dc2b4e06020a8473b3022836a1151d957bf89f978e35dd4d37819e72d269053fa1797b80feb5dcb8798197d22626d19917571b4af09"
			EncryptedVote evote = new EncryptedVote("7a2baaff59b5f862cff20fc059af42d9110bb5f6", "6fe1a5f2052c79252a01bcb1f1019c7a92fd8e45c9504171", "69e7b55df3370efd381e5a6c5c86002f3194183c3559f48705401152b6304313");
			Assert.IsTrue(decoder.DecodeEndVerify(evote, out byte[] decoded));
			//"778136";77;"0x2bddd3d05570be9d417bd0b28d54e7adcf1f3c19b7ff74ae011ba9f31b7da7b7";"#606026";"16:56:59";"{""message"":""7a2baaff59b5f862cff20fc059af42d9110bb5f6"",""nonce"":""6fe1a5f2052c79252a01bcb1f1019c7a92fd8e45c9504171"",""public_key"":""69e7b55df3370efd381e5a6c5c86002f3194183c3559f48705401152b6304313""}"
			Assert.AreEqual(2212294583, BitConverter.ToUInt32(decoded));			
		}
	}
}