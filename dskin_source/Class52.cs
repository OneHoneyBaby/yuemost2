using System;
using System.Collections.Generic;

internal static class Class52
{
    private static readonly KeyValuePair<string, string>[] keyValuePair_0 = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("&lt;", "<"), new KeyValuePair<string, string>("&gt;", ">"), new KeyValuePair<string, string>("&quot;", "\""), new KeyValuePair<string, string>("&amp;", "&") };
    private static readonly List<string> list_0 = new List<string>(new string[] { "area", "base", "basefont", "br", "col", "frame", "hr", "img", "input", "isindex", "link", "meta", "param" });
    private static readonly Dictionary<string, char> NejabnpYkh = new Dictionary<string, char>(StringComparer.InvariantCultureIgnoreCase);

    static Class52()
    {
        NejabnpYkh["nbsp"] = ' ';
        NejabnpYkh["rdquo"] = '"';
        NejabnpYkh["lsquo"] = '\'';
        NejabnpYkh["apos"] = '\'';
        NejabnpYkh["iexcl"] = Convert.ToChar(0xa1);
        NejabnpYkh["cent"] = Convert.ToChar(0xa2);
        NejabnpYkh["pound"] = Convert.ToChar(0xa3);
        NejabnpYkh["curren"] = Convert.ToChar(0xa4);
        NejabnpYkh["yen"] = Convert.ToChar(0xa5);
        NejabnpYkh["brvbar"] = Convert.ToChar(0xa6);
        NejabnpYkh["sect"] = Convert.ToChar(0xa7);
        NejabnpYkh["uml"] = Convert.ToChar(0xa8);
        NejabnpYkh["copy"] = Convert.ToChar(0xa9);
        NejabnpYkh["ordf"] = Convert.ToChar(170);
        NejabnpYkh["laquo"] = Convert.ToChar(0xab);
        NejabnpYkh["not"] = Convert.ToChar(0xac);
        NejabnpYkh["shy"] = Convert.ToChar(0xad);
        NejabnpYkh["reg"] = Convert.ToChar(0xae);
        NejabnpYkh["macr"] = Convert.ToChar(0xaf);
        NejabnpYkh["deg"] = Convert.ToChar(0xb0);
        NejabnpYkh["plusmn"] = Convert.ToChar(0xb1);
        NejabnpYkh["sup2"] = Convert.ToChar(0xb2);
        NejabnpYkh["sup3"] = Convert.ToChar(0xb3);
        NejabnpYkh["acute"] = Convert.ToChar(180);
        NejabnpYkh["micro"] = Convert.ToChar(0xb5);
        NejabnpYkh["para"] = Convert.ToChar(0xb6);
        NejabnpYkh["middot"] = Convert.ToChar(0xb7);
        NejabnpYkh["cedil"] = Convert.ToChar(0xb8);
        NejabnpYkh["sup1"] = Convert.ToChar(0xb9);
        NejabnpYkh["ordm"] = Convert.ToChar(0xba);
        NejabnpYkh["raquo"] = Convert.ToChar(0xbb);
        NejabnpYkh["frac14"] = Convert.ToChar(0xbc);
        NejabnpYkh["frac12"] = Convert.ToChar(0xbd);
        NejabnpYkh["frac34"] = Convert.ToChar(190);
        NejabnpYkh["iquest"] = Convert.ToChar(0xbf);
        NejabnpYkh["times"] = Convert.ToChar(0xd7);
        NejabnpYkh["divide"] = Convert.ToChar(0xf7);
        NejabnpYkh["Agrave"] = Convert.ToChar(0xc0);
        NejabnpYkh["Aacute"] = Convert.ToChar(0xc1);
        NejabnpYkh["Acirc"] = Convert.ToChar(0xc2);
        NejabnpYkh["Atilde"] = Convert.ToChar(0xc3);
        NejabnpYkh["Auml"] = Convert.ToChar(0xc4);
        NejabnpYkh["Aring"] = Convert.ToChar(0xc5);
        NejabnpYkh["AElig"] = Convert.ToChar(0xc6);
        NejabnpYkh["Ccedil"] = Convert.ToChar(0xc7);
        NejabnpYkh["Egrave"] = Convert.ToChar(200);
        NejabnpYkh["Eacute"] = Convert.ToChar(0xc9);
        NejabnpYkh["Ecirc"] = Convert.ToChar(0xca);
        NejabnpYkh["Euml"] = Convert.ToChar(0xcb);
        NejabnpYkh["Igrave"] = Convert.ToChar(0xcc);
        NejabnpYkh["Iacute"] = Convert.ToChar(0xcd);
        NejabnpYkh["Icirc"] = Convert.ToChar(0xce);
        NejabnpYkh["Iuml"] = Convert.ToChar(0xcf);
        NejabnpYkh["ETH"] = Convert.ToChar(0xd0);
        NejabnpYkh["Ntilde"] = Convert.ToChar(0xd1);
        NejabnpYkh["Ograve"] = Convert.ToChar(210);
        NejabnpYkh["Oacute"] = Convert.ToChar(0xd3);
        NejabnpYkh["Ocirc"] = Convert.ToChar(0xd4);
        NejabnpYkh["Otilde"] = Convert.ToChar(0xd5);
        NejabnpYkh["Ouml"] = Convert.ToChar(0xd6);
        NejabnpYkh["Oslash"] = Convert.ToChar(0xd8);
        NejabnpYkh["Ugrave"] = Convert.ToChar(0xd9);
        NejabnpYkh["Uacute"] = Convert.ToChar(0xda);
        NejabnpYkh["Ucirc"] = Convert.ToChar(0xdb);
        NejabnpYkh["Uuml"] = Convert.ToChar(220);
        NejabnpYkh["Yacute"] = Convert.ToChar(0xdd);
        NejabnpYkh["THORN"] = Convert.ToChar(0xde);
        NejabnpYkh["szlig"] = Convert.ToChar(0xdf);
        NejabnpYkh["agrave"] = Convert.ToChar(0xe0);
        NejabnpYkh["aacute"] = Convert.ToChar(0xe1);
        NejabnpYkh["acirc"] = Convert.ToChar(0xe2);
        NejabnpYkh["atilde"] = Convert.ToChar(0xe3);
        NejabnpYkh["auml"] = Convert.ToChar(0xe4);
        NejabnpYkh["aring"] = Convert.ToChar(0xe5);
        NejabnpYkh["aelig"] = Convert.ToChar(230);
        NejabnpYkh["ccedil"] = Convert.ToChar(0xe7);
        NejabnpYkh["egrave"] = Convert.ToChar(0xe8);
        NejabnpYkh["eacute"] = Convert.ToChar(0xe9);
        NejabnpYkh["ecirc"] = Convert.ToChar(0xea);
        NejabnpYkh["euml"] = Convert.ToChar(0xeb);
        NejabnpYkh["igrave"] = Convert.ToChar(0xec);
        NejabnpYkh["iacute"] = Convert.ToChar(0xed);
        NejabnpYkh["icirc"] = Convert.ToChar(0xee);
        NejabnpYkh["iuml"] = Convert.ToChar(0xef);
        NejabnpYkh["eth"] = Convert.ToChar(240);
        NejabnpYkh["ntilde"] = Convert.ToChar(0xf1);
        NejabnpYkh["ograve"] = Convert.ToChar(0xf2);
        NejabnpYkh["oacute"] = Convert.ToChar(0xf3);
        NejabnpYkh["ocirc"] = Convert.ToChar(0xf4);
        NejabnpYkh["otilde"] = Convert.ToChar(0xf5);
        NejabnpYkh["ouml"] = Convert.ToChar(0xf6);
        NejabnpYkh["oslash"] = Convert.ToChar(0xf8);
        NejabnpYkh["ugrave"] = Convert.ToChar(0xf9);
        NejabnpYkh["uacute"] = Convert.ToChar(250);
        NejabnpYkh["ucirc"] = Convert.ToChar(0xfb);
        NejabnpYkh["uuml"] = Convert.ToChar(0xfc);
        NejabnpYkh["yacute"] = Convert.ToChar(0xfd);
        NejabnpYkh["thorn"] = Convert.ToChar(0xfe);
        NejabnpYkh["yuml"] = Convert.ToChar(0xff);
        NejabnpYkh["forall"] = Convert.ToChar(0x2200);
        NejabnpYkh["part"] = Convert.ToChar(0x2202);
        NejabnpYkh["exist"] = Convert.ToChar(0x2203);
        NejabnpYkh["empty"] = Convert.ToChar(0x2205);
        NejabnpYkh["nabla"] = Convert.ToChar(0x2207);
        NejabnpYkh["isin"] = Convert.ToChar(0x2208);
        NejabnpYkh["notin"] = Convert.ToChar(0x2209);
        NejabnpYkh["ni"] = Convert.ToChar(0x220b);
        NejabnpYkh["prod"] = Convert.ToChar(0x220f);
        NejabnpYkh["sum"] = Convert.ToChar(0x2211);
        NejabnpYkh["minus"] = Convert.ToChar(0x2212);
        NejabnpYkh["lowast"] = Convert.ToChar(0x2217);
        NejabnpYkh["radic"] = Convert.ToChar(0x221a);
        NejabnpYkh["prop"] = Convert.ToChar(0x221d);
        NejabnpYkh["infin"] = Convert.ToChar(0x221e);
        NejabnpYkh["ang"] = Convert.ToChar(0x2220);
        NejabnpYkh["and"] = Convert.ToChar(0x2227);
        NejabnpYkh["or"] = Convert.ToChar(0x2228);
        NejabnpYkh["cap"] = Convert.ToChar(0x2229);
        NejabnpYkh["cup"] = Convert.ToChar(0x222a);
        NejabnpYkh["int"] = Convert.ToChar(0x222b);
        NejabnpYkh["there4"] = Convert.ToChar(0x2234);
        NejabnpYkh["sim"] = Convert.ToChar(0x223c);
        NejabnpYkh["cong"] = Convert.ToChar(0x2245);
        NejabnpYkh["asymp"] = Convert.ToChar(0x2248);
        NejabnpYkh["ne"] = Convert.ToChar(0x2260);
        NejabnpYkh["equiv"] = Convert.ToChar(0x2261);
        NejabnpYkh["le"] = Convert.ToChar(0x2264);
        NejabnpYkh["ge"] = Convert.ToChar(0x2265);
        NejabnpYkh["sub"] = Convert.ToChar(0x2282);
        NejabnpYkh["sup"] = Convert.ToChar(0x2283);
        NejabnpYkh["nsub"] = Convert.ToChar(0x2284);
        NejabnpYkh["sube"] = Convert.ToChar(0x2286);
        NejabnpYkh["supe"] = Convert.ToChar(0x2287);
        NejabnpYkh["oplus"] = Convert.ToChar(0x2295);
        NejabnpYkh["otimes"] = Convert.ToChar(0x2297);
        NejabnpYkh["perp"] = Convert.ToChar(0x22a5);
        NejabnpYkh["sdot"] = Convert.ToChar(0x22c5);
        NejabnpYkh["Alpha"] = Convert.ToChar(0x391);
        NejabnpYkh["Beta"] = Convert.ToChar(0x392);
        NejabnpYkh["Gamma"] = Convert.ToChar(0x393);
        NejabnpYkh["Delta"] = Convert.ToChar(0x394);
        NejabnpYkh["Epsilon"] = Convert.ToChar(0x395);
        NejabnpYkh["Zeta"] = Convert.ToChar(0x396);
        NejabnpYkh["Eta"] = Convert.ToChar(0x397);
        NejabnpYkh["Theta"] = Convert.ToChar(920);
        NejabnpYkh["Iota"] = Convert.ToChar(0x399);
        NejabnpYkh["Kappa"] = Convert.ToChar(0x39a);
        NejabnpYkh["Lambda"] = Convert.ToChar(0x39b);
        NejabnpYkh["Mu"] = Convert.ToChar(0x39c);
        NejabnpYkh["Nu"] = Convert.ToChar(0x39d);
        NejabnpYkh["Xi"] = Convert.ToChar(0x39e);
        NejabnpYkh["Omicron"] = Convert.ToChar(0x39f);
        NejabnpYkh["Pi"] = Convert.ToChar(0x3a0);
        NejabnpYkh["Rho"] = Convert.ToChar(0x3a1);
        NejabnpYkh["Sigma"] = Convert.ToChar(0x3a3);
        NejabnpYkh["Tau"] = Convert.ToChar(0x3a4);
        NejabnpYkh["Upsilon"] = Convert.ToChar(0x3a5);
        NejabnpYkh["Phi"] = Convert.ToChar(0x3a6);
        NejabnpYkh["Chi"] = Convert.ToChar(0x3a7);
        NejabnpYkh["Psi"] = Convert.ToChar(0x3a8);
        NejabnpYkh["Omega"] = Convert.ToChar(0x3a9);
        NejabnpYkh["alpha"] = Convert.ToChar(0x3b1);
        NejabnpYkh["beta"] = Convert.ToChar(0x3b2);
        NejabnpYkh["gamma"] = Convert.ToChar(0x3b3);
        NejabnpYkh["delta"] = Convert.ToChar(0x3b4);
        NejabnpYkh["epsilon"] = Convert.ToChar(0x3b5);
        NejabnpYkh["zeta"] = Convert.ToChar(950);
        NejabnpYkh["eta"] = Convert.ToChar(0x3b7);
        NejabnpYkh["theta"] = Convert.ToChar(0x3b8);
        NejabnpYkh["iota"] = Convert.ToChar(0x3b9);
        NejabnpYkh["kappa"] = Convert.ToChar(0x3ba);
        NejabnpYkh["lambda"] = Convert.ToChar(0x3bb);
        NejabnpYkh["mu"] = Convert.ToChar(0x3bc);
        NejabnpYkh["nu"] = Convert.ToChar(0x3bd);
        NejabnpYkh["xi"] = Convert.ToChar(0x3be);
        NejabnpYkh["omicron"] = Convert.ToChar(0x3bf);
        NejabnpYkh["pi"] = Convert.ToChar(960);
        NejabnpYkh["rho"] = Convert.ToChar(0x3c1);
        NejabnpYkh["sigmaf"] = Convert.ToChar(0x3c2);
        NejabnpYkh["sigma"] = Convert.ToChar(0x3c3);
        NejabnpYkh["tau"] = Convert.ToChar(0x3c4);
        NejabnpYkh["upsilon"] = Convert.ToChar(0x3c5);
        NejabnpYkh["phi"] = Convert.ToChar(0x3c6);
        NejabnpYkh["chi"] = Convert.ToChar(0x3c7);
        NejabnpYkh["psi"] = Convert.ToChar(0x3c8);
        NejabnpYkh["omega"] = Convert.ToChar(0x3c9);
        NejabnpYkh["thetasym"] = Convert.ToChar(0x3d1);
        NejabnpYkh["upsih"] = Convert.ToChar(0x3d2);
        NejabnpYkh["piv"] = Convert.ToChar(0x3d6);
        NejabnpYkh["OElig"] = Convert.ToChar(0x152);
        NejabnpYkh["oelig"] = Convert.ToChar(0x153);
        NejabnpYkh["Scaron"] = Convert.ToChar(0x160);
        NejabnpYkh["scaron"] = Convert.ToChar(0x161);
        NejabnpYkh["Yuml"] = Convert.ToChar(0x178);
        NejabnpYkh["fnof"] = Convert.ToChar(0x192);
        NejabnpYkh["circ"] = Convert.ToChar(710);
        NejabnpYkh["tilde"] = Convert.ToChar(0x2dc);
        NejabnpYkh["ndash"] = Convert.ToChar(0x2013);
        NejabnpYkh["mdash"] = Convert.ToChar(0x2014);
        NejabnpYkh["lsquo"] = Convert.ToChar(0x2018);
        NejabnpYkh["rsquo"] = Convert.ToChar(0x2019);
        NejabnpYkh["sbquo"] = Convert.ToChar(0x201a);
        NejabnpYkh["ldquo"] = Convert.ToChar(0x201c);
        NejabnpYkh["rdquo"] = Convert.ToChar(0x201d);
        NejabnpYkh["bdquo"] = Convert.ToChar(0x201e);
        NejabnpYkh["dagger"] = Convert.ToChar(0x2020);
        NejabnpYkh["Dagger"] = Convert.ToChar(0x2021);
        NejabnpYkh["bull"] = Convert.ToChar(0x2022);
        NejabnpYkh["hellip"] = Convert.ToChar(0x2026);
        NejabnpYkh["permil"] = Convert.ToChar(0x2030);
        NejabnpYkh["prime"] = Convert.ToChar(0x2032);
        NejabnpYkh["Prime"] = Convert.ToChar(0x2033);
        NejabnpYkh["lsaquo"] = Convert.ToChar(0x2039);
        NejabnpYkh["rsaquo"] = Convert.ToChar(0x203a);
        NejabnpYkh["oline"] = Convert.ToChar(0x203e);
        NejabnpYkh["euro"] = Convert.ToChar(0x20ac);
        NejabnpYkh["trade"] = Convert.ToChar(0x99);
        NejabnpYkh["larr"] = Convert.ToChar(0x2190);
        NejabnpYkh["uarr"] = Convert.ToChar(0x2191);
        NejabnpYkh["rarr"] = Convert.ToChar(0x2192);
        NejabnpYkh["darr"] = Convert.ToChar(0x2193);
        NejabnpYkh["harr"] = Convert.ToChar(0x2194);
        NejabnpYkh["crarr"] = Convert.ToChar(0x21b5);
        NejabnpYkh["lceil"] = Convert.ToChar(0x2308);
        NejabnpYkh["rceil"] = Convert.ToChar(0x2309);
        NejabnpYkh["lfloor"] = Convert.ToChar(0x230a);
        NejabnpYkh["rfloor"] = Convert.ToChar(0x230b);
        NejabnpYkh["loz"] = Convert.ToChar(0x25ca);
        NejabnpYkh["spades"] = Convert.ToChar(0x2660);
        NejabnpYkh["clubs"] = Convert.ToChar(0x2663);
        NejabnpYkh["hearts"] = Convert.ToChar(0x2665);
        NejabnpYkh["diams"] = Convert.ToChar(0x2666);
    }

    public static bool smethod_0(object object_0)
    {
        return list_0.Contains((string) object_0);
    }

    public static string smethod_1(string string_0)
    {
        if (!string.IsNullOrEmpty(string_0))
        {
            string_0 = smethod_3(string_0);
            string_0 = smethod_4(string_0);
            foreach (KeyValuePair<string, string> pair in keyValuePair_0)
            {
                string_0 = string_0.Replace(pair.Key, pair.Value);
            }
        }
        return string_0;
    }

    public static string smethod_2(string string_0)
    {
        if (!string.IsNullOrEmpty(string_0))
        {
            for (int i = keyValuePair_0.Length - 1; i >= 0; i--)
            {
                string_0 = string_0.Replace(keyValuePair_0[i].Value, keyValuePair_0[i].Key);
            }
        }
        return string_0;
    }

    private static string smethod_3(string string_0)
    {
        // This item is obfuscated and can not be translated.
        for (int i = string_0.IndexOf("&#", StringComparison.OrdinalIgnoreCase); i > -1; i = string_0.IndexOf("&#", (int) (i + 1)))
        {
            bool flag = (string_0.Length > (i + 3)) && (char.ToLower(string_0[i + 2]) == 'x');
            int num2 = (i + 2) + (flag ? 1 : 0);
            long num3 = 0L;
            while (num2 >= string_0.Length)
            {
            Label_004C:
                if (0 == 0)
                {
                    goto Label_008A;
                }
                num3 = (num3 * (flag ? ((long) 0x10) : ((long) 10))) + Class48.smethod_3(string_0[num2++], flag);
            }
            goto Label_004C;
        Label_008A:
            num2 += ((num2 >= string_0.Length) || (string_0[num2] != ';')) ? 0 : 1;
            string_0 = string_0.Remove(i, num2 - i);
            string_0 = string_0.Insert(i, Convert.ToChar(num3).ToString());
        }
        return string_0;
    }

    private static string smethod_4(string string_0)
    {
        for (int i = string_0.IndexOf('&'); i > -1; i = string_0.IndexOf('&', i + 1))
        {
            int index = string_0.IndexOf(';', i);
            if ((index > -1) && ((index - i) < 8))
            {
                char ch;
                string key = string_0.Substring(i + 1, (index - i) - 1);
                if (NejabnpYkh.TryGetValue(key, out ch))
                {
                    string_0 = string_0.Remove(i, (index - i) + 1);
                    string_0 = string_0.Insert(i, ch.ToString());
                }
            }
        }
        return string_0;
    }
}

