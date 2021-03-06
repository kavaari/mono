//
// NvdlValidatingReaderTests.cs
//
// Authors:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell Inc.
//

using System;
using System.IO;
using System.Xml;
using Commons.Xml.Nvdl;
using NUnit.Framework;

namespace MonoTests.Commons.Xml.Nvdl
{
	[TestFixture]
	public class NvdlValidatingReaderTests
	{
		[Test]
		public void ReadNvdlNvdl ()
		{
			using (TextReader r = File.OpenText ("Test/XmlFiles/nvdl.nvdl")) {
				NvdlRules rules = NvdlReader.Read (
					new XmlTextReader (r));
			}
		}

		[Test]
		public void ValidateNvdlNvdl ()
		{
			NvdlRules rules = null;
			string path = "Test/XmlFiles/nvdl.nvdl";
			using (TextReader r = File.OpenText (path)) {
				rules = NvdlReader.Read (
					new XmlTextReader (path, r));
			}
			using (TextReader r = File.OpenText (path)) {
				XmlTextReader xtr = new XmlTextReader (path, r);
				NvdlValidatingReader vr = new NvdlValidatingReader (xtr, rules);
				while (!vr.EOF)
					vr.Read ();
			}				
		}
	}
}
