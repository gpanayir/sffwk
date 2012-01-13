using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Internal;
using DevExpress.XtraSpellChecker;
using System.Globalization;
using DevExpress.XtraRichEdit;

namespace Fwk.UI
{
	/// <summary>
	/// 
	/// </summary>
	public class CommonUtils {
        /// <summary>
        /// Obtiene la ruta relativa
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
		public static string GetRelativePath(string name) {
			name = string .Concat ( "Data\\" , name);
			string path = System.Windows.Forms.Application.StartupPath;
			string s = "\\";
			for (int i = 0; i <= 10; i++) {
				if (System.IO.File.Exists(path + s + name))
					return (path + s + name);
				else
					s += "..\\";
			}
			return string.Empty;
		}
	}
	public class RtfLoadHelper {
		public static void Load(String fileName, RichEditControl richEditControl) {
			string path = CommonUtils.GetRelativePath(fileName);
			if (!String.IsNullOrEmpty(path))
				richEditControl.LoadDocument(path, DocumentFormat.Rtf);
            
		}
	}
	public class SpellCheckerHelper {
		public static void AddDictionaries(SharedDictionaryStorage storage) {
			CultureInfo engCulture = new CultureInfo("en-us");
			if (storage.Dictionaries.Count == 0) {
				SpellCheckerISpellDictionary dictionary = new SpellCheckerISpellDictionary(CommonUtils.GetRelativePath(@"american.xlg"), CommonUtils.GetRelativePath("english.aff"), engCulture);
				dictionary.AlphabetPath = CommonUtils.GetRelativePath("EnglishAlphabet.txt");
                dictionary.Load();
				storage.Dictionaries.Add(dictionary);
				SpellCheckerCustomDictionary customDictionary = new SpellCheckerCustomDictionary(CommonUtils.GetRelativePath("CustomEnglish.dic"), engCulture);
                customDictionary.Load();
				storage.Dictionaries.Add(customDictionary);
			}
		}
	}
}
